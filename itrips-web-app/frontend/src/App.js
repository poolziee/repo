import {useRoutes} from "react-router-dom"
import DateAdapter from '@material-ui/lab/AdapterDateFns';


import './style/style.css'
import routes from './routes';
import axios from "axios";
import refreshToken from "./services/refreshToken";
import authHeader from "./services/auth-header";
import {LocalizationProvider} from "@material-ui/lab";
import "antd/lib/message/style/index.css";

const App = () => {

    axios.interceptors.response.use(null, (error) => {
        const user = localStorage.getItem('user') || "";
        if (error.config && error.response && error.response.status === 403 && !error.config._retry) {
            error.config._retry = true;
            if (user !== "") {
                return refreshToken().then((token) => {
                    error.config.headers = authHeader();
                    console.log("refreshed access token");
                    return axios.request(error.config);
                });
            }
            return axios.request(error.config);
        }

        return Promise.reject(error);
    });

    const backupError = console.error;
    console.error = function filterErrors(msg) {
        const suppressedErrors = [
            'Warning: validateDOMNesting',
            'Warning: A component is changing an uncontrolled input to be controlled',
            'Warning: Failed %s type:',
            'Warning: Each child in a list should have a unique "key" prop',
            'Warning: React does not recognize the `startIcon` prop on a DOM element'
        ];
        if (!suppressedErrors.some(entry => msg.includes(entry))) {
            backupError.apply(console, arguments);
        }
    };

    const backup = console.warn;
    console.warn = function filterWarnings(msg) {
        const suppressedWarnings = [
            'Warning: componentWillReceiveProps has been renamed',
            'Warning: componentWillUpdate has been renamed',
            'Warning: validateDOMNesting',
            'Warning: React does not recognize the `startIcon` prop on a DOM element',
            'Failed prop type'
        ];

        if (!suppressedWarnings.some(entry => msg.includes(entry))) {
            backup.apply(console, arguments);
        }
    };
    const content = useRoutes(routes);
    return (
        <>
            <LocalizationProvider dateAdapter={DateAdapter}>
                {content}
            </LocalizationProvider>


        </>
    );

}

export default App;
