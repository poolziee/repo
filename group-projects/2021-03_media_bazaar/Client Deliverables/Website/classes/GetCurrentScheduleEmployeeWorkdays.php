<?php
class GetCurrentScheduleEmployeeWorkdays extends Database {
    public function getWorkdays($employeeId, $schedule) {
        $dayIds = $schedule->getDayIds();        

        $sql = "SELECT * FROM employees_workdays WHERE day_id IN (". implode(',', $dayIds) . ") AND employee_id = ?";
        $query = Database::connect()->prepare($sql);
        $query->execute([$employeeId]);

        $results = $query->fetchAll(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false) {
            // WorkDays Found
            $workDays = [];

            foreach($results as $r) {
                $workDayValues = array_values($r);

                $workDay = new EmployeeWorkday(...$workDayValues);
                array_push($workDays, $workDay);
            }

            return $workDays;
        } else {
            errorMessage('An error occurred, please try again later');
            return false;
        }
    }
}