import React from 'react';
import DashboardLayout from "../components/DashboardLayout";
import {Outlet} from "react-router-dom";
import AuthService from "../services/auth-service";
import AuthorizationRequired from "./AuthorizationRequired";
import {useNavigate} from "react-router";

const Booker = () => {
    const navigate = useNavigate();
    if (AuthService.isAuthenticated("ROLE_BOOKER")) {
        if (!AuthService.sessionExpired()) {
            return (
                DashboardLayout(<Outlet/>)
            )
        } else {
            navigate("/");
        }
    } else {
        return <AuthorizationRequired/>;
    }
}
export default Booker;
