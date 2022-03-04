<?php
class DayOffRequest extends Database {
    private $id;
    private $firstDayId;
    private $lastDayId;
    private $employeeId;
    private $urgent;
    private $reason;
    private $status;
    private $objection;
    private $empSeen;

    public function __construct($id, $firstDayId, $lastDayId, $employeeId, $urgent, $reason, $status, $objection, $empSeen) {
        $this->id = $id;
        $this->firstDayId = $firstDayId;
        $this->lastDayId = $lastDayId;
        $this->employeeId = $employeeId;
        $this->urgent = $urgent;
        $this->reason = $reason;
        $this->status = $status;
        $this->objection = $objection;
        $this->empSeen = $empSeen;
    }

    public function getId() {
        return $this->id;
    }

    public function getFirstDayId() {
        return $this->firstDayId;
    }

    public function getLastDayId() {
        return $this->lastDayId;
    }

    public function getEmployeeId() {
        return $this->employeeId;
    }

    public function getUrgentStatus() {
        return $this->urgent;
    }

    public function getReason() {
        return $this->reason;
    }

    public function getStatus() {
        return $this->status;
    }

    public function getObjection() {
        return $this->objection;
    }

    public function getEmpSeen() {
        return $this->empSeen;
    }
}