import {
    Box,
    Card,
    Table,
    TableBody,
    TableCell,
    TableRow,
    Typography,
} from '@material-ui/core';
import Label from '../../Label';
import UsersIcon from '../../../icons/Users';
import ReservationPopover from "../../booker/ReservationPopover";
import numeral from "numeral";

const currency = "$";

const labelColorsMap = {
    red: 'secondary',
    green: 'success',
    yellow: 'error'
};

function getWord(status) {
    if (status === "green") {
        return "";
    } else {
        return "only";
    }
}

const GroupedList11 = (props) => {

    const {rooms} = props;
    const {dates} = props;
    const {hotel} = props;


    return (
        <Box
            sx={{
                backgroundColor: 'background.default',
                minHeight: '100%',
                p: 3
            }}
        >
            <Card>
                <Table>
                    <TableBody>
                        {rooms.map((room) => (
                            <TableRow
                                key={room.id}
                                sx={{
                                    '&:last-child td': {
                                        border: 0
                                    }
                                }}
                            >
                                <TableCell>
                                    <Typography
                                        color="textPrimary"
                                        sx={{cursor: 'pointer'}}
                                        variant="subtitle2"
                                    >
                                        {room.type}
                                    </Typography>
                                    <Box
                                        sx={{
                                            alignItems: 'center',
                                            display: 'flex',
                                            mt: 1
                                        }}
                                    >
                                        <Box
                                            sx={{
                                                alignItems: 'center',
                                                display: 'flex',
                                            }}
                                        >
                                            <UsersIcon fontSize="small"/>
                                            <Typography
                                                color="textPrimary"
                                                sx={{ml: 1}}
                                                variant="subtitle2"
                                            >
                                                {room.sleeps}
                                            </Typography>
                                        </Box>
                                        <Box
                                            sx={{
                                                height: 4,
                                                width: 4,
                                                borderRadius: 4,
                                                backgroundColor: 'text.secondary',
                                                mx: 1
                                            }}
                                        />
                                        <Typography
                                            color="textSecondary"
                                            variant="body2"
                                        >
                                            Booked {room.bookings} times
                                        </Typography>
                                    </Box>
                                </TableCell>
                                <TableCell>
                                    <Label color={labelColorsMap[room.status]}>
                                        {getWord(room.status)} {room.offers_left} left
                                    </Label>
                                </TableCell>
                                <TableCell>
                                    <Typography
                                        color="textPrimary"
                                        variant="subtitle2"
                                    >
                                        {numeral(room.nightly_price)
                                            .format(`${currency}0,0.00`)}
                                    </Typography>
                                    <Typography
                                        color="textSecondary"
                                        sx={{mt: 1}}
                                        variant="body2"
                                    >
                                        Price per night
                                    </Typography>
                                </TableCell>
                                <TableCell>
                                    <Typography
                                        color="textPrimary"
                                        variant="subtitle2"
                                    >
                                        {numeral(room.total_price)
                                            .format(`${currency}0,0.00`)}
                                    </Typography>
                                    <Typography
                                        color="textSecondary"
                                        sx={{mt: 1}}
                                        variant="body2"
                                    >
                                        Total price ({room.totalNights} nights)
                                    </Typography>
                                </TableCell>
                                <TableCell align="right">
                                    <ReservationPopover room={room} dates={dates} hotel={hotel}/>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </Card>
        </Box>
    );
}

export default GroupedList11;
