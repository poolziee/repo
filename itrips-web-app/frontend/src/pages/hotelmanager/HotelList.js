import {useState, useEffect, useCallback} from 'react';
import {Link as RouterLink} from 'react-router-dom';
import {Box, Breadcrumbs, Button, Container, Grid, Link, Typography} from '@material-ui/core';
import {HotelListTable} from '../../components/hotelmanager/hotel';
import useMounted from '../../hooks/useMounted';
import ChevronRightIcon from '../../icons/ChevronRight';
import DownloadIcon from '../../icons/Download';
import UploadIcon from '../../icons/Upload';
import PlusIcon from '../../icons/Plus';
import service from "../../services/hotelmanager-service";

const ProductList = () => {
    const mounted = useMounted();
    const [hotels, setHotels] = useState([]);

    const getHotels = useCallback(async () => {
        try {
            const data = await service.getHotels();

            if (mounted.current) {
                setHotels(data);
            }
        } catch (err) {
            console.error(err);
        }
    }, [mounted]);

    useEffect(() => {
        getHotels();
    }, [getHotels]);
    return (
        <>
            <title>Dashboard| Hotels</title>
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
                                Hotel List
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
                                    to="/dashboard"
                                    variant="subtitle2"
                                >
                                    Management
                                </Link>
                                <Typography
                                    color="textSecondary"
                                    variant="subtitle2"
                                >
                                    Hotels
                                </Typography>
                            </Breadcrumbs>
                            <Box
                                sx={{
                                    mb: -1,
                                    mx: -1,
                                    mt: 1
                                }}
                            >
                                <Button
                                    color="primary"
                                    startIcon={<UploadIcon fontSize="small"/>}
                                    sx={{m: 1}}
                                    variant="text"
                                >
                                    Import
                                </Button>
                                <Button
                                    color="primary"
                                    startIcon={<DownloadIcon fontSize="small"/>}
                                    sx={{m: 1}}
                                    variant="text"
                                >
                                    Export
                                </Button>
                            </Box>
                        </Grid>
                        <Grid item>
                            <Box sx={{m: -1}}>
                                <Button
                                    color="primary"
                                    component={RouterLink}
                                    startIcon={<PlusIcon fontSize="small"/>}
                                    sx={{m: 1}}
                                    to="/hotelmanager/hotels/new"
                                    variant="contained"
                                >
                                    New Hotel
                                </Button>
                            </Box>
                        </Grid>
                    </Grid>
                    <Box sx={{mt: 3}}>
                        <HotelListTable hotels={hotels}/>
                    </Box>
                </Container>
            </Box>
        </>
    );
};

export default ProductList;
