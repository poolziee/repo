import PropTypes from 'prop-types';
import {
    Avatar,
    Box,
    IconButton,
    ListItemIcon,
    ListItemText,
    Menu,
    MenuItem,
    Tooltip,
    Typography
} from '@material-ui/core';
import {experimentalStyled} from '@material-ui/core/styles';
import ArchiveIcon from '../../icons/Archive';
import BellIcon from '../../icons/Bell';
import BanIcon from '../../icons/Ban';
import CameraIcon from '../../icons/Camera';
import PhoneIcon from '../../icons/Phone';
import DotsHorizontalIcon from '../../icons/DotsHorizontal';
import TrashIcon from '../../icons/Trash';

const ParticipantAvatar = experimentalStyled(Avatar)(({styleProps}) => {
    if (styleProps.small) {
        return {
            height: 30,
            width: 30,
            '&:nth-of-type(2)': {
                mt: '10px'
            }
        };
    }

    return {};
});

const ChatThreadToolbar = (props) => {
    const {participant} = props;

    return (
        <Box
            sx={{
                alignItems: 'center',
                backgroundColor: 'background.paper',
                borderBottom: (theme) => `1px solid ${theme.palette.divider}`,
                display: 'flex',
                flexShrink: 0,
                minHeight: 64,
                px: 2,
                py: 1
            }}
        >
            <Box
                sx={{
                    alignItems: 'center',
                    display: 'flex',
                    '& .MuiAvatar-root': {
                        mt: '10px'
                    }
                }}
            >
                <ParticipantAvatar
                    key={participant.id}
                    src={'avatar'}
                    styleProps={{small: false}}
                />
                <Typography
                    color="textPrimary"
                    sx={{ml: 2}}
                    variant="subtitle2"
                >
                    {participant.firstName + " " + participant.lastName}
                </Typography>
            </Box>
            <Box sx={{flexGrow: 1}}/>
            <IconButton>
                <PhoneIcon fontSize="small"/>
            </IconButton>
            <IconButton>
                <CameraIcon fontSize="small"/>
            </IconButton>
            <Tooltip title="More options">
                <IconButton
                >
                    <DotsHorizontalIcon fontSize="small"/>
                </IconButton>
            </Tooltip>
            <Menu
                keepMounted
                elevation={1}
            >
                <MenuItem>
                    <ListItemIcon>
                        <BanIcon fontSize="small"/>
                    </ListItemIcon>
                    <ListItemText primary="Block contact"/>
                </MenuItem>
                <MenuItem>
                    <ListItemIcon>
                        <TrashIcon fontSize="small"/>
                    </ListItemIcon>
                    <ListItemText primary="Delete thread"/>
                </MenuItem>
                <MenuItem>
                    <ListItemIcon>
                        <ArchiveIcon fontSize="small"/>
                    </ListItemIcon>
                    <ListItemText primary="Archive thread"/>
                </MenuItem>
                <MenuItem>
                    <ListItemIcon>
                        <BellIcon fontSize="small"/>
                    </ListItemIcon>
                    <ListItemText primary="Mute notifications"/>
                </MenuItem>
            </Menu>
        </Box>
    );
};

ChatThreadToolbar.propTypes = {
    participants: PropTypes.array
};

ChatThreadToolbar.defaultProps = {
    participants: []
};

export default ChatThreadToolbar;
