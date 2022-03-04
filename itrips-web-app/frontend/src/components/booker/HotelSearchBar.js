// noinspection DuplicatedCode
import BedIcon from '@material-ui/icons/Bed';
import {useState} from 'react';
import * as React from 'react'

import {
    Autocomplete,
    Box, Button,
    Card, Grid,
    InputAdornment, InputLabel, MenuItem, Select,
    TextField
} from '@material-ui/core';
import SearchIcon from '../../icons/Search';
import {Link as RouterLink} from "react-router-dom";
import {DateRangePicker} from "@material-ui/lab";
import {format} from "date-fns";


const HotelSearchBar = (props) => {
    const [open, setOpen] = useState(false);
    const [inputValue, setInputValue] = useState("");

    const {addresses} = props;
    const {parentalCallBack} = props;
    const [location, setLocation] = useState('');
    const [value, setValue] = useState([null, null]);
    const [guests, setGuests] = useState(2);


    const handleSearch = () => {
        let checkinString = format(value[0], 'MM/dd/yyyy');
        let checkoutString = format(value[1], 'MM/dd/yyyy')
        parentalCallBack(location, checkinString, checkoutString, guests);
    }
    const handleGuests = (event) => {
        setGuests(event.target.value);
    };

    return (
        <Card>
            <Box
                sx={{
                    alignItems: 'center',
                    display: 'flex',
                    flexWrap: 'wrap',
                    m: -1,
                    p: 2,
                    minHeight: 130,
                }}
            >
                <Box
                    sx={{
                        m: 1,
                        maxWidth: '100%',
                        width: 500
                    }}
                >

                    <Autocomplete
                        open={open}
                        onOpen={() => {
                            // only open when in focus and inputValue is not empty
                            if (inputValue) {
                                setOpen(true);
                            }
                        }}
                        onClose={() => setOpen(false)}
                        onInputChange={(e, value, reason) => {
                            setInputValue(value);
                            // only open when inputValue is not empty after the user typed something
                            if (!value) {
                                setOpen(false);
                            }
                        }}
                        onChange={(event, value) => setLocation(value)}
                        id="combo-box-demo"
                        options={addresses} // eslint-disable-line
                        renderInput={(params) =>
                            <TextField {...params}
                                       fullWidth
                                       placeholder="Where are you going?"
                                       variant="outlined"
                                       InputProps={{
                                           ...params.InputProps,
                                           startAdornment: (
                                               <InputAdornment position="start">
                                                   <BedIcon fontSize="small"/>
                                               </InputAdornment>
                                           ),
                                       }}
                            />}
                    />
                </Box>
                <Box
                    sx={{
                        m: 1,
                        mb: -1.6,
                        maxWidth: '100%',
                        width: 580
                    }}
                >
                    <DateRangePicker
                        startText="Check-in"
                        endText="Check-out"
                        value={value}
                        onChange={(newValue) => {
                            setValue(newValue);
                        }}
                        renderInput={(startProps, endProps) => (
                            <React.Fragment>
                                <TextField {...startProps}/>
                                <Box sx={{mx: 2}}> — </Box>
                                <TextField {...endProps}/>
                            </React.Fragment>
                        )}
                    />
                </Box>
                <Box
                    sx={{
                        m: 1,
                        mb: 3.7,
                        ml: -9,
                        mr: 10
                    }}>
                    <InputLabel id="guests">Guests</InputLabel>
                    <Select
                        labelId="guests-label"
                        id="demo-simple-select-autowidth"
                        value={guests}
                        onChange={handleGuests}
                        label="Guests"
                        style={{width: 80, textAlign: 'center'}}
                    >
                        <MenuItem value={1}>1</MenuItem>
                        <MenuItem value={2}>2</MenuItem>
                        <MenuItem value={3}>3</MenuItem>
                        <MenuItem value={4}>4</MenuItem>
                    </Select>
                </Box>
                <Grid item>
                    <Box sx={{ml: -4}}>
                        <Button
                            color="primary"
                            component={RouterLink}
                            startIcon={<SearchIcon fontSize="small"/>}
                            sx={{m: 1, height: 60, width: 150}}
                            to=""
                            variant="contained"
                            onClick={handleSearch}
                        >
                            Search
                        </Button>
                    </Box>
                </Grid>
            </Box>
        </Card>
    );
};

export default HotelSearchBar;