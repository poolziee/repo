import numeral from 'numeral';
import {
    Badge,
    Box,
    Card,
    CardContent,
    CardHeader,
    Divider,
    List,
    ListItem,
    ListItemText,
    Typography
} from '@material-ui/core';


const OverviewTotalRevenue = (props) => (
    <Card {...props}>
        <CardHeader
            subheader={(
                <Typography
                    color="textPrimary"
                    variant="h4"
                >
                    {numeral(props.data.totalSum).format('$0,0.00')}
                </Typography>
            )}
            sx={{pb: 0}}
            title={(
                <Typography
                    color="textSecondary"
                    variant="overline"
                >
                    Total revenue
                </Typography>
            )}
        />
        <CardContent>
            <Divider sx={{mb: 2}}/>
            <Typography
                color="textSecondary"
                variant="overline"
            >
                Hotels Revenue
            </Typography>
            <List
                disablePadding
                sx={{pt: 2}}
            >
                {props.data.entities.map((hotel) => (
                    <ListItem
                        disableGutters
                        key={hotel.name}
                        sx={{
                            pb: 2,
                            pt: 0
                        }}
                    >
                        <ListItemText
                            disableTypography
                            primary={(
                                <Box
                                    sx={{
                                        display: 'flex',
                                        justifyContent: 'space-between'
                                    }}
                                >
                                    <Badge
                                        anchorOrigin={{
                                            vertical: 'top',
                                            horizontal: 'left'
                                        }}
                                        variant="dot"
                                        sx={{
                                            pl: '20px',
                                            '& .MuiBadge-badge': {
                                                backgroundColor: hotel.color,
                                                left: 6,
                                                top: 11
                                            }
                                        }}
                                    >
                                        <Typography
                                            color="textPrimary"
                                            variant="subtitle2"
                                        >
                                            {hotel.name}
                                        </Typography>
                                    </Badge>
                                    <Typography
                                        color="textSecondary"
                                        variant="subtitle2"
                                    >
                                        {numeral(hotel.sum)
                                            .format('$0,0.00')}
                                    </Typography>
                                </Box>
                            )}
                        />
                    </ListItem>
                ))}
            </List>
        </CardContent>
    </Card>
);

export default OverviewTotalRevenue;
