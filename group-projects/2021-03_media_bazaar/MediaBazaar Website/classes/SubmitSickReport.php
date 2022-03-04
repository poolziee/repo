<?php
class SubmitSickReport extends Database {
    public function submit($sickReport) {
        $firstDayId = $sickReport->getFirstDayId();
        $lastDayId = $sickReport->getLastDayId();
        $employeeId = $sickReport->getEmployeeId();
        $description = $sickReport->getDescription();

        $sql = "INSERT INTO sick_reports (first_day_id, last_day_id, employee_id, description) VALUES (?, ?, ?, ?)";
        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$firstDayId, $lastDayId, $employeeId, $description]);

        return $result;
    }
}