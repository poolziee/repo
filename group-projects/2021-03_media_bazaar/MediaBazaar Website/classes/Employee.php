<?php
class Employee extends Database {
    private $id;
    private $first_name;
    private $last_name;
    private $birth_date;
    private $email;
    private $password;
    private $job_position;
    private $phone_number;
    private $address;
    private $salary;
    private $gender;
    private $education;
    private $contract;
    private $days_off;
    private $contract_hours;
    private $notes;

    public function __construct($id, $first_name, $last_name, $birth_date, $email, $password, $job_position, $phone_number, $address, $salary, $gender, $education, $contract, $days_off, $contract_hours, $notes) {
        $this->id = $id;
        $this->first_name = $first_name;
        $this->last_name = $last_name;
        $this->birth_date = $birth_date;
        $this->email = $email;
        $this->password = $password;
        $this->job_position = $job_position;
        $this->phone_number = $phone_number;
        $this->address = $address;
        $this->salary = $salary;
        $this->gender = $gender;
        $this->education = $education;
        $this->contract = $contract;
        $this->days_off = $days_off;
        $this->contract_hours = $contract_hours;
        $this->notes = $notes;
    }

    public function getId() {
        return $this->id;
    }

    public function getFirstName() {
        return $this->first_name;
    }

    public function getLastName() {
        return $this->last_name;
    }

    public function getGender() {
        return $this->gender;
    }

    public function getBirthDate() {
        return $this->birth_date;
    }

    public function getEmail() {
        return $this->email;
    }

    public function getPassword() {
        return $this->password;
    }

    public function getJobPosition() {
        return $this->job_position;
    }

    public function setFirstName($firstName) {
        $this->first_name = $firstName;
    }

    public function setLastName($lastName) {
        $this->last_name = $lastName;
    }

    public function setPassword($password) {
        $this->password = $password;
    }
}