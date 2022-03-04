import {
    Box,
    Card,
    CardHeader,
    Divider,
    Table,
    TableBody,
    TableCell,
    TableRow,
    Typography
} from '@material-ui/core';
import StarRating from "../StarRating";
import {useNavigate} from 'react-router-dom'

const DetailsList5 = (data) => {

    const navigate = useNavigate();
    let hotel = data.hotel;

    const handleEditRoom = (selectedRoom) => {
        navigate('/hotelmanager/hotel/' + hotel.id + '/room/' + selectedRoom.id + '/edit', {
            state: {selectedRoom, hotel}
        })
    };

    return (
        <Box
            sx={{
                backgroundColor: 'background.default',
                minHeight: '100%',
                maxWidth: 'auto',
                p: 3,
                textAlign: 'center',
            }}
        >
            <Card>
                <CardHeader style={{marginRight: 50}} title="Hotel info"/>
                <Divider/>
                <Table>
                    <TableBody>
                        <TableRow>
                            <TableCell style={{textAlign: 'center'}}>
                                <Typography
                                    color="textPrimary"
                                    variant="subtitle2"
                                    marginLeft={20}
                                    maxWidth='auto'
                                >
                                    ID
                                </Typography>
                            </TableCell>
                            <TableCell>
                                #
                                {hotel.id}
                            </TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell style={{textAlign: 'center'}}>
                                <Typography
                                    color="textPrimary"
                                    variant="subtitle2"
                                    marginLeft={20}

                                >
                                    Name
                                </Typography>
                            </TableCell>
                            <TableCell>
                                {hotel.name}
                            </TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell style={{textAlign: 'center'}}>
                                <Typography
                                    color="textPrimary"
                                    variant="subtitle2"
                                    marginLeft={20}

                                >
                                    Stars
                                </Typography>
                            </TableCell>
                            <TableCell>
                                <div style={{
                                    float: 'left',
                                    marginRight: 50
                                }}>
                                    <StarRating givenStars={hotel.stars} isStatic={true}/>
                                </div>
                            </TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell style={{textAlign: 'center'}}>
                                <Typography
                                    color="textPrimary"
                                    variant="subtitle2"
                                    marginLeft={20}
                                >
                                    Rooms
                                </Typography>
                            </TableCell>
                            <TableCell>
                                {hotel.rooms.map(r => (

                                    <div style={{cursor: "pointer"}} key={r.id} data-tag={r} onClick={() => {
                                        handleEditRoom(r)
                                    }}>
                                        {r.type} - {r.sleeps}
                                    </div>
                                ))}
                            </TableCell>
                        </TableRow>
                    </TableBody>
                </Table>
            </Card>
        </Box>
    );
};

export default DetailsList5;
