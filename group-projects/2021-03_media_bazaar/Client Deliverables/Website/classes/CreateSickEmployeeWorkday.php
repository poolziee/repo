<?php
class CreateSickEmployeeWorkday extends Database {
    public function createWorkday($dayId, $employeeId) {
        $sql = "INSERT INTO employees_workdays (day_id, employee_id, first_shift, second_shift, absence, absence_reason) VALUES (?, ?, 'None', 'None', 1, 'Sick')";
        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$dayId, $employeeId]);

        return $result;
    }
}