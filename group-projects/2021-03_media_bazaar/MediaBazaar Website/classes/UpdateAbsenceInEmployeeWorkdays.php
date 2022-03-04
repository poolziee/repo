<?php
class UpdateAbsenceInEmployeeWorkdays extends Database {
    public function updateAbsence($dayIds, $employeeId, $absenceReason) {

        foreach($dayIds as $dayId){
        $sql = "UPDATE employees_workdays SET `first_shift` = 'None', `second_shift` = 'None', `absence` = 1, `absence_reason` = ? WHERE day_id = $dayId AND employee_id = ? ";

        $conn = Database::connect();
        $query = $conn->prepare($sql);
        $query->execute([$absenceReason, $employeeId]);
        $conn = null;
    }
    return true;
    }
}