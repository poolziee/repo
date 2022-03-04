import {
    Box,
    Chip,
    Container,
    Typography
} from '@material-ui/core';
import {experimentalStyled} from '@material-ui/core/styles';
import WidgetPreviewer from "../WidgetPreviewer";
import GroupedList11 from "../widgets/grouped-lists/GroupedList11";
import StarRating from "../widgets/StarRating";
import Quill from "react-quill";


const QuillWrapper = experimentalStyled('div')(({theme}) => ({

    '& .ql-editor': {
        color: theme.palette.text.primary,
        fontFamily: theme.typography.body1.fontFamily,
        fontSize: 20,
        padding: theme.spacing(2),
        '&.ql-blank::before': {
            color: theme.palette.text.secondary,
            fontStyle: 'normal',
            left: theme.spacing(2)
        }
    }
}));

const HotelDetails = (props) => {

    const {hotel} = props;
    const dates = {
        checkin: hotel.checkin,
        checkout: hotel.checkout
    }
    return (
        <>
            <title>Hotel Reservation</title>
            <Box
                sx={{
                    backgroundColor: 'background.paper',
                    minHeight: '100%'
                }}
            >
                <Box sx={{py: 3}}>
                    <Container maxWidth="md">
                        <Box
                            sx={{
                                display: 'flex',
                                justifyContent: 'center'
                            }}
                        >
                            <Chip
                                label={hotel.location}
                                variant="outlined"
                            />
                        </Box>
                        <Typography
                            align="center"
                            color="textPrimary"
                            sx={{
                                fontWeight: 'fontWeightBold',
                                mt: 3
                            }}
                            variant="h2"
                        >
                            {hotel.name}
                        </Typography>
                        <Typography
                            align="center"
                            color="textSecondary"
                            sx={{mt: 3}}
                            variant="subtitle1"
                        >
                            {hotel.caption}
                        </Typography>
                        <Box
                            sx={{
                                display: 'flex',
                                justifyContent: 'center',
                                mt: 3
                            }}
                        >
                            <StarRating givenStars={hotel.stars} isStatic={true}/>
                        </Box>
                    </Container>
                </Box>
                <Box sx={{mt: 6}}>
                    <Container maxWidth="lg">
                        <Box
                            sx={{
                                backgroundImage: `url(https://images.unsplash.com/photo-1566073771259-6a8506099945?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG90ZWx8ZW58MHx8MHx8&w=1000&q=80)`,
                                backgroundPosition: 'center',
                                backgroundSize: 'cover',
                                borderRadius: '20px',
                                height: 600
                            }}
                        />
                    </Container>
                </Box>
                <Box sx={{py: 3}}>
                    <Container maxWidth="md">
                        <QuillWrapper>
                            <Quill value={hotel.description}
                                   theme={'bubble'}
                                   toolbar={false}
                                   readOnly={true}
                            />
                        </QuillWrapper>
                    </Container>
                </Box>
                <div>
                    <Container maxWidth="lg">
                        <Box sx={{mt: 3}}>
                            <WidgetPreviewer
                                element={<GroupedList11 hotel={hotel} rooms={hotel.roomOffers}
                                                        dates={dates}/>}
                                name={'Available rooms: ' + hotel.checkin + " - " + hotel.checkout}
                            />
                        </Box>
                    </Container>
                </div>
            </Box>
        </>
    );
};

export default HotelDetails;
