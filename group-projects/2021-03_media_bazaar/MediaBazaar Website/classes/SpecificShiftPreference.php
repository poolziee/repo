<?php
class SpecificShiftPreference extends ShiftPreference {
    private $dayOfWeek;

    public function __construct($userId, $preference, $dayOfWeek) {
        parent::__construct($userId, $preference);

        $this->dayOfWeek = $dayOfWeek;
    }

    public function getDayOfWeek() {
        return $this->dayOfWeek;
    }
}