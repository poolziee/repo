<?php
class SetGeneralShiftPreference extends Database {

    private function IsSet($userId){
         $sql = "SELECT * FROM employees_preferences WHERE employee_id = ? ";
         $query = Database::connect()->prepare($sql);
         $result = $query->execute([$userId]);
         if($result == null){
             return false;
         }
         return true;
    }
    public function setShiftPreference($generalShiftPreference) {
        $userId = $generalShiftPreference->getUserId();
        $preference = $generalShiftPreference->getPreference();
         
        if(!IsSet($userId)){
         $sql = "INSERT INTO employees_preferences (employee_id, monday, tuesday, wednesday, thursday, friday, saturday, sunday) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$userId, $preference, $preference, $preference, $preference, $preference, $preference, $preference]);

        return $result;
        }
        return 0;
    }
}