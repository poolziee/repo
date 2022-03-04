<?php
error_reporting(E_ERROR | E_PARSE);
$valid_urgency_values = ['not-urgent', 'urgent'];
// DAY OFF REQUEST
if(isset($_POST['day-off-submit'])) {
    if(isset($_POST['start-day']) && DateTime::createFromFormat('Y-m-d', $_POST['start-day']) !== false && DateTime::createFromFormat('Y-m-d', $_POST['start-day']) > DateTime::createFromFormat('Y-m-d', date('Y-m-d'))) {
        $startDay = $_POST['start-day'];
        $endDay = null;

        $findDay = new FindDayByDate();

        $firstDayId = $findDay->findDay($startDay)->getId();
        $lastDayId = null;

        $correct = false;

        if(is_null($_POST['one-day-only'])) {
            // GET END DATE
            if(isset($_POST['end-day']) && DateTime::createFromFormat('Y-m-d', $_POST['end-day']) !== false && DateTime::createFromFormat('Y-m-d', $_POST['end-day']) > DateTime::createFromFormat('Y-m-d', $_POST['start-day'])) {
                $endDay = $_POST['end-day'];

                $lastDayId = $findDay->findDay($endDay)->getId();

                if($lastDayId !== false) {
                    $correct = true;
                } else {
                    errorMessage('Cannot request day off that far into the future');
                }
            } else {
                errorMessage('Invalid end date');
            }
        } else {
            $correct = true;
        }

        if($correct) {
            if(isset($_POST['urgency']) && in_array($_POST['urgency'], $valid_urgency_values)) {
                // VERIFY URGENCY VALUE, CREATE AND SUBMIT REQUEST
                $urgency;

                if($_POST['urgency'] == 'not-urgent') {
                    $urgency = 0;
                } else if($_POST['urgency'] == 'urgent') {
                    $urgency = 1;
                }

                $reason = $_POST['reason'];

                $dayOffRequest = new DayOffRequest(null, $firstDayId, $lastDayId, $_SESSION['user']->getId(), $urgency, $reason, 'pending', null, null);

                $submitRequest = new SubmitDayOffRequest();

                if($submitRequest->submitRequest($dayOffRequest) == 1) {
                    successMessage('Successfully submitted day-off request');
                } else {
                    errorMessage('An error occurred, please try again later');
                }
            } else {
                errorMessage('Invalid urgency value');
            }
        }
    } else {
        errorMessage('Invalid start date');
    }
}
// SICK REPORT
else if(isset($_POST['sick-report-submit'])) {
    if(isset($_POST['until-date']) && DateTime::createFromFormat('Y-m-d', $_POST['until-date']) !== false && DateTime::createFromFormat('Y-m-d', $_POST['until-date']) > DateTime::createFromFormat('Y-m-d', date('Y-m-d'))) {
        if(isset($_POST['symptoms']) && !empty(trim($_POST['symptoms'])) && !is_null($_POST['symptoms'])) {
            $firstDay = date('Y-m-d');
            $untilDate = $_POST['until-date'];
            $description = $_POST['symptoms'];

            $findDay = new FindDayByDate();

            $firstDayId = $findDay->findDay($firstDay)->getId();
            $lastDayId = $findDay->findDay($untilDate)->getId();

            if($firstDayId !== false && $lastDayId !== false) {
                // CHECK IF SICK REPORT ALREADY EXISTS
                $checkIfSickReportExists = new GetSickReportsInDayIDRange();
                $existingReports = $checkIfSickReportExists->getSickReportsLastDayId($firstDayId, $lastDayId, $_SESSION['user']->getId());

                if(!isset($_SESSION['existing_sick_report_last_day']) && count($existingReports) > 0) {
                    $existingReportLastDayId = $existingReports[0]['last_day_id'];
                    $findExistingReportDay = new FindDayById();

                    $existingSickReportDay = $findExistingReportDay->findDay($existingReportLastDayId);

                    if($existingSickReportDay !== false) {
                        $_SESSION['existing_sick_report_last_day'] = $existingSickReportDay->getReadableDate();
                    }
                }

                if(count($existingReports) === 0) {
                    // DAYS ARE VALID, CREATE SICK REPORT AND SUBMIT IT
                    $sickReport = new SickReport(null, $firstDayId, $lastDayId, $_SESSION['user']->getId(), $description, 0);

                    $submitSickReport = new SubmitSickReport();
                    
                    if($submitSickReport->submit($sickReport)) {
                        // SUCCESSFULLY SUBMITTED REPORT
                        // UPDATE ABSENCE IN EMPLOYEE_WORKDAYS
                        $begin = new DateTime($firstDay);
                        $end = new DateTime($untilDate);
                        $end->add(new DateInterval('P1D'));
                        $interval = new DateInterval('P1D');

                        $dateRange = new DatePeriod($begin, $interval, $end);
        
                        $days = [];
                        $dayIds = [];
                        $updateAbsenceDayIds = [];
                        $weekIds = [];
                        $dayShifts = [];
        
                        foreach($dateRange as $date){
                            $day = $findDay->findDay($date->format("Y-m-d"));
                            $id = $day->getId();
                            $weekId = $day->getWeekId();

                            if(!is_null($id)) {
                                array_push($dayIds, $id);
                            }

                            array_push($days, $day);

                            $weekIds[$id] = [];
                            array_push($weekIds[$id], $weekId);
                        }

                        $getEmployeeWorkdays = new GetEmployeeWorkdaysInRange();
                        $employeeWorkdays = $getEmployeeWorkdays->getEmployeeWorkDays($dayIds, $_SESSION['user']->getId());

                        foreach($employeeWorkdays as $day) {
                            $id = $day->getDayId();
                            $firstShift = $day->getFirstShift();
                            $secondShift = $day->getSecondShift();

                            // REMOVE DAY IDS OF DAYS WITH EMPLOYEE WORK DAY 
                            if(($key = array_search($id, $dayIds)) !== false) {
                                unset($dayIds[$key]);
                                array_push($updateAbsenceDayIds, $id);
                            }

                            $hours = 0;

                            $dayShifts[$id] = [];

                            if(strtolower($firstShift) != 'none') {
                                $hours += 4.5;
                                
                                array_push($dayShifts[$id], $firstShift);
                            }

                            if(strtolower($secondShift) != 'none') {
                                $hours += 4.5;

                                array_push($dayShifts[$id], $secondShift);
                            }

                            array_push($weekIds[$id], $hours);
                        }

                        // CREATE ABSENCE EMPLOYEE WORK DAYS FOR MISSING DAYS
                        $createSickWorkday = new CreateSickEmployeeWorkday();
                        $successfulCreationOfSickWorkdays = 0;

                        foreach($dayIds as $day) {
                            if($createSickWorkday->createWorkday($day, $_SESSION['user']->getId())) {
                                $successfulCreationOfSickWorkdays++;
                            }
                        }

                        if($successfulCreationOfSickWorkdays == count($dayIds)) {
                            $updateAbsence = new UpdateAbsenceInEmployeeWorkdays();
                            
                            if($updateAbsence->updateAbsence($updateAbsenceDayIds, $_SESSION['user']->getId(), 'Sick')) {
                                // SUCCESSFULLY UPDATED ABSENCE IN EMPLOYEE_WORKDAYS
                                // UPDATE EMPLOYEE WORKED HOURS
                                
                                $weekHours = [];

                                foreach($weekIds as $week) {
                                    $weekId = $week[0];
                                    $hours = $week[1];
            
                                    $weekHours[$weekId] += $hours;
                                }
            
                                $decreaseHours = new DecreaseEmployeeWorkedHours();
            
                                foreach($weekHours as $key => $value) {
                                    $workedHours = new WorkedHours($key, $_SESSION['user']->getId(), $value);
                                    
                                    if($value > 0) {
                                        $decreaseHours->decreaseHours($workedHours);
                                    }
                                }

                                // UPDATE ASSIGNED SHIFTS
                                $updateAssignedShifts = new UpdateAssignedShiftsInDay();
                                $successfulUpdateToShifts = 0;
            
                                foreach($days as $day) {
                                    $id = $day->getId();
                                    $position = strtolower($_SESSION['user']->getJobPosition());
                                    $value;
            
                                    if($position == 'security') {
                                        $position = 'security_assigned';
                                        $value = $day->getSecurityAssigned();
                                    } else if($position == 'cashier') {
                                        $position = 'cashiers_assigned';
                                        $value = $day->getCashiersAssigned();
                                    } else if($position == 'stocker') {
                                        $position = 'stockers_assigned';
                                        $value = $day->getStockersAssigned();
                                    } else if($position == 'salesassistant') {
                                        $position = 'sales_assistants_assigned';
                                        $value = $day->getSalesAssistantsAssigned();
                                    } else if($position == 'warehousemanager') {
                                        $position = 'warehouse_managers_assigned';
                                        $value = $day->getWarehouseManagersAssigned();
                                    }
            
                                    $values = explode(' ', $value);
            
                                    foreach($dayShifts[$id] as $shift) {
                                        if(strtolower($shift) == 'morning') {
                                            $values[0] -= 1;
                                        } else if(strtolower($shift) == 'midday') {
                                            $values[1] -= 1;
                                        } else if(strtolower($shift) == 'evening') {
                                            $values[2] -= 1;
                                        }
                                    }
            
                                    $newValue = implode(' ', $values);
            
                                    if($updateAssignedShifts->updateShift($id, $position, $newValue)) {
                                        $successfulUpdateToShifts++;   
                                    }
                                }
            
                                // CHECK IF SUBMISSION SUCCESSFUL
                                if(!empty($days) && $successfulUpdateToShifts == count($days)) {
                                    successMessage('Successfully submitted report and updated schedule');
                                    // UPDATE CURRENT SCHEDULE
                                    $updateSchedule = new UpdateCurrentSchedule();
                                    $updateSchedule->updateSchedule();
                                } 
                                else {
                                    successMessage('Successfully submitted report');
                                }
                            } else {
                                errorMessage('Could not update employee shifts, please try again later');
                            }
                        } else {
                            errorMessage('An error occurred whilst updating your workdays, please try again later');
                        }
                    } else {
                        errorMessage('An error occurred, please try again later');
                    }
                } else {
                    errorMessage("A sick report has already been submitted until {$_SESSION['existing_sick_report_last_day']}");
                }
            } else {
                errorMessage('Cannot select a date that far into the future');
            }
        } else {
            errorMessage('Please specify your symptoms');
        }
    } else {
        errorMessage('Invalid until date');
    }
}