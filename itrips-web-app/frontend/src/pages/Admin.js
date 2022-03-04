import React from 'react';
import DashboardLayout from "../components/DashboardLayout";
import {Outlet} from "react-router-dom";
import AuthService from "../services/auth-service";
import AuthorizationRequired from "./AuthorizationRequired";

const Admin = () => {

    if (AuthService.isAuthenticated("ROLE_ADMIN")) {
        return (
            DashboardLayout(<Outlet/>)
        )
    } else {
        return <AuthorizationRequired/>;
    }
}

export default Admin;
