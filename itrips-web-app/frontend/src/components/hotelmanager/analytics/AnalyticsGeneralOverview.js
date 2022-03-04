import Chart from 'react-apexcharts';
import {Box, Button, Card, Divider, Grid, Typography} from '@material-ui/core';
import {useTheme} from '@material-ui/core/styles';
import ArrowRightIcon from '../../../icons/ArrowRight';
/* eslint-disable */
const LineChart = (props) => {
    const theme = useTheme();
    const {arr} = props;
    const chartOptions = {
        chart: {
            background: 'transparent',
            toolbar: {
                show: false
            },
            zoom: {
                enabled: false
            }
        },
        colors: ['#000080'],
        dataLabels: {
            enabled: false
        },
        grid: {
            show: false
        },
        stroke: {
            width: 3
        },
        theme: {
            mode: theme.palette.mode
        },
        tooltip: {
            enabled: false
        },
        xaxis: {
            labels: {
                show: false
            },
            axisBorder: {
                show: false
            },
            axisTicks: {
                show: false
            }
        },
        yaxis: {
            show: false
        }
    };

    const chartSeries = [{data: arr}];

    return (
        <Chart
            options={chartOptions}
            series={chartSeries}
            type="line"
            width={120}
        />
    );
};

const BarChart = (props) => {
    const {color} = props;
    const {data} = props;
    const theme = useTheme();
    const colors = [];
    colors.push(color);
    const chartOptions = {
        chart: {
            background: 'transparent',
            toolbar: {
                show: false
            },
            zoom: {
                enabled: false
            }
        },
        colors: colors,
        dataLabels: {
            enabled: false
        },
        grid: {
            show: false
        },
        states: {
            normal: {
                filter: {
                    type: 'none',
                    value: 0
                }
            }
        },
        stroke: {
            width: 0
        },
        theme: {
            mode: theme.palette.mode
        },
        tooltip: {
            enabled: false
        },
        xaxis: {
            axisBorder: {
                show: false
            },
            axisTicks: {
                show: false
            },
            labels: {
                show: false
            }
        },
        yaxis: {
            show: false
        }
    };

    const chartSeries = [{data: data}];
    return (
        <Chart
            options={chartOptions}
            series={chartSeries}
            type="bar"
            width={120}
        />
    );
};

const AnalyticsGeneralOverview = (props) => {
    const {data} = props;
    const {parentalCallBack} = props;
    const lineChartData = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    data.entities.map((entity) => {
        for (let i = 0; i < 12; i++) {
            lineChartData[i] += entity.data[i];
        }
    })
    const kFormatter = (x) => {
        return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    }

    const sendHotelName = (hotelName) => {
        parentalCallBack(hotelName);
    }
    return (
        <>
            <Grid
                container
                spacing={2}
            >
                <Grid
                    item
                    md={3}
                    sm={6}
                    xs={12}
                >
                    <Card>
                        <Box
                            sx={{
                                alignItems: 'center',
                                display: 'flex',
                                justifyContent: 'space-between',
                                p: 3
                            }}
                        >
                            <div>
                                <Typography
                                    color="textPrimary"
                                    variant="subtitle2"
                                >
                                    Total Bookings
                                </Typography>
                                <Typography
                                    color="textPrimary"
                                    sx={{mt: 1}}
                                    variant="h4"
                                >
                                    {kFormatter(data.totalSum)}
                                </Typography>
                            </div>
                            <LineChart arr={lineChartData}/>
                        </Box>
                        <Divider/>
                        <Box
                            sx={{
                                px: 3,
                                py: 2
                            }}
                        >
                            <Button
                                color="primary"
                                endIcon={<ArrowRightIcon fontSize="small"/>}
                                variant="text"
                                onClick={() => {
                                    sendHotelName(" ")
                                }}
                            >
                                Chart
                            </Button>
                        </Box>
                    </Card>
                </Grid>
                {data.entities.map((ent) => (
                    <Grid
                        item
                        md={3}
                        sm={6}
                        xs={12}
                    >
                        <Card>
                            <Box
                                sx={{
                                    alignItems: 'center',
                                    display: 'flex',
                                    justifyContent: 'space-between',
                                    p: 3
                                }}
                            >
                                <div>
                                    <Typography
                                        color="textPrimary"
                                        variant="subtitle2"
                                    >
                                        {ent.name}
                                    </Typography>
                                    <Typography
                                        color="textPrimary"
                                        sx={{mt: 1}}
                                        variant="h5"
                                    >
                                        {kFormatter(ent.sum)}
                                    </Typography>
                                </div>
                                <BarChart color={ent.color} data={ent.data}/>
                            </Box>
                            <Divider/>
                            <Box
                                sx={{
                                    px: 3,
                                    py: 2
                                }}
                            >
                                <Button
                                    color="primary"
                                    endIcon={<ArrowRightIcon fontSize="small"/>}
                                    variant="text"
                                    onClick={() => {
                                        sendHotelName(ent.name)
                                    }}
                                >
                                    Chart
                                </Button>
                            </Box>
                        </Card>
                    </Grid>
                ))}

            </Grid>
        </>
    );
}
/* eslint-disable */

export default AnalyticsGeneralOverview;
