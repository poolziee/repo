import {useState} from 'react';
import {useNavigate, useParams} from 'react-router-dom';
import toast from 'react-hot-toast';
import * as Yup from 'yup';
import HotelService from '../../../services/hotelmanager-service';
import {Formik} from 'formik';
import {useLocation} from "react-router";
import {
    Box,
    Button,
    Card,
    CardContent,
    CardHeader,
    FormHelperText,
    Grid,
    TextField,
} from '@material-ui/core';
import FileDropzone from '../../FileDropzone';
import RoomFacilitiesFilter from "./RoomFacilitiesFilter";


const RoomCreateForm = (props) => {

    const {hotelId} = useParams();
    const navigate = useNavigate();
    const [files, setFiles] = useState([]);
    const {state} = useLocation();
    let {room} = "";

    if (state.selectedRoom != null) {
        room = state.selectedRoom;
    } else {
        room = {
            id: '',
            type: '',
            sleeps: '',
            facilities: [],
            images: [],
            total: '',
            price: '',
            submit: ''
        }
    }

    const handleDrop = (newFiles) => {
        setFiles((prevFiles) => [...prevFiles, ...newFiles]);
    };

    const handleRemove = (file) => {
        setFiles((prevFiles) => prevFiles.filter((_file) => _file.path
            !== file.path));
    };

    const handleRemoveAll = () => {
        setFiles([]);
    };

    function onKeyDown(keyEvent) {
        if ((keyEvent.charCode || keyEvent.keyCode) === 13) {
            keyEvent.preventDefault();
        }
    }


    return (
        <Formik
            initialValues={{

                type: room.type,
                sleeps: room.sleeps,
                facilities: room.facilities,
                images: room.images,
                total: room.total,
                price: room.price,
                submit: ''
            }}
            validationSchema={Yup
                .object()
                .shape({
                    type: Yup.string().max(255).required(),
                    sleeps: Yup.number().min(0).required(),
                    facilities: Yup.array(),
                    images: Yup.array(),
                    price: Yup.number().min(0).required(),
                    total: Yup.number().min(0).required(),
                })}
            onSubmit={async (values, {setErrors, setStatus, setSubmitting}) => {
                try {
                    // NOTE: Make API request
                    if (room.type === "") {
                        HotelService.addRoom(hotelId, values).then(response => {
                            let hotel = response.data;
                            setStatus({success: true});
                            setSubmitting(false);
                            toast.success('Proceeding with rooms!');
                            navigate('/hotelmanager/hotels/' + hotelId + '/newroom', {
                                state: {hotel}
                            });
                        });
                    } else {
                        HotelService.updateRoom(values, room.id).then(response => {
                            let hotel = response.data;
                            setStatus({success: true});
                            setSubmitting(false);
                            toast.success('Proceeding with rooms!');
                            navigate('/hotelmanager/hotels/' + hotelId + '/newroom', {
                                state: {hotel}
                            });
                        });
                    }

                } catch (err) {
                    console.error(err);
                    toast.error('Something went wrong!');
                    setStatus({success: false});
                    setErrors({submit: err.message});
                    setSubmitting(false);
                }
            }}
        >
            {({
                  errors,
                  handleBlur,
                  handleChange,
                  handleSubmit,
                  isSubmitting,
                  setFieldValue,
                  touched,
                  values
              }) => (
                <form
                    onSubmit={handleSubmit}
                    onKeyDown={onKeyDown}
                    {...props}
                >
                    <Grid
                        container
                        spacing={3}
                    >
                        <Grid
                            item
                            lg={8}
                            md={6}
                            xs={12}
                        >
                            <Card>
                                <CardContent>
                                    <CardHeader title="General"/>
                                    <TextField
                                        error={Boolean(touched.type && errors.type)}
                                        fullWidth
                                        helperText={touched.type && errors.type}
                                        label="Room type"
                                        name="type"
                                        onBlur={handleBlur}
                                        onChange={handleChange}
                                        value={values.type}
                                        variant="outlined"
                                    />
                                    <Box sx={{mt: 2}}>
                                        <TextField
                                            error={Boolean(touched.sleeps && errors.sleeps)}
                                            fullWidth
                                            helperText={touched.sleeps && errors.sleeps
                                                ? errors.sleeps
                                                : 'Sleeping places'}
                                            label="Sleeps"
                                            name="sleeps"
                                            onBlur={handleBlur}
                                            onChange={handleChange}
                                            type="number"
                                            value={values.sleeps}
                                            variant="outlined"
                                        />
                                    </Box>
                                </CardContent>
                            </Card>
                            <Box sx={{mt: 3}}>
                                <Card>
                                    <RoomFacilitiesFilter parentalCallBack={setFieldValue}/>
                                </Card>
                            </Box>
                            <Box sx={{mt: 3}}>
                                <Card>
                                    <CardHeader title="Upload Images"/>
                                    <CardContent>
                                        <FileDropzone
                                            accept="image/*"
                                            files={files}
                                            onDrop={handleDrop}
                                            onRemove={handleRemove}
                                            onRemoveAll={handleRemoveAll}
                                        />
                                    </CardContent>
                                </Card>
                            </Box>
                        </Grid>
                        <Grid
                            item
                            lg={4}
                            md={6}
                            xs={12}
                        >
                            <Card>
                                <CardHeader title="Organize"/>
                                <CardContent>
                                    <Box sx={{mt: 2}}>
                                        <TextField
                                            error={Boolean(touched.total && errors.total)}
                                            fullWidth
                                            helperText={touched.total && errors.total
                                                ? errors.total
                                                : 'Total rooms available at the hotel'}
                                            label="Total rooms"
                                            name="total"
                                            onBlur={handleBlur}
                                            onChange={handleChange}
                                            type="number"
                                            value={values.total}
                                            variant="outlined"
                                        />
                                    </Box>
                                    <Box sx={{mt: 2}}>
                                        <TextField
                                            error={Boolean(touched.price && errors.price)}
                                            fullWidth
                                            helperText={touched.price && errors.price
                                                ? errors.price
                                                : 'The room price per night'}
                                            label="Price"
                                            name="price"
                                            onBlur={handleBlur}
                                            onChange={handleChange}
                                            type="number"
                                            value={values.price}
                                            variant="outlined"
                                        />
                                    </Box>
                                </CardContent>
                            </Card>
                            {errors.submit && (
                                <Box sx={{mt: 3}}>
                                    <FormHelperText error>
                                        {errors.submit}
                                    </FormHelperText>
                                </Box>
                            )}
                            <Box
                                sx={{
                                    display: 'flex',
                                    justifyContent: 'flex-end',
                                    mt: 3
                                }}
                            >
                                <Button
                                    color="primary"
                                    disabled={isSubmitting}
                                    type="submit"
                                    variant="contained"
                                >
                                    Save & Proceed
                                </Button>
                            </Box>
                        </Grid>
                    </Grid>
                </form>
            )}
        </Formik>
    );
};

export default RoomCreateForm;