import {useEffect} from 'react';
import {Link as RouterLink} from 'react-router-dom';
import {Box, Breadcrumbs, Button, Container, Grid, Link, Typography} from '@material-ui/core';
import {RoomCreateForm} from '../../components/hotelmanager/room';
import ChevronRightIcon from '../../icons/ChevronRight';
import ArrowRightIcon from "../../icons/ArrowRight";
import {useLocation} from "react-router";


const RoomUpdate = () => {

    const {state} = useLocation();
    let {hotel} = state;
    let {selectedRoom} = state;

    useEffect(() => {
    }, [hotel, selectedRoom]);

    return (
        <>
            <title>Hotel Update | iTrips</title>
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
                                    component={RouterLink}
                                    to="/hotelmanager/hotels"
                                    variant="subtitle2"
                                >
                                    Hotel #{hotel.id}
                                </Link>
                                <Typography
                                    color="textSecondary"
                                    variant="subtitle2"
                                >
                                    Rooms
                                </Typography>
                            </Breadcrumbs>
                        </Grid>
                        <Grid item>
                            <Box sx={{m: -1}}>
                                <Button
                                    color="primary"
                                    type="submit"
                                    variant="contained"
                                    endIcon={<ArrowRightIcon/>}
                                >
                                    Save and Return
                                </Button>
                            </Box>
                        </Grid>
                    </Grid>
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
                                Update Room
                            </Typography>
                        </Grid>
                    </Grid>
                    <Box sx={{mt: 3}}>
                        <RoomCreateForm/>
                    </Box>
                </Container>
            </Box>
        </>
    );
};

export default RoomUpdate;