import {Link as RouterLink} from 'react-router-dom';
import PropTypes from 'prop-types';
import {AppBar, Box, IconButton, Toolbar} from '@material-ui/core';
import {experimentalStyled} from '@material-ui/core/styles';
import MenuIcon from '../../icons/Menu';
import AccountPopover from './popover/AccountPopover';
import ContactsPopover from './popover/ContactsPopover';
import Logo from './Logo';
import NotificationsPopover from './popover/NotificationsPopover';

const NavbarRoot = experimentalStyled(AppBar)(({theme}) => ({
    ...(theme.palette.mode === 'dark' && {
        backgroundColor: theme.palette.background.paper,
        borderBottom: `1px solid ${theme.palette.divider}`,
        boxShadow: 'none'
    }),
    zIndex: theme.zIndex.drawer + 100
}));

const Navbar = (props) => {
    const {onSidebarMobileOpen, ...other} = props;

    return (
        <NavbarRoot {...other}>
            <Toolbar sx={{minHeight: 64}}>
                <IconButton
                    color="inherit"
                    onClick={onSidebarMobileOpen}
                    sx={{
                        display: {
                            lg: 'none'
                        }
                    }}
                >
                    <MenuIcon fontSize="small"/>
                </IconButton>
                <RouterLink to="/">
                    <Logo
                        sx={{
                            display: {
                                lg: 'inline',
                                xs: 'none'
                            },
                            height: 40,
                            width: 40
                        }}
                    />
                </RouterLink>
                <Box
                    sx={{
                        flexGrow: 1,
                        ml: 2
                    }}
                />
                <Box sx={{ml: 1}}>
                    <ContactsPopover/>
                </Box>
                <Box sx={{ml: 1}}>
                    <NotificationsPopover/>
                </Box>
                <Box sx={{ml: 2}}>
                    <AccountPopover/>
                </Box>
            </Toolbar>
        </NavbarRoot>
    );
};

Navbar.propTypes = {
    onSidebarMobileOpen: PropTypes.func
};

export default Navbar;