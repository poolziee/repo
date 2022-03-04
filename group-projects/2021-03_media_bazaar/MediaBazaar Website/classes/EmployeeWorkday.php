<?php
class EmployeeWorkday extends Database {
    private $day_id;
    private $employee_id;
    private $first_shift;
    private $second_shift;
    private $absence;
    private $absence_reason;

    public function __construct($day_id, $employee_id, $first_shift, $second_shift, $absence, $absence_reason) {
        $this->day_id = $day_id;
        $this->employee_id = $employee_id;
        $this->first_shift = $first_shift;
        $this->second_shift = $second_shift;
        $this->absence = $absence;
        $this->absence_reason = $absence_reason;
    }

    public function getDayId() {
        return $this->day_id;
    }

    public function getFirstShift() {
        return $this->first_shift;
    }

    public function getSecondShift() {
        return $this->second_shift;
    }

    public function getShiftsString() {
        $str = "";

        if(strtolower($this->first_shift) != 'none') {
            $str .= $this->first_shift;
        }

        if(strtolower($this->second_shift) != 'none') {
            $str .= " & " . $this->second_shift;
        }

        return $str;
    }
}