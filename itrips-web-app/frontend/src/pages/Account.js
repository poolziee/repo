import {useState} from 'react';
import {Link as RouterLink} from 'react-router-dom';
import {
    Box,
    Breadcrumbs,
    Container,
    Divider,
    Grid,
    Link,
    Tab,
    Tabs,
    Typography
} from '@material-ui/core';
import {
    AccountGeneralSettings,
    AccountSecuritySettings
} from '../components/account';

import ChevronRightIcon from '../icons/ChevronRight';

const tabs = [
    {label: 'General', value: 'general'},
    {label: 'Security', value: 'security'}
];

const Account = () => {
    const [currentTab, setCurrentTab] = useState('general');


    const handleTabsChange = (event, value) => {
        setCurrentTab(value);
    };

    return (
        <>
            <title>Dashboard: Account | Material Kit Pro</title>
            <Box
                sx={{
                    backgroundColor: 'background.default',
                    minHeight: '100%',
                    py: 8
                }}
            >
                <Container maxWidth={'xl'}>
                    <Grid
                        container
                        justifyContent="space-between"
                        spacing={3}
                    >
                        <Grid item>
                            <Typography
                                color="textPrimary"
                                variant="h5"
                            >
                                Account
                            </Typography>
                            <Breadcrumbs
                                aria-label="breadcrumb"
                                separator={<ChevronRightIcon fontSize="small"/>}
                                sx={{mt: 1}}
                            >
                                <Link
                                    color="textPrimary"
                                    component={RouterLink}
                                    to="/dashboard"
                                    variant="subtitle2"
                                >
                                    Dashboard
                                </Link>
                                <Typography
                                    color="textSecondary"
                                    variant="subtitle2"
                                >
                                    Account
                                </Typography>
                            </Breadcrumbs>
                        </Grid>
                    </Grid>
                    <Box sx={{mt: 3}}>
                        <Tabs
                            indicatorColor="primary"
                            onChange={handleTabsChange}
                            scrollButtons="auto"
                            textColor="primary"
                            value={currentTab}
                            variant="scrollable"
                        >
                            {tabs.map((tab) => (
                                <Tab
                                    key={tab.value}
                                    label={tab.label}
                                    value={tab.value}
                                />
                            ))}
                        </Tabs>
                    </Box>
                    <Divider/>
                    <Box sx={{mt: 3}}>
                        {currentTab === 'general' && <AccountGeneralSettings/>}
                        {currentTab === 'security' && <AccountSecuritySettings/>}
                    </Box>
                </Container>
            </Box>
        </>
    );
};

export default Account;
