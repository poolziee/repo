import {useState} from 'react';
import {
    Box,
    Button,
    ButtonBase, Card, CardContent, CardHeader, Divider,
    makeStyles,
    Popover, Table, TableBody, TableCell, TableRow, Typography,
} from '@material-ui/core';
import BookingService from "../../services/booker-service";
import {useNavigate} from "react-router-dom";
import {message} from 'antd';
import TrashIcon from '../../icons/Trash';
import service from "../../services/booker-service";

const useStyles = makeStyles(theme => ({
    popoverRoot: {
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        backdropFilter: "blur(3px)",
        backgroundColor: 'window.default',
    },
}));

const CancelBookingPopover = (props) => {
    const navigate = useNavigate();
    const {booking} = props;

    const [open, setOpen] = useState(false);
    const handleOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleConfirm = () => {

        BookingService.deleteBooking(booking.id)
            .then(response => {
                window.location.reload(false);
            })
    }

    const classes = useStyles();

    return (
        <>
            <Box
                component={ButtonBase}
                onClick={handleOpen}
                sx={{
                    alignItems: 'center',
                    display: 'flex',
                }}
                size="small"
                startIcon={<TrashIcon/>}
                variant="contained"
            >
                <Button
                    sx={{
                        backgroundColor: 'error.main',
                        '&:hover': {
                            backgroundColor: 'error.dark'
                        }
                    }}
                    size="small"
                    startIcon={<TrashIcon/>}
                    variant="contained"

                >
                    Cancel
                </Button>
            </Box>
            <Popover
                keepMounted
                onClose={handleClose}
                open={open}
                anchorReference={"none"}
                classes={{
                    root: classes.popoverRoot,
                }}
            >
                <div
                    style={{
                        minWidth: '700px',
                    }}
                >
                    <Box
                        sx={{
                            backgroundColor: 'background.default',
                            minHeight: '100%',
                            p: 3
                        }}
                    >
                        <Card>
                            <CardHeader title="Cancel the booking:"/>
                            <Divider/>
                            <CardContent>
                                <Box sx={{mt: 2}}>
                                    <Table>
                                        <TableBody>
                                            <TableRow>
                                                <TableCell>
                                                    <Typography
                                                        color="textPrimary"
                                                        variant="subtitle2"
                                                    >
                                                        Dates:
                                                    </Typography>
                                                </TableCell>
                                                <TableCell>
                                                    {booking.checkin} - {booking.checkout}
                                                </TableCell>
                                            </TableRow>
                                            <TableRow>
                                                <TableCell>
                                                    <Typography
                                                        color="textPrimary"
                                                        variant="subtitle2"
                                                    >
                                                        Hotel:
                                                    </Typography>
                                                </TableCell>
                                                <TableCell>
                                                    {booking.hotel.name}
                                                </TableCell>
                                            </TableRow>
                                            <TableRow>
                                                <TableCell>
                                                    <Typography
                                                        color="textPrimary"
                                                        variant="subtitle2"
                                                    >
                                                        Room:
                                                    </Typography>
                                                </TableCell>
                                                <TableCell>
                                                    {booking.room.type}
                                                </TableCell>
                                            </TableRow>
                                        </TableBody>
                                    </Table>
                                </Box>
                                <Box sx={{mt: 2}}>
                                    <Button
                                        color="primary"
                                        variant="contained"
                                        onClick={handleConfirm}
                                    >
                                        Confirm
                                    </Button>
                                </Box>
                            </CardContent>
                        </Card>
                    </Box>
                </div>
            </Popover>
        </>
    );
};

export default CancelBookingPopover;