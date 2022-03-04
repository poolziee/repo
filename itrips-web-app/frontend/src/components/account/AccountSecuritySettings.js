import toast from 'react-hot-toast';
import * as Yup from 'yup';
import {Formik} from 'formik';
import {
    Box,
    Button,
    Card,
    CardContent,
    CardHeader,
    Divider,
    FormHelperText,
    Grid,
    TextField
} from '@material-ui/core';
import wait from '../../utils/wait';
import * as React from "react";
import service from '../../services/auth-service';
import {useEffect, useState} from "react";

const AccountSecuritySettings = (props) => {

    const [successHidden, setSuccessHidden] = useState(true);
    const [errorMessage, setErrorMessage] = useState('');

    useEffect(() => {

    }, [successHidden, errorMessage])

    return (

        <Formik
            initialValues={{
                currPassword: '',
                password: '',
                passwordConfirm: '',
                submit: null
            }}
            validationSchema={Yup
                .object()
                .shape({
                    currPassword: Yup
                        .string()
                        .min(8, 'Must be at least 7 characters')
                        .max(255)
                        .required('Required'),
                    password: Yup
                        .string()
                        .min(8, 'Must be at least 7 characters')
                        .max(255)
                        .required('Required'),
                    passwordConfirm: Yup
                        .string()
                        .oneOf([Yup.ref('password'), null], 'Passwords must match')
                        .required('Required')
                })}
            onSubmit={async (values, {resetForm, setErrors, setStatus, setSubmitting}) => {
                try {
                    // NOTE: Make API request
                    service.updatePassword(values.password, values.currPassword).then((response) => {
                        setErrorMessage('');
                        setSuccessHidden(false);
                    }).catch((err) => {
                        console.log(err.response);
                        setSuccessHidden(true);
                        setErrorMessage(err.response.data.error);
                    })
                    await wait(500);
                    resetForm();
                    setStatus({success: true});
                    setSubmitting(false);
                    toast.success('Password updated!');
                } catch (err) {
                    toast.error('Something went wrong!');
                    setStatus({success: false});
                    setErrors({submit: err.message});
                    setSubmitting(false);
                }
            }}
        >
            {({errors, handleBlur, handleChange, handleSubmit, isSubmitting, touched, values}) => (
                <form
                    onSubmit={handleSubmit}
                    {...props}
                >
                    <Card>
                        <CardHeader title="Change Password"/>
                        <Divider/>
                        <CardContent>
                            <Grid
                                container
                                direction={'column'}
                                spacing={4}

                            >
                                <Grid
                                    item
                                    md={4}
                                    sm={6}
                                    xs={12}
                                    justify="space-between"
                                >
                                    <TextField
                                        error={Boolean(touched.currPassword && errors.currPassword)}
                                        fullWidth
                                        helperText={touched.currPassword && errors.currPassword}
                                        label="Current Password"
                                        name="currPassword"
                                        onBlur={handleBlur}
                                        onChange={handleChange}
                                        type="password"
                                        value={values.currPassword}
                                        variant="outlined"
                                    />

                                </Grid>
                                <Grid
                                    item
                                    md={4}
                                    sm={6}
                                    xs={12}

                                >
                                    <TextField
                                        error={Boolean(touched.password && errors.password)}
                                        fullWidth
                                        helperText={touched.password && errors.password}
                                        label="New Password"
                                        name="password"
                                        onBlur={handleBlur}
                                        onChange={handleChange}
                                        type="password"
                                        value={values.password}
                                        variant="outlined"
                                    />
                                </Grid>
                                <Grid
                                    item
                                    md={4}
                                    sm={6}
                                    xs={12}
                                >
                                    <TextField
                                        error={Boolean(touched.passwordConfirm && errors.passwordConfirm)}
                                        fullWidth
                                        helperText={touched.passwordConfirm && errors.passwordConfirm}
                                        label="Confirm new password"
                                        name="passwordConfirm"
                                        onBlur={handleBlur}
                                        onChange={handleChange}
                                        type="password"
                                        value={values.passwordConfirm}
                                        variant="outlined"
                                    />
                                </Grid>
                            </Grid>
                            {errors.submit && (
                                <Box sx={{mt: 3}}>
                                    <FormHelperText error>
                                        {errors.submit}
                                    </FormHelperText>
                                </Box>
                            )}
                        </CardContent>
                        <Divider/>
                        <Box
                            sx={{
                                display: 'flex',
                                justifyContent: 'flex-end',
                                p: 2
                            }}
                        >
                            <Box sx={{mt: 3}}>
                                <FormHelperText sx={{color: 'green', fontSize: 'medium', marginRight: 3}}
                                                hidden={successHidden}>
                                    Successfully updated password!
                                </FormHelperText>
                                <FormHelperText error sx={{fontSize: 'medium', marginRight: 3}}>
                                    {errorMessage}
                                </FormHelperText>
                            </Box>
                            <Button
                                color="primary"
                                disabled={isSubmitting}
                                type="submit"
                                variant="contained"
                            >
                                Change Password
                            </Button>
                        </Box>
                    </Card>
                </form>
            )}
        </Formik>
    );
}


export default AccountSecuritySettings;
