import {useState} from 'react';
import {
    Box,
    Button,
    ButtonBase, Card, CardContent, CardHeader, Divider,
    makeStyles,
    Popover, Table, TableBody, TableCell, TableRow, Typography,
} from '@material-ui/core';
import numeral from "numeral";
import AuthService from "../../services/auth-service";
import BookingService from "../../services/booker-service";
import {useNavigate} from "react-router-dom";

const currency = "$";
const userId = AuthService.getCurrentUser().id;
const useStyles = makeStyles(theme => ({
    popoverRoot: {
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        backdropFilter: "blur(3px)",
        backgroundColor: 'window.default',
    },
}));

const ReservationPopover = (props) => {
    const navigate = useNavigate();

    const {room} = props;
    const {dates} = props;
    const {hotel} = props;

    const [open, setOpen] = useState(false);
    const handleOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleConfirm = () => {
        let newBooking = {
            price: room.total_price,
            userId: userId,
            roomId: room.id,
            checkinString: dates.checkin,
            checkoutString: dates.checkout
        }
        BookingService.saveBooking(newBooking)
            .then(response => {
                navigate('/booker/history/');
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
            >
                <Button
                    color="primary"
                    size="small"
                    variant="outlined"
                >
                    Reserve
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
                            <CardHeader title="Reservation"/>
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
                                                    {dates.checkin} - {dates.checkout} ({room.totalNights} nights)
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
                                                    {hotel.name}
                                                </TableCell>
                                            </TableRow>
                                            <TableRow>
                                                <TableCell>
                                                    <Typography
                                                        color="textPrimary"
                                                        variant="subtitle2"
                                                    >
                                                        Location:
                                                    </Typography>
                                                </TableCell>
                                                <TableCell>
                                                    {hotel.location}
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
                                                    {room.type}
                                                </TableCell>
                                            </TableRow>
                                            <TableRow>
                                                <TableCell>
                                                    <Typography
                                                        color="textPrimary"
                                                        variant="subtitle2"
                                                    >
                                                        Guests:
                                                    </Typography>
                                                </TableCell>
                                                <TableCell>
                                                    {room.sleeps}
                                                </TableCell>
                                            </TableRow>
                                            <TableRow>
                                                <TableCell>
                                                    <Typography
                                                        color="textPrimary"
                                                        variant="subtitle2"
                                                    >
                                                        Total price:
                                                    </Typography>
                                                </TableCell>
                                                <TableCell>
                                                    {numeral(room.total_price)
                                                        .format(`${currency}0,0.00`)}
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

export default ReservationPopover;