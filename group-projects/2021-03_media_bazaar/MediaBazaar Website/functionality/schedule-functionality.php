<?php
$begin = new DateTime($_SESSION['schedule']->getStartDate());
$end = new DateTime($_SESSION['schedule']->getEndDate());
$end->add(new DateInterval('P1D'));
$interval = new DateInterval('P1D');

$dateRange = new DatePeriod($begin, $interval, $end);

$scheduleDaysWeekOne = [];
$scheduleDaysWeekTwo = [];

$weekOneId = $_SESSION['schedule']->getWeekIds()[0];
$weekTwoId = $_SESSION['schedule']->getWeekIds()[1];

$scheduleWorkdayDayIdShifts = [];

foreach($_SESSION['schedule']->getWorkdays() as $workDay) {
    $scheduleWorkdayDayIdShifts[$workDay->getDayId()] = $workDay->getShiftsString();
}

$scheduleWorkdayDayIds = array_keys($scheduleWorkdayDayIdShifts);

$findDay = new FindDayByDate();

foreach($dateRange as $date){
    $day = $findDay->findDay($date->format("Y-m-d"));
    $dayId = $day->getId();
    $weekId = $day->getWeekId();

    $pos = array_search($dayId, $scheduleWorkdayDayIds);

    if($weekId == $weekOneId) {
        $scheduleDaysWeekOne[$dayId] = [];

        array_push($scheduleDaysWeekOne[$dayId], $day);

        if($pos !== false) {
            array_push($scheduleDaysWeekOne[$dayId], $scheduleWorkdayDayIdShifts[$dayId]);
        }
    } else if($weekId == $weekTwoId) {
        $scheduleDaysWeekTwo[$dayId] = [];

        array_push($scheduleDaysWeekTwo[$dayId], $day);

        if($pos !== false) {
            array_push($scheduleDaysWeekTwo[$dayId], $scheduleWorkdayDayIdShifts[$dayId]);
        }
    }
}

// var_dump($_SESSION['schedule']->getEndDate());