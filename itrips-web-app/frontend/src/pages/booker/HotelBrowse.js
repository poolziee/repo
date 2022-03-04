import {useCallback, useState, useEffect} from 'react';
import {Link as RouterLink} from 'react-router-dom';
import {Box, Breadcrumbs, Container, Grid, Link, Typography} from '@material-ui/core';
import {HotelSearchBar, HotelSearchResult} from '../../components/booker';
import useMounted from '../../hooks/useMounted';
import ChevronRightIcon from '../../icons/ChevronRight';
import bookingService from "../../services/booker-service";


const ProjectBrowse = () => {
    const mounted = useMounted();
    const [offers, setOffers] = useState([]);
    const [addresses, setAddresses] = useState([]);

    const getAddresses = useCallback(async () => {
        try {
            const data = await bookingService.getAddresses();
            if (mounted.current) {
                setAddresses(data);
            }
        } catch (err) {
            console.error(err);
        }
    }, [mounted]);


    const getOffers = useCallback(async (location, checkinString, checkoutString, guests) => {
        try {
            const data = await bookingService.getOffers(location, checkinString, checkoutString, guests);
            if (mounted.current) {
                setOffers(data);
            }
        } catch (err) {
            console.error(err);
        }
    }, [mounted]);

    useEffect(() => {
        getAddresses();
    }, [getOffers, getAddresses]);

    const handleQuery = (location, checkinString, checkoutString, guests) => {
        getOffers(location, checkinString, checkoutString, guests);

    };

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
                                Book the best offers
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
                                    Browse
                                </Typography>
                            </Breadcrumbs>
                        </Grid>
                    </Grid>
                    <Box sx={{mt: 3}}>
                        <HotelSearchBar addresses={addresses} parentalCallBack={handleQuery}/>
                    </Box>
                    <Box sx={{mt: 6}}>
                        <HotelSearchResult offers={offers}/>
                    </Box>
                </Container>
            </Box>
        </>
    );
};

export default ProjectBrowse;
