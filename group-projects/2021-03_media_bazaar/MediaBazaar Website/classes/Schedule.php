<?php
class Schedule extends Database {
    private $id;
    private $start_date;
    private $end_date;
    private $is_outdated;
    private $days;
    private $work_days;

    public function __construct($id, $start_date, $end_date, $is_outdated) {
        $this->id = $id;
        $this->start_date = $start_date;
        $this->end_date = $end_date;
        $this->is_outdated = $is_outdated;
        $this->days = [];
        $this->work_days = [];
    }

    public function getStartDate() {
        return $this->start_date;
    }

    public function getEndDate() {
        return $this->end_date;
    }

    public function getDays() {
        return $this->days;
    }

    public function getDayIds() {
        $ids = [];

        foreach($this->days as $day) {
            array_push($ids, $day->getId());
        }

        return $ids;
    }

    public function getWeekIds() {
        $ids = [];

        foreach($this->days as $day) {
            $weekId = $day->getWeekId();

            if(!in_array($weekId, $ids)) {
                array_push($ids, $weekId);
            }
        }

        return $ids;
    }
    
    public function getWorkDays() {
        return $this->work_days;
    }

    public function addDay($day) {
        array_push($this->days, $day);
    }

    public function addWorkDay($workDay) {
        array_push($this->work_days, $workDay);
    }
}