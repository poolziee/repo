import axios from "axios";
import jwt_decode from "jwt-decode";
import authHeader from './auth-header';


const API_URL = "http://localhost:3000/api/";
const register = (data) => {
    return axios.post(API_URL + "register", data, {
        headers: {
            'Content-Type': 'application/json'
        }
    })
};
const login = (data) => {
    return axios
        .post(API_URL + "login", data)
        .then((response) => {
            console.log(response);
            if (response.data.tokens) {

                localStorage.setItem("user", JSON.stringify(response.data));
            }
            return response.data;
        });
};

const logout = () => {
    localStorage.clear();
    sessionStorage.clear();
};

const getCurrentUser = () => {
    return JSON.parse(localStorage.getItem("user")) || "";
};

const isAuthenticated = (role) => {
    if (getCurrentUser() === "") {
        return false;
    }
    return getCurrentUser().roles.some(r => r.name === role);
}

const sessionExpired = () => {

    let user = getCurrentUser();
    if (user !== "") {
        let tokens = user.tokens;
        let decodedRefresh = jwt_decode(tokens.refresh_token);
        if (decodedRefresh.exp * 1000 < Date.now()) {
            localStorage.clear();
            return true;
        }
    }
    return false;
}

const updateUser = (email, firstName, lastName) => {
    const userId = getCurrentUser().id;
    return axios.put(API_URL + "user/update-user", null, {
        params: {email, firstName, lastName, userId},
        headers: authHeader()
    })
}
const updatePassword = (newPassword, currPassword) => {
    const userId = getCurrentUser().id;
    return axios.put(API_URL + "user/update-password", null, {
        params: {newPassword, currPassword, userId},
        headers: authHeader()
    })
}
// eslint-disable-next-line import/no-anonymous-default-export
export default {
    register,
    login,
    logout,
    getCurrentUser,
    isAuthenticated,
    sessionExpired,
    updateUser,
    updatePassword
};