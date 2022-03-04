/* eslint-disable */
import React, {useEffect, useRef, useState} from "react";
import {message} from "antd";
import {Link as RouterLink} from 'react-router-dom';
import {
    getUsers,
    countNewMessages,
    findChatMessages,
    findChatMessage
} from "../services/chat-service";
import {useRecoilState} from "recoil";
import {
    chatActiveContact,
    chatMessages,
} from "../atom/globalState";
import ScrollToBottom from "react-scroll-to-bottom";
import "../style/Chat.css";
import {useNavigate} from "react-router";
import AuthService from '../services/auth-service';
import CogIcon from '../icons/Cog';
import PencilAltIcon from '../icons/PencilAlt';
import {
    Avatar, AvatarGroup,
    Box, Chip,
    Divider,
    IconButton,
    Link,
    ListItem,
    ListItemAvatar, ListItemText,
    TextField,
    Tooltip,
    Typography
} from "@material-ui/core";
import SendIcon from "@material-ui/icons/Send";
import moment from 'moment';
import {ChatContactSearch, ChatThreadToolbar} from "../components/chat";
import Scrollbar from "../components/Scrollbar";

let stompClient = null;
const Chat = () => {
    const navigate = useNavigate();
    const currentUser = AuthService.getCurrentUser();
    const [text, setText] = useState("");
    const [contacts, setContacts] = useState([]);
    const [activeContact, setActiveContact] = useRecoilState(chatActiveContact);
    const [messages, setMessages] = useRecoilState(chatMessages);
    const rootRef = useRef(null);

    const parentalCallback = (value) => {
        setActiveContact(value);
    }
    useEffect(() => {
        if (AuthService.getCurrentUser() === "") {
            navigate("/");
        }
        connect();
        loadContacts();
    }, []);

    useEffect(() => {
        if (Object.keys(activeContact).length !== 0) {
            findChatMessages(activeContact.id.toString(), currentUser.id.toString()).then((response) => {
                    setMessages(response.data)
                }
            );
            loadContacts();
        }
    }, [activeContact]);

    const scrollToBottom = () => {
        // eslint-disable-next-line no-underscore-dangle
        if (rootRef?.current?._container) {
            // eslint-disable-next-line no-underscore-dangle
            rootRef.current._container.scrollTop = rootRef.current._container.scrollHeight;
        }
    };

    useEffect(() => {
        scrollToBottom();
    }, [messages, scrollToBottom]);

    const connect = () => {
        const Stomp = require("stompjs");
        let SockJS = require("sockjs-client");
        SockJS = new SockJS("http://localhost:8080/ws");
        stompClient = Stomp.over(SockJS);
        stompClient.connect({}, onConnected, onError);
    };

    const onConnected = () => {
        console.log("connected");
        stompClient.subscribe(
            "/user/" + currentUser.id.toString() + "/queue/messages",
            onMessageReceived
        );
    };

    const onError = (err) => {
        console.log(err);
    };

    const onMessageReceived = (msg) => {
        const notification = JSON.parse(msg.body);

        const session = JSON.parse(sessionStorage.getItem("recoil-persist"));
        console.log(session);
        if (session !== null) {
            const active = session.chatActiveContact;
            if (active.id.toString() === notification.senderId) {
                findChatMessage(notification.id.toString()).then((response) => {
                    const newMessages = JSON.parse(sessionStorage.getItem("recoil-persist"))
                        .chatMessages;
                    newMessages.push(response.data);
                    setMessages(newMessages);
                });
            } else {
                message.info("Received a new message from " + notification.senderName);
            }
        } else {
            message.info("Received a new message from " + notification.senderName);
        }
        loadContacts();
    };

    const sendMessage = (msg) => {
        if (msg.trim() !== "") {
            const message = {
                senderId: currentUser.id.toString(),
                recipientId: activeContact.id.toString(),
                senderName: currentUser.firstName + " " + currentUser.lastName,
                recipientName: activeContact.firstName + " " + activeContact.lastName,
                content: msg,
                timestamp: new Date(),
            };
            stompClient.send("/api/chat", {}, JSON.stringify(message));

            let newMessages = [];
            if (messages.length > 0) {
                newMessages = [...messages];
            }
            newMessages.push(message);
            setMessages(newMessages);


            let contact = contacts.filter((c) => c.id.toString() === activeContact.id.toString())
                .map((contact) => {
                    return contact;
                })[0]
            contact.lastMessage = message;
            contact.newMessages = 0;
            const copy = {...message};
            contact.lastMessage = formatLastMessage(copy);
            let newContacts = contacts.filter((c) => c.id.toString() !== activeContact.id.toString());
            newContacts.push(contact);
            const sorted = filterByLastMessage(newContacts);
            setContacts(sorted);
        }
    };

    const filterByLastMessage = (contacts) => {
        const notEmpty = contacts.filter((c) => !!c.lastMessage);
        const empty = contacts.filter((c) => !c.lastMessage);

        const sorted = [].concat(notEmpty)
            .sort((a, b) => b.lastMessage.timestamp.localeCompare(a.lastMessage.timestamp));
        return sorted.concat(empty);
    }

    const formatLastMessage = (lastMessage) => {
        let name = lastMessage.senderName.split(' ')[0] + ": ";
        let time;
        let message = lastMessage.content;
        if (message.length >= 20) {
            message = message.substring(0, 17) + '...';
        }
        if (lastMessage.senderId.toString() === currentUser.id.toString()) {
            name = 'Me: ';
        }
        time = getMsgTime(lastMessage.timestamp);
        lastMessage.formattedContent = name + message + " ·" + time;
        return lastMessage;
    }

    const getMsgTime = (msgTime) => {
        let date1 = moment(msgTime);
        let date2 = moment(Date.now());
        const dayDif = date2.diff(date1, 'days');
        if (dayDif > 0 && dayDif < 7) {
            return date1.toLocaleString('en-us', {weekday: 'short'});
        } else if (dayDif <= 0) {
            return moment(date1).format('HH:mm');
        } else {
            return moment(date1).format('DD.MM');
        }
    }

    const loadContacts = () => {
        const promise = getUsers().then((response) =>
            response.data.map((contact) =>
                countNewMessages(contact.id.toString(), currentUser.id.toString()).then((response) => {
                    contact.newMessages = response.data.newMessages;
                    contact.lastMessage = response.data.lastMessage;
                    if (contact.lastMessage) {
                        contact.lastMessage = formatLastMessage(contact.lastMessage);
                    }

                    return contact;
                })
            )
        );

        promise.then((promises) =>
            Promise.all(promises).then((users) => {

                setContacts(filterByLastMessage(users.filter(user => user.id.toString() !== currentUser.id.toString())));
                if (activeContact === undefined && contacts.length > 0) {
                    setActiveContact(contacts[0]);
                }
            })
        );
    };


    //THREAD LIST SEARCH
    const [isSearchFocused, setIsSearchFocused] = useState(false);
    const [searchQuery, setSearchQuery] = useState('');
    const [searchResults, setSearchResults] = useState([]);

    const handleSearchClickAway = () => {
        setIsSearchFocused(false);
        setSearchQuery('');
    };

    const handleSearchChange = (event) => {
        try {
            const {value} = event.target;

            setSearchQuery(value);

            if (value) {
                let data = contacts.filter((contact) => {
                    let matches = true;

                    if (value && !contact.firstName.toLowerCase().includes(value.toLowerCase()) && !contact.lastName.toLowerCase().includes(value.toLowerCase())) {
                        matches = false;
                    }
                    return matches;
                });
                setSearchResults(data);
            } else {
                setSearchResults(contacts);
            }
        } catch (err) {
            console.error(err);
        }
    };


    const handleSearchFocus = () => {
        setIsSearchFocused(true);
    };


    return (

        <>
            <Box
                sx={{
                    backgroundColor: 'background.default',
                    display: 'flex',
                    height: '100%'
                }}
            >
                <Box
                    sx={{
                        backgroundColor: 'background.paper',
                        borderRight: 1,
                        borderColor: 'divider',
                        display: 'flex',
                        flexDirection: 'column',
                        maxWidth: '100%',
                        width: 300
                    }}
                >
                    <Box
                        sx={{
                            alignItems: 'center',
                            display: 'flex',
                            flexShrink: 0,
                            height: 64,
                            px: 2
                        }}
                    >
                        <Typography
                            color="textPrimary"
                            variant="h5"
                        >
                            Chats
                        </Typography>
                        <Box sx={{flexGrow: 1}}/>
                        <IconButton>
                            <CogIcon fontSize="small"/>
                        </IconButton>
                        <IconButton
                            component={RouterLink}
                            to="/dashboard/chat/new"
                        >
                            <PencilAltIcon fontSize="small"/>
                        </IconButton>
                    </Box>
                    <Box
                        sx={{
                            display: {
                                sm: 'block',
                                xs: 'none'
                            }
                        }}
                    >
                        <ChatContactSearch
                            isFocused={isSearchFocused}
                            onChange={handleSearchChange}
                            onClickAway={handleSearchClickAway}
                            onFocus={handleSearchFocus}
                            query={searchQuery}
                            results={searchResults}
                            parentalCallback={parentalCallback}
                        />
                    </Box>
                    <Scrollbar options={{suppressScrollX: true}}>
                        <Box sx={{display: isSearchFocused ? 'none' : undefined}}>
                            {/*thread list*/}
                            {contacts.map((contact) => (
                                <ListItem
                                    button
                                    onClick={() => {
                                        setActiveContact(contact);
                                    }}
                                    sx={{
                                        backgroundColor: activeContact && Number(contact.id) === Number(activeContact.id) && 'action.selected',
                                        boxShadow: (theme) => activeContact && Number(contact.id) === Number(activeContact.id) && `inset 4px 0px 0px ${theme.palette.primary.main}`
                                    }}
                                >
                                    <ListItemAvatar
                                        sx={{
                                            display: 'flex',
                                            justifyContent: {
                                                sm: 'flex-start',
                                                xs: 'center'
                                            }
                                        }}
                                    >
                                        <AvatarGroup
                                            max={2}
                                            sx={{
                                                '& .MuiAvatar-root':
                                                    {
                                                        height: 36,
                                                        width: 36
                                                    }
                                            }}
                                        >
                                            <Avatar
                                                key={contact.id}
                                                src={'avatar'}
                                            />
                                        </AvatarGroup>
                                    </ListItemAvatar>
                                    <ListItemText
                                        primary={contact.firstName + " " + contact.lastName}
                                        primaryTypographyProps={{
                                            color: 'textPrimary',
                                            noWrap: true,
                                            variant: 'subtitle2'
                                        }}
                                        secondary={contact.lastMessage && contact.lastMessage.formattedContent || "Start the chat now!"}
                                        secondaryTypographyProps={{
                                            color: 'textSecondary',
                                            noWrap: true,
                                            variant: 'body2'
                                        }}
                                        sx={{
                                            display: {
                                                sm: 'block',
                                                xs: 'none'
                                            }
                                        }}
                                    />
                                    <Box
                                        sx={{
                                            alignItems: 'flex-end',
                                            display: {
                                                sm: 'flex',
                                                xs: 'none'
                                            },
                                            flexDirection: 'column',
                                            ml: 2
                                        }}
                                    >
                                        {contact.newMessages !== undefined &&
                                        contact.newMessages > 0 && (
                                            <Chip
                                                color="primary"
                                                label={contact.newMessages}
                                                size="small"
                                                sx={{
                                                    height: 18,
                                                    mt: '2px',
                                                    minWidth: 18,
                                                    p: '2px'
                                                }}
                                            />
                                        )}
                                    </Box>
                                </ListItem>
                            ))}
                            {/*thread list*/}
                        </Box>
                    </Scrollbar>
                </Box>
                <Box
                    sx={{
                        backgroundColor: 'background.default',
                        display: 'flex',
                        flexDirection: 'column',
                        flexGrow: 1
                    }}
                >
                    {
                        Object.keys(activeContact).length > 0 &&
                        <ChatThreadToolbar participant={activeContact}/>
                    }

                    <Box
                        sx={{
                            flexGrow: 1,
                            overflow: 'auto'
                        }}
                    >
                        <Scrollbar
                            options={{suppressScrollX: true}}
                            ref={rootRef}
                        >
                            <Box sx={{p: 2}}>
                                {
                                    messages.length > 0 && messages.map((msg) => (
                                        <Box
                                            sx={{
                                                display: 'flex',
                                                mb: 2
                                            }}
                                        >
                                            <Box
                                                sx={{
                                                    display: 'flex',
                                                    flexDirection: msg.senderId === currentUser.id.toString()
                                                        ? 'row-reverse'
                                                        : 'row',
                                                    maxWidth: 500,
                                                    ml: msg.senderId === currentUser.id.toString() ? 'auto' : 0
                                                }}
                                            >
                                                <Avatar
                                                    src={'avatar'}
                                                    sx={{
                                                        height: 32,
                                                        ml: msg.senderId === currentUser.id.toString() ? 2 : 0,
                                                        mr: msg.senderId === currentUser.id.toString() ? 0 : 2,
                                                        width: 32
                                                    }}
                                                />
                                                <div>
                                                    <Box
                                                        sx={{
                                                            backgroundColor: msg.senderId === currentUser.id.toString()
                                                                ? 'primary.main'
                                                                : 'background.paper',
                                                            borderRadius: 1,
                                                            boxShadow: 1,
                                                            color: msg.senderId === currentUser.id.toString()
                                                                ? 'primary.contrastText'
                                                                : 'text.primary',
                                                            px: 2,
                                                            py: 1
                                                        }}
                                                    >
                                                        <Link
                                                            color="inherit"
                                                            component={RouterLink}
                                                            to="#"
                                                            disabled
                                                            variant="subtitle2"
                                                        >
                                                            {msg.senderId !== currentUser.id.toString() ? msg.senderName : 'Me'}
                                                        </Link>

                                                        <Box sx={{mt: 1}}>
                                                            <Typography
                                                                color="inherit"
                                                                variant="body1"
                                                            >
                                                                {msg.content}
                                                            </Typography>
                                                        </Box>
                                                    </Box>
                                                    <Box
                                                        sx={{
                                                            display: 'flex',
                                                            justifyContent: msg.senderId === currentUser.id.toString()
                                                                ? 'flex-end'
                                                                : 'flex-start',
                                                            mt: 1,
                                                            px: 2
                                                        }}
                                                    >
                                                        <Typography
                                                            color="textSecondary"
                                                            noWrap
                                                            variant="caption"
                                                        >
                                                            {moment(msg.timestamp).fromNow()}
                                                            {' '}
                                                        </Typography>
                                                    </Box>
                                                </div>
                                            </Box>
                                        </Box>
                                    ))}
                            </Box>
                        </Scrollbar>

                    </Box>
                    <Divider/>
                    {
                        Object.keys(activeContact).length !== 0 &&
                        <Box
                            sx={{
                                alignItems: 'center',
                                backgroundColor: 'background.paper',
                                display: 'flex',
                                px: 2,
                                py: 1,
                            }}
                        >
                            <Avatar
                                sx={{
                                    mr: 2
                                }}
                                src={'avatar'}
                            />
                            <TextField
                                fullWidth
                                size="small"
                                variant="outlined"
                                name="user_input"
                                placeholder="Write your message..."
                                value={text}
                                onChange={(event) => setText(event.target.value)}
                                onKeyPress={(event) => {
                                    if (event.key === "Enter") {
                                        sendMessage(text);
                                        setText("");
                                    }
                                }}
                            />
                            <Tooltip title="Send">
        <span>
          <IconButton
              color="primary"
              onClick={() => {
                  sendMessage(text);
                  setText("");
              }}
          >
            <SendIcon fontSize="small"/>
          </IconButton>
        </span>
                            </Tooltip>
                        </Box>
                    }
                </Box>
            </Box>
        </>
    );
};

export default Chat;
/* eslint-disable */