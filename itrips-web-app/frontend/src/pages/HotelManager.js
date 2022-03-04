import DashboardLayout from "../components/DashboardLayout";
import {Outlet, useNavigate} from "react-router-dom";
import AuthService from "../services/auth-service";
import AuthorizationRequired from "./AuthorizationRequired";

const HotelManager = () => {

    const navigate = useNavigate();
    if (AuthService.isAuthenticated("ROLE_HOTEL_MANAGER")) {
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
export default HotelManager;
