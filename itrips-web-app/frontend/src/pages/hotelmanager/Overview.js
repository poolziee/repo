import {useState, useCallback, useEffect} from 'react';
import {
    Box, CircularProgress,
    Container,
    Grid, LinearProgress,
    Typography
} from '@material-ui/core';
import {
    OverviewLatestBookings,
    OverviewMonthlyEarnings,
    OverviewWeeklyEarnings, OverviewTotalRevenue
} from '../../components/hotelmanager/overview';

import AuthService from '../../services/auth-service';
import OverviewBookingsRevenue from "../../components/hotelmanager/overview/OverviewBookingsRevenue";
import service from "../../services/hotelmanager-service";
import useMounted from "../../hooks/useMounted";

/* eslint-disable */
const Overview = () => {

    const mounted = useMounted();
    const [overviewData, setOverviewData] = useState([]);
    const [loading, setLoading] = useState(true);
    const colors = ["#e60049", "#0bb4ff", "#50e991", "#e6d800", "#9b19f5", "#ffa300", "#dc0ab4", "#b3d4ff", "#00bfa0"];

    const getOverviewData = useCallback(async () => {
        try {
            // set loading to true before calling API
            setLoading(true);
            const data = await service.getOverviewData();
            if (mounted.current) {
                for (let i = 0; i < data.entitiesTotalSums.entities.length; i++) {
                    data.entitiesTotalSums.entities[i].color = colors[i];
                    data.yearlySumsData.series[i].color = colors[i];
                }
                for (let i = 0; i < data.latestBookings.length; i++) {
                    let checkinParts = data.latestBookings[i].checkin.split('-');
                    let checkoutParts = data.latestBookings[i].checkout.split('-');

                    data.latestBookings[i].checkin = new Date(checkinParts[0], checkinParts[1] - 1, checkinParts[2].substr(0, 2));
                    data.latestBookings[i].checkout = new Date(checkoutParts[0], checkoutParts[1] - 1, checkoutParts[2].substr(0, 2));
                    var timeDif = data.latestBookings[i].checkout.getTime() - data.latestBookings[i].checkin.getTime();
                    var dayDif = timeDif / (1000 * 3600 * 24);
                    data.latestBookings[i].nights = dayDif;
                }
                setOverviewData(data);
                // switch loading to false after fetch is complete
                setLoading(false);
                console.log(data);
            }
        } catch (err) {
            console.error(err);
        }
    }, [mounted]);

    useEffect(() => {
        getOverviewData();
    }, [getOverviewData]);

    // return a Spinner when loading is true
    if (loading) return (
        <>
            <LinearProgress/>
            <Box sx={{width: '100%', justifyContent: 'center', alignItems: 'center', display: 'flex', height: '100vh'}}>
                <CircularProgress size={300}/>
            </Box>
        </>
    );

    // data will be null when fetch call fails
    if (!overviewData) return (
        <span>Data not available</span>
    );

    // when data is available, title is shown
    return (
        <>
            <title>Dashboard: Overview | Material Kit Pro</title>
            <Box
                sx={{
                    backgroundColor: 'background.default',
                    minHeight: '100%',
                    py: 8
                }}
            >
                <Container maxWidth={'xl'}>
                    <Grid
                        container
                        spacing={3}
                    >
                        <Grid
                            alignItems="center"
                            container
                            justifyContent="space-between"
                            spacing={3}
                            item
                            xs={12}
                        >
                            <Grid item>
                                <Typography
                                    color="textSecondary"
                                    variant="overline"
                                >
                                    Overview
                                </Typography>
                                <Typography
                                    color="textPrimary"
                                    variant="h5"
                                >
                                    Good Morning, {AuthService.getCurrentUser().firstName}
                                </Typography>
                                <Typography
                                    color="textSecondary"
                                    variant="subtitle2"
                                >
                                    Here&apos;s what&apos;s happening with your hotels
                                </Typography>
                            </Grid>

                        </Grid>
                        <Grid
                            item
                            md={6}
                            xs={12}
                        >
                            <OverviewWeeklyEarnings earnings={overviewData.weeklyRevenue}/>
                        </Grid>
                        <Grid
                            item
                            md={6}
                            xs={12}
                        >
                            <OverviewMonthlyEarnings earnings={overviewData.monthlyRevenue}/>
                        </Grid>
                        <Grid
                            item
                            md={8}
                            xs={12}
                        >
                            <OverviewBookingsRevenue data={overviewData.yearlySumsData}/>
                        </Grid>
                        <Grid
                            item
                            md={4}
                            xs={12}
                        >
                            <OverviewTotalRevenue data={overviewData.entitiesTotalSums}/>
                        </Grid>
                        <Grid
                            item
                            md={8}
                            xs={12}
                        >
                            <OverviewLatestBookings data={overviewData.latestBookings}/>
                        </Grid>
                    </Grid>
                </Container>
            </Box>
        </>
    );
};
/* eslint-disable */
export default Overview;
