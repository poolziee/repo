import {Link as RouterLink} from 'react-router-dom';
import {Box, Breadcrumbs, Container, Grid, Link, Typography} from '@material-ui/core';
import ChevronRightIcon from '../../icons/ChevronRight';
import HotelDetails from "../../components/booker/HotelDetails";
import {useLocation} from "react-router";
import {useEffect} from "react";


const ProjectBrowse = () => {

    const {state} = useLocation();
    let {offer} = state;


    useEffect(() => {
    }, [offer]);

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
                                Make a reservation
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
                                    Reservation
                                </Typography>
                            </Breadcrumbs>
                        </Grid>
                    </Grid>
                    <Box sx={{mt: 6}}>
                        <HotelDetails hotel={offer}/>
                    </Box>
                </Container>
            </Box>
        </>
    );
};

export default ProjectBrowse;