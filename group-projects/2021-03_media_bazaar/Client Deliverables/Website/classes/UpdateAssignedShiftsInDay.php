<?php
class UpdateAssignedShiftsInDay extends Database {
    public function updateShift($dayId, $position, $value) {
        $sql;

        if($position == 'security_assigned') {
            $sql = "UPDATE days SET security_assigned = ? WHERE `id` = ?";    
        } else if($position == 'cashiers_assigned') {
            $sql = "UPDATE days SET cashiers_assigned = ? WHERE `id` = ?";    
        } else if($position == 'stockers_assigned') {
            $sql = "UPDATE days SET stockers_assigned = ? WHERE `id` = ?";    
        } else if($position == 'sales_assistants_assigned') {
            $sql = "UPDATE days SET sales_assistants_assigned = ? WHERE `id` = ?";    
        } else if($position == 'warehouse_managers_assigned') {
            $sql = "UPDATE days SET warehouse_managers_assigned = ? WHERE `id` = ?";    
        }

        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$value, $dayId]);

        return $result;
    }
}