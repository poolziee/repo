<?php
class GetSickReportsInDayIDRange extends Database {
    public function getSickReportsLastDayId($firstDayId, $lastDayId, $employeeId) {
        $sql = "SELECT last_day_id FROM sick_reports WHERE first_day_id BETWEEN ? AND ? AND employee_id = ?";
        $query = Database::connect()->prepare($sql);
        $query->execute([$firstDayId, $lastDayId, $employeeId]);

        $results = $query->fetchAll();
        return $results;
    }
}