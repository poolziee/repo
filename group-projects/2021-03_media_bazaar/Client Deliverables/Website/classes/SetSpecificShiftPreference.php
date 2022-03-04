<?php
class SetSpecificShiftPreference extends Database {

    private function IsSet($userId){
         $sql = "SELECT * FROM employees_preferences WHERE employee_id = ? ";
         $query = Database::connect()->prepare($sql);
         $result = $query->execute([$userId]);
         if($result == null){
             return false;
         }
         return true;
    }

    public function setShiftPreference($specificShiftPreference) {
        $userId = $specificShiftPreference->getUserId();
        $preference = $specificShiftPreference->getPreference();
        $day = $specificShiftPreference->getDayOfWeek();
        
        if(!IsSet($userId)){
         $sql;

        if($day == 'monday') {
            $sql = "INSERT INTO employees_preferences (employee_id, monday) VALUES (?, ?)";
        } else if($day == 'tuesday') {
            $sql = "INSERT INTO employees_preferences (employee_id, tuesday) VALUES (?, ?)";
        } else if($day == 'wednesday') {
            $sql = "INSERT INTO employees_preferences (employee_id, wednesday) VALUES (?, ?)";
        } else if($day == 'thursday') {
            $sql = "INSERT INTO employees_preferences (employee_id, thursday) VALUES (?, ?)";
        } else if($day == 'friday') {
            $sql = "INSERT INTO employees_preferences (employee_id, friday) VALUES (?, ?)";
        } else if($day == 'saturday') {
            $sql = "INSERT INTO employees_preferences (employee_id, saturday) VALUES (?, ?)";
        } else if($day == 'sunday') {
            $sql = "INSERT INTO employees_preferences (employee_id, sunday) VALUES (?, ?)";
        }

        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$userId, $preference]);

        return $result;
        }
        return 0;
    }
}