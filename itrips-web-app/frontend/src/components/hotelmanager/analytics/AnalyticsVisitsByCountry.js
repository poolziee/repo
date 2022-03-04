import {useState} from 'react';
import numeral from 'numeral';
import {
    Badge,
    Box,
    Card,
    CardHeader,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    TableSortLabel,
    Typography
} from '@material-ui/core';


const AnalyticsVisitsByCountry = (props) => {
    const [order, setOrder] = useState('desc');
    const {data} = props;

    const handleSort = () => {
        setOrder((prevOrder) => {
            if (prevOrder === 'asc') {
                return 'desc';
            }

            return 'asc';
        });
    };

    if (data.info === "All Hotels") {
        return " ";
    }
    return (
        <Card>
            <CardHeader
                disableTypography
                title={(
                    <Box
                        sx={{
                            alignItems: 'center',
                            display: 'flex',
                            justifyContent: 'space-between'
                        }}
                    >
                        <Typography
                            color="textPrimary"
                            variant="h6"
                        >
                            Total room bookings
                        </Typography>
                    </Box>
                )}
            />
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>
                            Room
                        </TableCell>
                        <TableCell sortDirection={order}>
                            <TableSortLabel
                                active
                                direction={order}
                                onClick={handleSort}
                            >
                                Visits
                            </TableSortLabel>
                        </TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {data.series.map((room) => (
                        <TableRow
                            key={room.name}
                            sx={{
                                '&:last-child td': {
                                    border: 0
                                }
                            }}
                        >
                            <TableCell>
                                <Box
                                    sx={{
                                        alignItems: 'center',
                                        display: 'flex'
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
                                                backgroundColor: room.color,
                                                left: 6,
                                                top: 11
                                            }
                                        }}
                                    >
                                        <Typography
                                            color="textPrimary"
                                            sx={{ml: 2}}
                                            variant="subtitle2"
                                        >
                                            {room.name}
                                        </Typography>
                                    </Badge>
                                </Box>
                            </TableCell>
                            <TableCell>
                                {numeral(room.data.reduce((partial_sum, a) => partial_sum + a, 0)).format('0,0')}
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </Card>
    );
};

export default AnalyticsVisitsByCountry;
