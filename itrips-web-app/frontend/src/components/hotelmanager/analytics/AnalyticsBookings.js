import Chart from 'react-apexcharts';
import {Box, Card, CardHeader, Typography} from '@material-ui/core';
import {useTheme} from '@material-ui/core/styles';
import Scrollbar from '../../Scrollbar';


const AnalyticsBookings = (props) => {
    const theme = useTheme();
    const {data} = props;
    const kFormatter = (x) => {
        return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    }
    const chartOptions = {
        chart: {
            background: 'transparent',
            stacked: true,
            toolbar: {
                show: false
            }
        },
        dataLabels: {
            enabled: false
        },
        grid: {
            borderColor: theme.palette.divider,
            xaxis: {
                lines: {
                    show: true
                }
            },
            yaxis: {
                lines: {
                    show: true
                },
                labels: {
                    formatter: function (value) {
                        return kFormatter(value);
                    }
                }
            }
        },
        states: {
            active: {
                filter: {
                    type: 'none'
                }
            },
            hover: {
                filter: {
                    type: 'none'
                }
            }
        },
        legend: {
            show: false
        },
        stroke: {
            colors: ['transparent'],
            show: true,
            width: 2
        },
        theme: {
            mode: theme.palette.mode
        },
        xaxis: {
            axisBorder: {
                show: false
            },
            axisTicks: {
                show: false
            },
            categories: data.months,
            labels: {
                style: {
                    colors: theme.palette.text.secondary
                }
            }
        },
        yaxis: {
            labels: {
                offsetX: -12,
                style: {
                    colors: theme.palette.text.secondary
                }
            }
        }
    };

    const chartSeries = data.series;

    return (
        <Card {...props}>
            <CardHeader
                subheader={(
                    <Typography
                        color="textSecondary"
                        variant="body2"
                    >
                        Bookings count
                    </Typography>
                )}
                title={data.info}
            />
            <Scrollbar>
                <Box
                    sx={{
                        height: 336,
                        minWidth: 500,
                        px: 2
                    }}
                >
                    <Chart
                        height="300"
                        options={chartOptions}
                        series={chartSeries}
                        type="bar"
                    />
                </Box>
            </Scrollbar>
        </Card>
    );
};

export default AnalyticsBookings;
