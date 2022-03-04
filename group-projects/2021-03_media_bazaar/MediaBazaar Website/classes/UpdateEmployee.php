<?php
class UpdateEmployee extends Database {
    private $user_id;

    public function __construct($employee) {
        $this->user_id = $employee->getId();
    }

    public function updateUser($firstName, $lastName) {
        $sql = "UPDATE employees SET `first_name` = ?, `last_name` = ? WHERE `id` = ?";
        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$firstName, $lastName, $this->user_id]);

        $this->updateUserSessionInfo([$firstName, $lastName]);

        return $result;
    }

    public function updateUserWithNewPassword($firstName, $lastName, $newPassword) {
        $sql = "UPDATE employees SET `first_name` = ?, `last_name` = ?, `password` = ? WHERE `id` = ?";
        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$firstName, $lastName, $newPassword, $this->user_id]);

        $this->updateUserSessionInfo([$firstName, $lastName, $newPassword]);

        return $result;
    }

    private function updateUserSessionInfo($attributes) {
        $_SESSION['user']->setFirstName($attributes[0]);
        $_SESSION['user']->setLastName($attributes[1]);
        
        if(count($attributes) == 3) {
            // UPDATE PASSWORD AS WELL
            $_SESSION['user']->setPassword($attributes[2]);
        }
    }
}