<?php
class Announcement extends Database {
    private $id;
    private $text;
    private $user_id;

    public function __construct($id, $text, $user_id) {
        $this->id = $id;
        $this->text = $text;
        $this->user_id = $user_id;
    }

    public function getId() {
        return $this->id;
    }

    public function getText() {
        return $this->text;
    }

    public function getUserId() {
        return $this->user_id;
    }
}