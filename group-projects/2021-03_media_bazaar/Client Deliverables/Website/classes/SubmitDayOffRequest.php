<?php
class SubmitDayOffRequest extends Database {
    public function submitRequest($dayOffRequest) {
        $firstDayId = $dayOffRequest->getFirstDayId();
        $lastDayId = $dayOffRequest->getLastDayId();
        $employeeId = $dayOffRequest->getEmployeeId();
        $urgent = $dayOffRequest->getUrgentStatus();
        $reason = $dayOffRequest->getReason();
        $status = $dayOffRequest->getStatus();

        $sql = "INSERT INTO dayoff_requests (first_day_id, last_day_id, employee_id, urgent, reason, status) VALUES (?, ?, ?, ?, ?, ?)";
        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$firstDayId, $lastDayId, $employeeId, $urgent, $reason, $status]);

        return $result;
    }
}