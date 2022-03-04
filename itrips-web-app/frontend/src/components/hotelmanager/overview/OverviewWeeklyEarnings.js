import Chart from 'react-apexcharts';
import {
    Avatar,
    Box,
    Card,
    CardContent,
    Typography
} from '@material-ui/core';
import {alpha, useTheme} from '@material-ui/core/styles';
import ChevronUpIcon from '../../../icons/ChevronUp';
import numeral from "numeral";

const currency = "$";
const OverviewWeeklyEarnings = (props) => {
    const theme = useTheme();
    const {earnings, ...other} = props;

    const chartOptions = {
        chart: {
            background: 'transparent',
            stacked: false,
            toolbar: {
                show: false
            }
        },
        colors: ['#27c6db'],
        labels: [''],
        plotOptions: {
            radialBar: {
                dataLabels: {
                    value: {
                        show: false
                    }
                },
                hollow: {
                    size: '60%'
                },
                track: {
                    background: theme.palette.background.default
                }
            }
        },
        theme: {
            mode: theme.palette.mode
        }
    };

    const chartSeries = [83];

    return (
        <Card {...other}>
            <CardContent
                sx={{
                    alignItems: 'center',
                    display: 'flex'
                }}
            >
                <Chart
                    height="160"
                    options={chartOptions}
                    series={chartSeries}
                    type="radialBar"
                    width="160"
                />
                <Box
                    sx={{
                        display: 'flex',
                        flex: 1
                    }}
                >
                    <div>
                        <Typography
                            color="primary"
                            variant="h4"
                        >
                            {numeral(earnings.revenue)
                                .format(`${currency}0,0.00`)}
                        </Typography>
                        <Typography
                            color="textPrimary"
                            sx={{mt: 1}}
                            variant="subtitle2"
                        >
                            Weekly revenue
                        </Typography>
                        <Typography
                            color="textSecondary"
                            sx={{mt: 1}}
                            variant="subtitle2"
                        >
                            From {earnings.from} Until {earnings.until}
                        </Typography>
                    </div>
                    <Box sx={{flexGrow: 1}}/>
                    <Avatar
                        sx={{
                            backgroundColor: alpha(theme.palette.success.main, 0.08),
                            color: 'success.main'
                        }}
                        variant="rounded"
                    >
                        <ChevronUpIcon fontSize="small"/>
                    </Avatar>
                </Box>
            </CardContent>

        </Card>
    );
};

export default OverviewWeeklyEarnings;
