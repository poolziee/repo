<?php
class UpdateSpecificShiftPreference extends Database {
    public function updateShiftPreference($specificShiftPreference) {
        $userId = $specificShiftPreference->getUserId();
        $preference = $specificShiftPreference->getPreference();
        $day = $specificShiftPreference->getDayOfWeek();

        $sql;

        if($day == 'monday') {
            $sql = "UPDATE employees_preferences SET `monday` = ? WHERE `employee_id` = ?";
        } else if($day == 'tuesday') {
            $sql = "UPDATE employees_preferences SET `tuesday` = ? WHERE `employee_id` = ?";
        } else if($day == 'wednesday') {
            $sql = "UPDATE employees_preferences SET `wednesday` = ? WHERE `employee_id` = ?";
        } else if($day == 'thursday') {
            $sql = "UPDATE employees_preferences SET `thursday` = ? WHERE `employee_id` = ?";
        } else if($day == 'friday') {
            $sql = "UPDATE employees_preferences SET `friday` = ? WHERE `employee_id` = ?";
        } else if($day == 'saturday') {
            $sql = "UPDATE employees_preferences SET `saturday` = ? WHERE `employee_id` = ?";
        } else if($day == 'sunday') {
            $sql = "UPDATE employees_preferences SET `sunday` = ? WHERE `employee_id` = ?";
        }

        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$preference, $userId]);

        return $result;
    }
}