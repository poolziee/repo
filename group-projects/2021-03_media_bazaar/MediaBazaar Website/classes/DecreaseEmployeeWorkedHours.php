<?php
class DecreaseEmployeeWorkedHours extends Database {
    public function decreaseHours($workedHours) {
        $week_id = $workedHours->getWeekId();
        $employee_id = $workedHours->getEmployeeId();
        $hours = $workedHours->getHours();

        $sql = "UPDATE worked_hours SET `hours` = `hours` - ? WHERE `week_id` = ? AND `employee_id` = ?";
        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$hours, $week_id, $employee_id]);

        return $result;
    }
}