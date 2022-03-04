import {useState} from 'react';
import {Link as RouterLink, useNavigate} from 'react-router-dom';
import PropTypes from 'prop-types';

import {
    Box,
    Card,
    IconButton,
    InputAdornment,
    Link,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TablePagination,
    TableRow,
    TextField
} from '@material-ui/core';
import ImageIcon from '../../../icons/Image';
import PencilAltIcon from '../../../icons/PencilAlt';
import SearchIcon from '../../../icons/Search';
import Scrollbar from '../../Scrollbar';
import StarRating from "../../widgets/StarRating";

const sortOptions = [
    {
        label: 'Bookings (highest first)',
        value: 'updatedAt|desc'
    },
    {
        label: 'Bookings (lowest first)',
        value: 'updatedAt|asc'
    },
    {
        label: 'Creation date (newest first)',
        value: 'createdAt|desc'
    },
    {
        label: 'Creation date (oldest first)',
        value: 'createdAt|asc'
    }
];

const applyFilters = (hotels, query) => hotels
    .filter((hotel) => {
        let matches = true;

        if (query && !hotel.name.toLowerCase().includes(query.toLowerCase())) {
            matches = false;
        }
        return matches;
    });

const applyPagination = (hotels, page, limit) => hotels
    .slice(page * limit, page * limit + limit);

const HotelListTable = (props) => {
    const navigate = useNavigate();
    const {hotels, ...other} = props;
    const [page, setPage] = useState(0);
    const [limit, setLimit] = useState(10);
    const [query, setQuery] = useState('');
    const [sort, setSort] = useState(sortOptions[0].value);

    const handleQueryChange = (event) => {
        setQuery(event.target.value);
    };


    const handleSortChange = (event) => {
        setSort(event.target.value);
    };


    const handlePageChange = (event, newPage) => {
        setPage(newPage);
    };

    const handleLimitChange = (event) => {
        setLimit(parseInt(event.target.value, 10));
    };

    const handleEditHotel = (hotel) => {
        navigate('/hotelmanager/hotels/' + hotel.id + '/edit', {
            state: {hotel}
        })
    };

    // Usually query is done on backend with indexing solutions
    const filteredHotels = applyFilters(hotels, query);
    const paginatedHotels = applyPagination(filteredHotels, page, limit);

    return (
        <Card {...other}>
            <Box
                sx={{
                    alignItems: 'center',
                    display: 'flex',
                    flexWrap: 'wrap',
                    m: -1,
                    p: 2
                }}
            >
                <Box
                    sx={{
                        m: 1,
                        maxWidth: '100%',
                        width: 500
                    }}
                >
                    <TextField
                        fullWidth
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <SearchIcon fontSize="small"/>
                                </InputAdornment>
                            )
                        }}
                        onChange={handleQueryChange}
                        placeholder="Search hotels"
                        value={query}
                        variant="outlined"
                    />
                </Box>
                <Box
                    sx={{
                        m: 1,
                        maxWidth: '100%',
                        width: 240
                    }}
                >
                    <TextField
                        label="Sort By"
                        name="sort"
                        onChange={handleSortChange}
                        select
                        SelectProps={{native: true}}
                        value={sort}
                        variant="outlined"
                    >
                        {sortOptions.map((option) => (
                            <option
                                key={option.value}
                                value={option.value}
                            >
                                {option.label}
                            </option>
                        ))}
                    </TextField>
                </Box>
                <Box
                    sx={{
                        m: 1,
                        maxWidth: '100%',
                        width: 240
                    }}
                >
                </Box>
            </Box>
            <Scrollbar>
                <Box sx={{minWidth: 1200}}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>
                                    Name
                                </TableCell>
                                <TableCell>
                                    Location
                                </TableCell>
                                <div style={{paddingLeft: 105}}>
                                    <TableCell>
                                        Stars
                                    </TableCell>
                                </div>
                                <TableCell>
                                    Total Bookings
                                </TableCell>
                                <TableCell align="right">
                                    Actions
                                </TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {paginatedHotels.map((hotel) => {

                                return (
                                    <TableRow
                                        hover
                                        key={hotel.id}
                                    >
                                        <TableCell>
                                            <Box
                                                sx={{
                                                    alignItems: 'center',
                                                    display: 'flex'
                                                }}
                                            >
                                                {hotel.image
                                                    ? (
                                                        <Box
                                                            sx={{
                                                                alignItems: 'center',
                                                                backgroundColor: 'background.default',
                                                                display: 'flex',
                                                                height: 100,
                                                                justifyContent: 'center',
                                                                overflow: 'hidden',
                                                                width: 100,
                                                                '& img': {
                                                                    height: 'auto',
                                                                    width: '100%'
                                                                }
                                                            }}
                                                        >
                                                            <img
                                                                alt="hotel"
                                                                src={hotel.image}
                                                            />
                                                        </Box>
                                                    )
                                                    : (
                                                        <Box
                                                            sx={{
                                                                alignItems: 'center',
                                                                backgroundColor: 'background.default',
                                                                display: 'flex',
                                                                height: 100,
                                                                justifyContent: 'center',
                                                                width: 100
                                                            }}
                                                        >
                                                            <ImageIcon fontSize="small"/>
                                                        </Box>
                                                    )}
                                                <Link
                                                    color="textPrimary"
                                                    component={RouterLink}
                                                    to="#"
                                                    underline="none"
                                                    sx={{ml: 2}}
                                                    variant="subtitle2"
                                                >
                                                    {hotel.name}
                                                </Link>
                                            </Box>
                                        </TableCell>
                                        <TableCell>
                                            {hotel.country + ', ' + hotel.city}
                                        </TableCell>
                                        <TableCell>
                                            {<StarRating givenStars={hotel.stars} isStatic={true}/>}
                                        </TableCell>
                                        <TableCell>
                                            {hotel.total_bookings}
                                        </TableCell>
                                        <TableCell align="right">
                                            <div data-tag={hotel} onClick={() => {
                                                handleEditHotel(hotel)
                                            }}>
                                                <IconButton fontSize="small">
                                                    <PencilAltIcon/>
                                                </IconButton>
                                            </div>
                                        </TableCell>
                                    </TableRow>
                                );
                            })}
                        </TableBody>
                    </Table>
                    <TablePagination
                        component="div"
                        count={filteredHotels.length}
                        onPageChange={handlePageChange}
                        onRowsPerPageChange={handleLimitChange}
                        page={page}
                        rowsPerPage={limit}
                        rowsPerPageOptions={[5, 10, 25]}
                    />
                </Box>
            </Scrollbar>
        </Card>
    );
};

HotelListTable.propTypes = {
    hotels: PropTypes.array.isRequired
};

export default HotelListTable;
