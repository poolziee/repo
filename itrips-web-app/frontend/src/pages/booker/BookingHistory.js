import {Link as RouterLink} from 'react-router-dom';
import {Box, Breadcrumbs, Container, Grid, Link, Typography} from '@material-ui/core';
import ChevronRightIcon from '../../icons/ChevronRight';
import BookingHistoryList from "../../components/booker/BookingHistoryList";
import useMounted from "../../hooks/useMounted";
import {useCallback, useEffect, useState} from "react";
import bookingService from "../../services/booker-service";


const BookingHistory = () => {

    const mounted = useMounted();
    const [bookings, setBookings] = useState([]);


    const getBookings = useCallback(async () => {
        try {
            const data = await bookingService.getBookings();
            if (mounted.current) {

                for (let i = 0; i < data.length; i++) {
                    let checkinParts = data[i].checkin.split('-');
                    let checkin = new Date(checkinParts[0], checkinParts[1] - 1, checkinParts[2].substr(0, 2));
                    if (checkin > new Date()) {
                        data[i].button = true;
                    }
                }
                setBookings(data);
            }
        } catch (err) {
            console.error(err);
        }
    }, [mounted]);


    useEffect(() => {
        getBookings();
    }, [getBookings]);

    return (
        <>
            <Box
                sx={{
                    backgroundColor: 'background.default',
                    minHeight: '100%',
                    py: 8
                }}
            >
                <Container maxWidth={'xl'}>
                    <Grid
                        alignItems="center"
                        container
                        justifyContent="space-between"
                        spacing={3}
                    >
                        <Grid item>
                            <Typography
                                color="textPrimary"
                                variant="h5"
                            >
                                Booking History
                            </Typography>
                            <Breadcrumbs
                                aria-label="breadcrumb"
                                separator={<ChevronRightIcon fontSize="small"/>}
                                sx={{mt: 1}}
                            >
                                <Link
                                    color="textPrimary"
                                    component={RouterLink}
                                    to="/dashboard"
                                    variant="subtitle2"
                                >
                                    Dashboard
                                </Link>
                                <Link
                                    color="textPrimary"
                                    component={RouterLink}
                                    to="/dashboard/projects"
                                    variant="subtitle2"
                                >
                                    Stays
                                </Link>
                                <Typography
                                    color="textSecondary"
                                    variant="subtitle2"
                                >
                                    History
                                </Typography>
                            </Breadcrumbs>
                        </Grid>
                    </Grid>
                    <Box sx={{mt: 6}}>
                        <BookingHistoryList bookings={bookings}/>
                    </Box>
                </Container>
            </Box>
        </>
    );
};

export default BookingHistory;