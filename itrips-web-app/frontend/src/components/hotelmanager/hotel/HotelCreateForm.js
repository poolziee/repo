import {useState} from 'react';
import {useNavigate} from 'react-router-dom';
import toast from 'react-hot-toast';
import * as Yup from 'yup';
import {Formik} from 'formik';
import HotelService from '../../../services/hotelmanager-service';
import StarRating from "../../widgets/StarRating";
import {
    Alert,
    Box,
    Button,
    Card,
    CardContent,
    CardHeader,
    FormHelperText,
    Grid, Snackbar, Stack,
    TextField,
    Typography
} from '@material-ui/core';
import FileDropzone from '../../FileDropzone';
import QuillEditor from '../../QuillEditor';
import ArrowRightIcon from '../../../icons/ArrowRight'
import {useLocation} from "react-router";

const HotelCreateForm = (props) => {
    const navigate = useNavigate();
    const [files, setFiles] = useState([]);
    const {state} = useLocation();
    let {hotel} = "";
    let stars = 0;
    if (state !== null) {
        hotel = state.hotel;
        stars = hotel.stars;
    } else {
        hotel =
            {
                description: "",
                //  images: [],
                name: "",
                country: "",
                city: "",
                street: "",
                stars: "",
                submit: null
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

    const [open, setOpen] = useState(false);


    const handleClose = (event, reason) => {
        if (reason === "clickaway") {
            return;
        }

        setOpen(false);
    };

    return (
        <>
            <Stack sx={{}}>
                <Snackbar open={open} autoHideDuration={5000} onClose={handleClose} style={{
                    position: 'fixed',
                    top: 0,
                    right: 0,
                    flexDirection: 'column'
                }}>
                    <Alert onClose={handleClose} severity="error">
                        Please provide star rating!
                    </Alert>
                </Snackbar>
            </Stack>

            <Formik
                initialValues={{
                    description: hotel.description,
                    //  images: [],
                    name: hotel.name,
                    country: hotel.country,
                    city: hotel.city,
                    street: hotel.street,
                    stars: hotel.stars,
                    caption: hotel.caption,
                    submit: null
                }}
                validationSchema={Yup
                    .object()
                    .shape({
                        description: Yup.string().max(5000),
                        // images: Yup.array(),
                        name: Yup.string().max(255).required(),
                        country: Yup.string().max(255).required(),
                        city: Yup.string().max(255).required(),
                        street: Yup.string().max(255).required(),
                        caption: Yup.string().max(255).required(),
                    })}
                onSubmit={async (values, {setStatus, setSubmitting}) => {

                    if (values.stars !== "") {
                        // NOTE: Make API request
                        if (hotel.name === "") {
                            HotelService.addHotel(values)
                                .then(response => {
                                    let hotel = response.data;
                                    if (hotel.id !== null) {
                                        setStatus({success: true});
                                        setSubmitting(false);
                                        toast.success('Proceeding with rooms!');
                                        navigate('/hotelmanager/hotels/' + hotel.id + '/newroom', {
                                            state: {hotel}
                                        });
                                    }
                                })
                                .catch((err) => {
                                    console.log(err);
                                });
                        } else {
                            HotelService.updateHotel(values, hotel.id)
                                .then(response => {
                                    let hotel = response.data;
                                    if (hotel.id !== null) {
                                        setStatus({success: true});
                                        setSubmitting(false);
                                        toast.success('Proceeding with rooms!');
                                        navigate('/hotelmanager/hotels/' + hotel.id + '/newroom', {
                                            state: {hotel}
                                        });
                                    }
                                })
                                .catch((err) => {
                                    console.log(err);
                                });
                        }
                    } else {
                        setOpen(true);
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
                      values,
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
                                        <div style={{textAlign: 'center'}}>
                                            <TextField
                                                style={{width: 400}}
                                                error={Boolean(touched.name && errors.name)}
                                                helperText={touched.name && errors.name}
                                                label="Hotel Name"
                                                name="name"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                value={values.name}
                                                variant="outlined"
                                            />
                                        </div>
                                        <Typography
                                            color="textSecondary"
                                            sx={{
                                                mb: 2,
                                                mt: 3
                                            }}
                                            variant="subtitle2"
                                        >
                                            Caption
                                        </Typography>
                                        <TextField
                                            error={Boolean(touched.caption && errors.caption)}
                                            fullWidth
                                            helperText={touched.caption && errors.caption}
                                            name="caption"
                                            onBlur={handleBlur}
                                            onChange={handleChange}
                                            value={values.caption}
                                            variant="outlined"
                                        />
                                        <Typography
                                            color="textSecondary"
                                            sx={{
                                                mb: 2,
                                                mt: 3
                                            }}
                                            variant="subtitle2"
                                        >
                                            Description
                                        </Typography>
                                        <QuillEditor
                                            onChange={(value) => setFieldValue('description', value)}
                                            placeholder="Write something"
                                            sx={{height: 400}}
                                            value={values.description}
                                        />
                                        {(touched.description && errors.description) && (
                                            <Box sx={{mt: 2}}>
                                                <FormHelperText error>
                                                    {errors.description}
                                                </FormHelperText>
                                            </Box>
                                        )}
                                        <Typography
                                            color="textSecondary"
                                            sx={{
                                                mb: 2,
                                                mt: 3
                                            }}
                                            variant="subtitle2"
                                        >
                                            Stars
                                        </Typography>
                                        <StarRating parentalCallBack={setFieldValue} givenStars={stars}/>
                                    </CardContent>
                                </Card>
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
                                    <CardHeader title="Address"/>
                                    <CardContent>
                                        <Box sx={{mt: 2}}>
                                            <TextField
                                                error={Boolean(touched.country && errors.country)}
                                                fullWidth
                                                helperText={touched.country && errors.country}
                                                label="Country"
                                                name="country"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                value={values.country}
                                                variant="outlined"
                                            />
                                        </Box>
                                        <Box sx={{mt: 2}}>
                                            <TextField
                                                error={Boolean(touched.city && errors.city)}
                                                fullWidth
                                                helperText={touched.city && errors.city}
                                                label="City"
                                                name="city"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                value={values.city}
                                                variant="outlined"
                                            />
                                        </Box>
                                        <Box sx={{mt: 2}}>
                                            <TextField
                                                error={Boolean(touched.street && errors.street)}
                                                fullWidth
                                                helperText={touched.street && errors.street}
                                                label="Street"
                                                name="street"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                value={values.street}
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
                                        endIcon={<ArrowRightIcon/>}
                                    >
                                        Save & Proceed
                                    </Button>
                                </Box>
                            </Grid>
                        </Grid>
                    </form>
                )}
            </Formik>
        </>

    );
};

export default HotelCreateForm;
