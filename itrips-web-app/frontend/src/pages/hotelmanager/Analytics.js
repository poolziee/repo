import {useCallback, useEffect, useState,} from 'react';
import {Link as RouterLink} from 'react-router-dom';
import {
    Box,
    Breadcrumbs,
    Button,
    CircularProgress,
    Container,
    Grid,
    LinearProgress,
    Link,
    Typography
} from '@material-ui/core';
import {
    AnalyticsGeneralOverview,
    AnalyticsVisitsByCountry,
    AnalyticsBookings
} from '../../components/hotelmanager/analytics';
import ChevronDownIcon from '../../icons/ChevronDown';
import ChevronRightIcon from '../../icons/ChevronRight';
import DownloadIcon from '../../icons/Download';
import useMounted from "../../hooks/useMounted";
import service from "../../services/hotelmanager-service";

/* eslint-disable */
const Analytics = () => {

    const mounted = useMounted();
    const [overviewData, setOverviewData] = useState([]);
    const [loading, setLoading] = useState(true);
    const roomColors = ["#fd7f6f", "#7eb0d5", "#b2e061", "#bd7ebe", "#ffb55a", "#ffee65", "#beb9db", "#fdcce5", "#8bd3c7"];
    const hotelColors = ["#b30000", "#7c1158", "#4421af", "#1a53ff", "#0d88e6", "#00b7c7", "#5ad45a", "#8be04e", "#ebdc78"];

    const [yearlyData, setYearlyData] = useState({});

    const updateChart = (async (hotelName) => {


        const data = await service.getHotelYearlyAnalyticsData(hotelName);
        if (mounted.current) {
            let info = "All Hotels";
            if (hotelName !== " ") {
                info = hotelName;
                let count = 0;
                data.series.map((room) => {
                    room.color = roomColors[count];
                    count++;
                })
            } else {
                let count = 0;
                data.series.map((hotel) => {
                    hotel.color = hotelColors[count];
                    count++;
                })
            }

            overviewData.yearlySumsData = data;
            overviewData.yearlySumsData.info = info;
            setYearlyData(data);
        }

    })


    const getOverviewData = useCallback(async () => {
        try {
            // set loading to true before calling API
            setLoading(true);
            const data = await service.getAnalyticsData();
            if (mounted.current) {
                for (let i = 0; i < data.entitiesTotalSums.entities.length; i++) {
                    data.entitiesTotalSums.entities[i].color = hotelColors[i];
                    data.yearlySumsData.series[i].color = hotelColors[i];
                    data.entitiesTotalSums.entities[i].data = data.yearlySumsData.series[i].data;
                }
                data.yearlySumsData.info = "All Hotels"
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
            <title>Dashboard: Analytics</title>
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
                        justifyContent="space-between"
                        spacing={3}
                    >
                        <Grid item>
                            <Typography
                                color="textPrimary"
                                variant="h5"
                            >
                                Analytics
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
                                <Typography
                                    color="textSecondary"
                                    variant="subtitle2"
                                >
                                    Analytics
                                </Typography>
                            </Breadcrumbs>
                        </Grid>
                        <Grid item>
                            <Button
                                endIcon={<DownloadIcon fontSize="small"/>}
                                variant="outlined"
                            >
                                Export
                            </Button>
                            <Button
                                color="primary"
                                endIcon={<ChevronDownIcon fontSize="small"/>}
                                sx={{ml: 2}}
                                variant="contained"
                            >
                                Last month
                            </Button>
                        </Grid>
                    </Grid>
                    <Box sx={{py: 3}}>
                        <AnalyticsGeneralOverview parentalCallBack={updateChart}
                                                  data={overviewData.entitiesTotalSums} loading={loading}/>
                    </Box>
                    <Grid
                        container
                        spacing={3}
                    >
                        <Grid
                            item
                            xl={9}
                            md={8}
                            xs={12}
                        >
                            <AnalyticsBookings data={overviewData.yearlySumsData}/>
                        </Grid>
                        <Grid
                            item
                            xl={3}
                            md={4}
                            xs={12}
                        >
                            <AnalyticsVisitsByCountry data={overviewData.yearlySumsData}/>
                        </Grid>
                    </Grid>
                </Container>
            </Box>
        </>
    );
};
/* eslint-disable */
export default Analytics;
