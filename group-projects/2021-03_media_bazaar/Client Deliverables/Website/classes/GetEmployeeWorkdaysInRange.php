<?php
class GetEmployeeWorkdaysInRange extends Database {
    public function getEmployeeWorkDays($dayIds, $employeeId) {
        $sql = "SELECT * FROM employees_workdays WHERE day_id IN (". implode(',', $dayIds) . ") AND employee_id = ?";
        $query = Database::connect()->prepare($sql);
        $query->execute([$employeeId]);

        $results = $query->fetchAll(PDO::FETCH_ASSOC);
        $count = $query->rowCount();
        $days = [];
        
        if($query != false && $count >= 1) {
            // EmployeeWorkdays Found
            foreach($results as $r) {
                $dayValues = array_values($r);
                
                $day = new EmployeeWorkday(...$dayValues);
                array_push($days, $day);
            }
        }
        return $days;
    }
}