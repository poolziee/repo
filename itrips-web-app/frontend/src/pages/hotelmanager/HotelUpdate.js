import {useEffect} from 'react';
import {Link as RouterLink} from 'react-router-dom';
import {Box, Breadcrumbs, Button, Container, Grid, Link, Typography} from '@material-ui/core';
import {HotelCreateForm} from '../../components/hotelmanager/hotel';
import ArrowLeftIcon from '../../icons/ArrowLeft';
import ChevronRightIcon from '../../icons/ChevronRight';
import {useLocation} from "react-router";

const HotelUpdate = () => {

    const {state} = useLocation();
    let {hotel} = state;
    
    useEffect(() => {
    }, [hotel]);


    useEffect(() => {
    }, []);

    return (
        <>
            <title>Edit Hotel | iTrips</title>
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
                                Edit hotel
                            </Typography>
                            <Breadcrumbs
                                aria-label="breadcrumb"
                                separator={<ChevronRightIcon fontSize="small"/>}
                                sx={{mt: 1}}
                            >
                                <Link
                                    color="textPrimary"
                                    component={RouterLink}
                                    to="/hotelmanager"
                                    variant="subtitle2"
                                >
                                    Dashboard
                                </Link>
                                <Link
                                    color="textPrimary"
                                    component={RouterLink}
                                    to="/hotelmanager"
                                    variant="subtitle2"
                                >
                                    Management
                                </Link>
                                <Link
                                    color="textPrimary"
                                    variant="subtitle2"
                                    component={RouterLink}
                                    to="/hotelmanager/hotels"
                                >
                                    Hotels
                                </Link>
                                <Typography
                                    color="textSecondary"
                                    variant="subtitle2"
                                >
                                    Edit Hotel
                                </Typography>
                            </Breadcrumbs>
                        </Grid>
                        <Grid item>
                            <Box sx={{m: -1}}>
                                <Button
                                    color="primary"
                                    component={RouterLink}
                                    startIcon={<ArrowLeftIcon fontSize="small"/>}
                                    sx={{mt: 1}}
                                    to="/hotelmanager/hotels"
                                    variant="outlined"
                                >
                                    Cancel
                                </Button>
                            </Box>
                        </Grid>
                    </Grid>
                    <Box sx={{mt: 3}}>
                        <HotelCreateForm/>
                    </Box>
                </Container>
            </Box>
        </>
    );
};

export default HotelUpdate;