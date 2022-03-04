<?php
class SickReport extends Database {
    private $id;
    private $first_day_id;
    private $last_day_id;
    private $employee_id;
    private $description;
    private $hr_seen;

    public function __construct($id, $first_day_id, $last_day_id, $employee_id, $description, $hr_seen) {
        $this->id = $id;
        $this->first_day_id = $first_day_id;
        $this->last_day_id = $last_day_id;
        $this->employee_id = $employee_id;
        $this->description = $description;
        $this->hr_seen = $hr_seen;
    }

    public function getFirstDayId() {
        return $this->first_day_id;
    }

    public function getLastDayId() {
        return $this->last_day_id;
    }

    public function getEmployeeId() {
        return $this->employee_id;
    }

    public function getDescription() {
        return $this->description;
    }
}