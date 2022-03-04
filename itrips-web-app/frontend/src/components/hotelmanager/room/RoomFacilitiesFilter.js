import {useState} from 'react';
import {Box, Button, Card, CardHeader, Chip, Divider, Input} from '@material-ui/core';
import SearchIcon from '../../../icons/Search';
import MultiSelect from '../../MultiSelect';

const selectOptions = [
    {
        label: 'Electronics',
        options: [
            'Refrigerator',
            'Microwave',
            'Hairdryer',
            'TV',
        ]
    },
    {
        label: 'View',
        options: [
            'Sea view',
            'Garden view',
            'Forest view'
        ]
    },
    {
        label: 'Other',
        options: [
            'Free WiFi',
            'Minibar',
            'Terrace'
        ]
    }
];

const RoomFacilitiesFilter = ({parentalCallBack}) => {
    const [inputValue, setInputValue] = useState('');
    const [chips, setChips] = useState([
        'Garden view',
        'Free WiFi',
        'Terrace',
    ]);

    const handleInputChange = (event) => {
        setInputValue(event.target.value);
    };

    const handleInputKeyup = (event) => {
        if (event.code === 'ENTER' && inputValue) {
            if (!chips.includes(inputValue)) {
                setChips((prevChips) => [...prevChips, inputValue]);
                setInputValue('');
            }
        }
    };

    const handleNewFacility = (event) => {
        setChips((prevChips) => [...prevChips, inputValue]);
        parentalCallBack('facilities', chips);
        setInputValue("");
    }

    const handleChipDelete = (chip) => {
        setChips((prevChips) => prevChips.filter((prevChip) => chip !== prevChip));
    };

    const handleMultiSelectChange = (value) => {
        setChips(value);
    };

    return (
        <Card>
            <CardHeader title="Facilities"/>
            <Box
                sx={{
                    alignItems: 'center',
                    display: 'flex',
                    p: 2
                }}
            >
                <SearchIcon fontSize="small"/>
                <Box
                    sx={{
                        flexGrow: 1,
                        ml: 3,
                        maxWidth: 120
                    }}
                >
                    <Input
                        fullWidth
                        disableUnderline
                        onChange={handleInputChange}
                        onKeyUp={handleInputKeyup}
                        placeholder="Enter a facility"
                        value={inputValue}
                    />
                </Box>
                <Button
                    color="primary"
                    onClick={handleNewFacility}
                    variant="contained"
                >
                    Add
                </Button>
            </Box>
            <Divider/>
            <Box
                sx={{
                    alignItems: 'center',
                    display: 'flex',
                    flexWrap: 'wrap',
                    p: 2
                }}
            >
                {chips.map((chip) => (
                    <Chip
                        key={chip}
                        label={chip}
                        onDelete={() => handleChipDelete(chip)}
                        sx={{m: 1}}
                        variant="outlined"
                    />
                ))}
            </Box>
            <Divider/>
            <Box
                sx={{
                    alignItems: 'center',
                    display: 'flex',
                    flexWrap: 'wrap',
                    p: 1
                }}
            >
                {selectOptions.map((option) => (
                    <MultiSelect
                        key={option.label}
                        label={option.label}
                        onChange={handleMultiSelectChange}
                        options={option.options}
                        value={chips}
                    />
                ))}
                <Box sx={{flexGrow: 1}}/>
            </Box>
        </Card>
    );
};

export default RoomFacilitiesFilter;
