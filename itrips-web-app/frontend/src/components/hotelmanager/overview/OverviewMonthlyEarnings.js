import Chart from 'react-apexcharts';
import numeral from 'numeral';
import {
    Avatar,
    Box,
    Card,
    CardContent,
    Typography
} from '@material-ui/core';
import {alpha, useTheme} from '@material-ui/core/styles';
import ChevronDownIcon from '../../../icons/ChevronDown';

const OverviewMonthlyEarnings = (props) => {
    const theme = useTheme();
    const {earnings} = props;

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
        <Card {...props}>
            <CardContent
                sx={{
                    display: 'flex',
                    alignItems: 'center'
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
                            color="textPrimary"
                            variant="h4"
                        >
                            {numeral(earnings.revenue).format('$0,0.00')}
                        </Typography>
                        <Typography
                            color="textPrimary"
                            sx={{mt: 1}}
                            variant="subtitle2"
                        >
                            Monthly revenue
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
                            backgroundColor: alpha(theme.palette.error.main, 0.08),
                            color: 'error.main'
                        }}
                        variant="rounded"
                    >
                        <ChevronDownIcon fontSize="small"/>
                    </Avatar>
                </Box>
            </CardContent>
        </Card>
    );
};

export default OverviewMonthlyEarnings;
