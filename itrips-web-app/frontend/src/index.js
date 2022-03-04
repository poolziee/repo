import 'react-perfect-scrollbar/dist/css/styles.css';
import 'react-draft-wysiwyg/dist/react-draft-wysiwyg.css';
import 'react-quill/dist/quill.snow.css';
import 'nprogress/nprogress.css';
import ReactDOM from 'react-dom';
import {BrowserRouter as Router} from 'react-router-dom';
import App from './App';
import {CssBaseline, ThemeProvider} from '@material-ui/core';
import theme from './theme/theme.js'
import {Provider as ReduxProvider} from 'react-redux';
import store from './store';
import {RecoilRoot} from "recoil";
import recoilPersist from "recoil-persist";

const {RecoilPersist, updateState} = recoilPersist([], {
    key: "recoil-persist",
    storage: sessionStorage,
});

ReactDOM.render(
    <RecoilRoot initializeState={updateState}>
        <ReduxProvider store={store}>
            <Router>
                <ThemeProvider theme={theme}>
                    <CssBaseline/>
                    <RecoilPersist/>
                    <App/>
                </ThemeProvider>
            </Router>
        </ReduxProvider>
    </RecoilRoot>
    , document.getElementById('root')
);