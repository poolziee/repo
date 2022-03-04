import {Link as RouterLink} from 'react-router-dom';
import PropTypes from 'prop-types';
import numeral from 'numeral';
import {
    Box,
    Card,
    CardMedia,
    Divider,
    Grid,
    Link,
    Rating,
    Typography
} from '@material-ui/core';
import UsersIcon from '../../icons/Users';
import {useNavigate} from 'react-router-dom';

const currency = '$';
const HotelCard = (props) => {
    const navigate = useNavigate();
    const {offer, ...other} = props;
    let lastIndex = offer.location.lastIndexOf(", ");
    let location = offer.location.substring(0, lastIndex);

    const handleOfferClick = () => {
        navigate('/booker/reservation/hotel', {
            state: {offer}
        });
    }

    return (
        <Card {...other}>
            <Box sx={{p: 3}}>
                <CardMedia
                    image='https://images.unsplash.com/photo-1566073771259-6a8506099945?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG90ZWx8ZW58MHx8MHx8&w=1000&q=80'
                    sx={{
                        backgroundColor: 'background.default',
                        height: 200
                    }}
                />
                <Box
                    sx={{
                        alignItems: 'center',
                        display: 'flex',
                        mt: 2
                    }}
                >
                    <Box sx={{ml: 2}}>
                        <Link
                            color="textPrimary"
                            variant="h6"
                            onClick={handleOfferClick}
                            style={{cursor: 'pointer'}}
                        >
                            {offer.name}
                        </Link>
                        <Typography
                            color="textSecondary"
                            variant="body2"
                        >
                            <Link
                                color="textPrimary"
                                component={RouterLink}
                                to="#"
                                variant="subtitle2"
                                style={{pointerEvents: "none"}}
                            >
                                {location}
                            </Link>
                        </Typography>
                    </Box>
                </Box>
            </Box>
            <Box
                sx={{
                    pb: 2,
                    px: 3
                }}
            >
                <Typography
                    color="textSecondary"
                    variant="body2"
                >
                    {offer.caption}
                </Typography>
            </Box>
            <Box
                sx={{
                    px: 3,
                    py: 2
                }}
            >
                <Grid
                    alignItems="center"
                    container
                    justifyContent="space-between"
                    spacing={3}
                >
                    <Grid item>
                        <Typography
                            color="textPrimary"
                            variant="subtitle2"
                        >
                            {numeral(offer.totalPrice)
                                .format(`${currency}0,0.00`)}
                        </Typography>
                        <Typography
                            color="textSecondary"
                            variant="body2"
                        >
                            Total for {offer.totalNights} nights
                        </Typography>
                        <Typography>
                            ━━━━━━━
                        </Typography>
                        <Typography
                            color="textSecondary"
                            variant="body2"
                        >
                            nightly price per unit: {numeral(offer.nightlyPrice)
                            .format(`${currency}0,0.00`)}
                        </Typography>
                    </Grid>
                    <Grid item>
                        <Typography
                            color="textPrimary"
                            variant="subtitle2"
                        >

                        </Typography>
                        <Typography
                            color="textSecondary"
                            variant="body2"
                        >

                        </Typography>
                    </Grid>
                    <Grid item>
                        <Typography
                            color="textPrimary"
                            variant="subtitle2"
                        >
                            {offer.bookings}
                        </Typography>
                        <Typography
                            color="textSecondary"
                            variant="body2"
                        >
                            Bookings
                        </Typography>
                    </Grid>
                </Grid>
            </Box>
            <Divider/>
            <Box
                sx={{
                    alignItems: 'center',
                    display: 'flex',
                    pl: 2,
                    pr: 3,
                    py: 2
                }}
            >
                <Box
                    sx={{
                        alignItems: 'center',
                        display: 'flex',
                        ml: 2
                    }}
                >
                    <UsersIcon fontSize="small"/>
                    <Typography
                        color="textSecondary"
                        sx={{ml: 1}}
                        variant="subtitle2"
                    >
                        {offer.guests}
                    </Typography>
                </Box>
                <Box sx={{flexGrow: 1}}/>
                <Rating
                    readOnly
                    size="small"
                    value={offer.stars}
                />
            </Box>
        </Card>
    );
};

HotelCard.propTypes = {
    offer: PropTypes.object.isRequired
};

export default HotelCard;
