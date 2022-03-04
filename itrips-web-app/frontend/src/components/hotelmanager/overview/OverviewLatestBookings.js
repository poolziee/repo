import {format} from 'date-fns';
import numeral from 'numeral';
import {
    Box,
    Card,
    CardHeader,
    Table,
    TableBody,
    TableCell,
    TableRow,
    Typography
} from '@material-ui/core';


const OverviewLatestBookings = (props) => {
    const {data} = props;


    return (
        <>
            <Card>
                <CardHeader title="Latest Bookings"/>
                <Table>
                    <TableBody>
                        {data.map((booking) => (
                            <TableRow
                                key={booking.id}
                                sx={{
                                    '&:last-child td': {
                                        border: 0
                                    }
                                }}
                            >
                                <TableCell width={100}>
                                    <Box sx={{p: 1}}>
                                        <Typography
                                            align="center"
                                            color="textSecondary"
                                            variant="subtitle2"
                                        >

                                            {format(booking.checkin, 'LLL').toUpperCase()}

                                        </Typography>
                                        <Typography
                                            align="center"
                                            color="textSecondary"
                                            variant="h6"
                                        >

                                            {format(booking.checkin, 'd')}

                                        </Typography>
                                    </Box>
                                </TableCell>
                                <TableCell>
                                    <div>
                                        <Typography
                                            color="textPrimary"
                                            variant="subtitle2"
                                        >
                                            {booking.hotel.name + ", " + booking.room.type + " (" + booking.nights + " nights)"}
                                        </Typography>
                                        <Typography
                                            color="textSecondary"
                                            variant="body2"
                                        >
                                            {"Booker: " + booking.user.firstName + " " + booking.user.lastName + " "}
                                        </Typography>
                                    </div>
                                </TableCell>
                                <TableCell align="right">
                                    <Typography
                                        color={'success.main'}
                                        variant="subtitle2"
                                    >
                                        {'+'}
                                        {' '}
                                        {numeral(booking.price).format('$0,0.00')}
                                    </Typography>
                                    <Typography
                                        color="textSecondary"
                                        variant="body2"
                                    >
                                        {'USD'}
                                    </Typography>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </Card>
        </>
    );
}


export default OverviewLatestBookings;
