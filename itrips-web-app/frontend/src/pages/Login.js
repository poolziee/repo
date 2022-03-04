import * as React from 'react';
import {Link, useNavigate} from "react-router-dom";
import {useState} from "react";
import AuthService from "../services/auth-service";
import {
    Avatar,
    Button,
    CssBaseline,
    TextField,
    FormControlLabel,
    Checkbox,
    Grid,
    Box,
    Typography,
    Container, FormHelperText
} from '@material-ui/core';
import {useEffect} from "react";

function Copyright(props) {
    return (
        <Typography variant="body2" color="text.secondary" align="center" {...props}>
            {'Copyright © '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}


export default function Login() {
    const [errorMessage, setErrorMessage] = useState("");
    const [inputUsername, setInputUsername] = useState({username: "",});
    const [inputPassword, setInputPassword] = useState({password: "",})
    let navigate = useNavigate();

    const onUsernameChange = e => {
        setInputUsername({
            ...inputUsername,
            [e.target.name]: e.target.value,
        })
    }

    const onPasswordChange = e => {
        setInputPassword({
            ...inputPassword,
            [e.target.name]: e.target.value,
        })
    }

    useEffect(() => {
        let user = AuthService.getCurrentUser();
        if (user) {
            if (!AuthService.sessionExpired()) {
                if (user.roles.some(role => role.name === 'ROLE_ADMIN')) {
                    navigate('/admin');
                } else if (user.roles.some(role => role.name === 'ROLE_BOOKER')) {
                    navigate('/booker');
                } else if (user.roles.some(role => role.name === 'ROLE_HOTEL_MANAGER')) {
                    navigate('/hotelmanager');
                }
            }
        }

    }, [navigate, errorMessage])

    const handleSubmit = (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);
        AuthService.login(data)
            .then(user => {
                    if (user.tokens) {
                        if (user.roles.some(role => role.name === 'ROLE_ADMIN')) {
                            navigate('/admin');
                        } else if (user.roles.some(role => role.name === 'ROLE_BOOKER')) {
                            navigate('/booker');
                        } else if (user.roles.some(role => role.name === 'ROLE_HOTEL_MANAGER')) {
                            navigate('/hotelmanager');
                        }
                    }
                }
            )
            .catch((err) => {
                setErrorMessage(err.response.data.error_message);
            });
        setInputUsername({username: ""});
        setInputPassword({password: ""});
    };

    return (

        <div className="page">
            <Container component="main" maxWidth="sm">
                <CssBaseline/>
                <Box
                    sx={{
                        marginTop: 8,
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                        border: 1,
                        borderRadius: 6,
                        padding: 5,
                    }}
                >
                    <Avatar sx={{m: 1, bgcolor: 'secondary.main'}}>
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Sign in
                    </Typography>
                    <Box component="form" onSubmit={handleSubmit} noValidate sx={{mt: 1}}>
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            label="Username"
                            name="username"
                            autoComplete="username"
                            autoFocus
                            onChange={onUsernameChange}
                            value={inputUsername.username}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            name="password"
                            label="Password"
                            type="password"
                            autoComplete="current-password"
                            onChange={onPasswordChange}
                            value={inputPassword.password}
                        />
                        <FormControlLabel
                            control={<Checkbox value="remember" color="primary"/>}
                            label="Remember me"
                        />
                        <Box sx={{mt: 3}}>
                            <FormHelperText error>
                                {errorMessage}
                            </FormHelperText>
                        </Box>
                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{mt: 3, mb: 2}}
                        >
                            Sign In
                        </Button>
                        <Grid container>
                            <Grid item xs>
                                <Link to="#" variant="body2">
                                    Forgot password?
                                </Link>
                            </Grid>
                            <Grid item>
                                <Link to='/register' variant="body2">
                                    {"Don't have an account? Sign Up"}
                                </Link>
                            </Grid>
                        </Grid>
                    </Box>
                </Box>
                <Copyright sx={{mt: 8, mb: 4}}/>
            </Container>
        </div>
    );
}