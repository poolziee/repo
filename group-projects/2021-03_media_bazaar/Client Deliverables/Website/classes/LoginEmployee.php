<?php
class LoginEmployee extends Database {
    public function login($email, $password) {
        $sql = "SELECT * FROM employees WHERE email = ?";
        $query = Database::connect()->prepare($sql);
        $query->execute([$email]);

        $result = $query->fetch(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false) {
            if($count === 1) {
                // User found
                if($result['password'] === $password) {
                    // Correct password
                    $result = array_values($result);

                    $user = new Employee(...$result);

                    $_SESSION['user'] = $user;
                    
                    return true;
                } else {
                    errorMessage('Incorrect password');
                    return false;
                }
            } else {
                errorMessage('Could not find employee with provided email');
                return false;
            }
        } else {
            errorMessage('An error occurred, please try again later');
            return false;
        }
    }
}