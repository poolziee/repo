import {useEffect} from 'react';
import {Link as RouterLink, useLocation} from 'react-router-dom';
import PropTypes from 'prop-types';
import {Avatar, Box, Divider, Drawer, Typography} from '@material-ui/core';
import useMediaQuery from '@material-ui/core/useMediaQuery';
import Scrollbar from '../Scrollbar';
import SidebarSections from "./SidebarSections";
import NavSection from './NavSection';


const Sidebar = (props) => {
    const {onMobileClose, openMobile} = props;
    const location = useLocation();
    const user = JSON.parse(localStorage.getItem("user"));
    const lgUp = useMediaQuery((theme) => theme.breakpoints.up('lg'));
    let role = "";
    user.roles.forEach(
        r => {
            if (r.name !== "ROLE_USER") {
                role = r.name;
                return "";
            }
        }
    )
    const sections = SidebarSections(role);

    useEffect(() => {
        if (openMobile && onMobileClose) {
            onMobileClose();
        }
        // eslint-disable-next-line
    }, [location.pathname]);

    const content = (
        <Box
            sx={{
                display: 'flex',
                flexDirection: 'column',
                height: '100%'
            }}
        >
            <Scrollbar options={{suppressScrollX: true}}>
                <Box
                    sx={{
                        display: {
                            lg: 'none',
                            xs: 'flex'
                        },
                        justifyContent: 'center',
                        p: 2
                    }}
                >
                </Box>
                <Box sx={{p: 2}}>
                    <Box
                        sx={{
                            alignItems: 'center',
                            backgroundColor: 'background.default',
                            borderRadius: 1,
                            display: 'flex',
                            overflow: 'hidden',
                            p: 2
                        }}
                    >
                        <RouterLink to="/dashboard/account">
                            <Avatar
                                src={user.avatar}
                                sx={{
                                    cursor: 'pointer',
                                    height: 48,
                                    width: 48
                                }}
                            />
                        </RouterLink>
                        <Box sx={{ml: 2}}>
                            <Typography
                                color="textPrimary"
                                variant="subtitle2"
                            >
                                {user.username}
                            </Typography>
                            <Typography
                                color="textSecondary"
                                variant="body2"
                            >
                                {user.roles.filter(r => r.name !== "ROLE_USER")[0].name.substring(5)}
                            </Typography>
                        </Box>
                    </Box>
                </Box>
                <Divider/>
                <Box sx={{p: 2}}>
                    {sections.map((section) => (
                        <NavSection
                            key={section.title}
                            pathname={location.pathname}
                            sx={{
                                '& + &': {
                                    mt: 3
                                }
                            }}
                            {...section}
                        />
                    ))}
                </Box>
                <Divider/>
            </Scrollbar>
        </Box>
    );

    if (lgUp) {
        return (
            <Drawer
                anchor="left"
                open
                PaperProps={{
                    sx: {
                        backgroundColor: 'background.paper',
                        height: 'calc(100% - 64px) !important',
                        top: '64px !Important',
                        width: 280
                    }
                }}
                variant="permanent"
            >
                {content}
            </Drawer>
        );
    }

    return (
        <Drawer
            anchor="left"
            onClose={onMobileClose}
            open={openMobile}
            PaperProps={{
                sx: {
                    backgroundColor: 'background.paper',
                    width: 280
                }
            }}
            variant="temporary"
        >
            {content}
        </Drawer>
    );
};

Sidebar.propTypes = {
    onMobileClose: PropTypes.func,
    openMobile: PropTypes.bool
};

export default Sidebar;