<?php
class WorkedHours extends Database {
    private $week_id;
    private $employee_id;
    private $hours;

    public function __construct($week_id, $employee_id, $hours) {
        $this->week_id = $week_id;
        $this->employee_id = $employee_id;
        $this->hours = $hours;
    }

    public function getWeekId() {
        return $this->week_id;
    }

    public function getEmployeeId() {
        return $this->employee_id;
    }

    public function getHours() {
        return $this->hours;
    }
}