import Chart from 'react-apexcharts';
import {Card, CardContent, CardHeader} from '@material-ui/core';
import {useTheme} from '@material-ui/core/styles';
import numeral from "numeral";

const currency = '$';
const OverviewBookingsRevenue = (props) => {
    const {data} = props;

    const theme = useTheme();

    const chartOptions = {
        chart: {
            background: 'transparent',
            stacked: false,
            toolbar: {
                show: false
            }
        },
        dataLabels: {
            enabled: false
        },
        fill: {
            type: 'solid',
            opacity: 0
        },
        grid: {
            borderColor: theme.palette.divider
        },
        markers: {
            strokeColors: theme.palette.background.paper,
            size: 6
        },
        stroke: {
            curve: 'straight',
            width: 2
        },
        theme: {
            mode: theme.palette.mode
        },
        xaxis: {
            axisBorder: {
                color: theme.palette.divider,
                show: true
            },
            axisTicks: {
                color: theme.palette.divider,
                show: true
            },
            categories: data.months
        },
        yaxis: {
            labels: {
                formatter: function (value) {
                    return numeral(value).format(`${currency}0,0`);
                }
            },
        }
    };

    const chartSeries = data.series;

    return (
        <Card {...props}>
            <CardHeader title="Bookings Revenue"/>
            <CardContent>
                <Chart
                    height="360"
                    options={chartOptions}
                    series={chartSeries}
                    type="area"
                />
            </CardContent>
        </Card>
    );
};

export default OverviewBookingsRevenue;
