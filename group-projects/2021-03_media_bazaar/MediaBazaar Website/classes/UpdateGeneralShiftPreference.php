<?php
class UpdateGeneralShiftPreference extends Database {
    public function updateShiftPreference($generalShiftPreference) {
        $userId = $generalShiftPreference->getUserId();
        $preference = $generalShiftPreference->getPreference();

        $sql = "UPDATE employees_preferences SET `monday` = ?, `tuesday` = ?, `wednesday` = ?, `thursday` = ?, `friday` = ?, `saturday` = ?, `sunday` = ? WHERE `employee_id` = ?";
        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$preference, $preference, $preference, $preference, $preference, $preference, $preference, $userId]);

        return $result;
    }
}