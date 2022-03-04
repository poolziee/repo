import {
    Box, Button,
    Card,
    Table,
    TableBody,
    TableCell,
    TableRow,
    Typography,
} from '@material-ui/core';
import UsersIcon from '../../icons/Users';
import numeral from "numeral";
import TrashIcon from "../../icons/Trash";
import * as React from "react";
import service from "../../services/booker-service"
import wait from "../../utils/wait";
import {message} from "antd";
import {useEffect, useState} from "react";
import CancelBookingPopover from "./CancelBookingPopover";


const currency = "$";
const BookingHistoryList = (props) => {

    const {bookings} = props;

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
                        {bookings.map((booking) => (
                            <TableRow
                                key={booking.id}
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
                                        {booking.hotel.name}
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
                                                {booking.room.sleeps}
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
                                            {booking.room.type}
                                        </Typography>
                                    </Box>
                                </TableCell>
                                <TableCell>
                                    <Typography
                                        color="textPrimary"
                                        variant="subtitle2"
                                    >
                                        {booking.checkin} - {booking.checkout}
                                    </Typography>
                                    <Typography
                                        color="textSecondary"
                                        sx={{mt: 1}}
                                        variant="body2"
                                    >
                                        Dates
                                    </Typography>
                                </TableCell>
                                <TableCell>
                                    <Typography
                                        color="textPrimary"
                                        variant="subtitle2"
                                    >
                                        {numeral(booking.price)
                                            .format(`${currency}0,0.00`)}
                                    </Typography>
                                    <Typography
                                        color="textSecondary"
                                        sx={{mt: 1}}
                                        variant="body2"
                                    >
                                        Total price
                                    </Typography>
                                </TableCell>
                                <TableCell>
                                    {booking.button &&
                                    <CancelBookingPopover booking={booking}/>
                                    }
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </Card>
        </Box>
    );

};

export default BookingHistoryList;
