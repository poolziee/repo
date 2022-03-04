<?php
$user = $_SESSION['user'];

if(isset($_POST['submit'])) {
    if(isset($_POST['current-password']) && !empty(trim($_POST['current-password'])) && !is_null($_POST['current-password'])) {
        if(isset($_POST['first-name']) && !empty(trim($_POST['first-name'])) && !is_null($_POST['first-name'])) {
            if(isset($_POST['last-name']) && !empty(trim($_POST['last-name'])) && !is_null($_POST['last-name'])) {
                $firstName = $_POST['first-name'];
                $lastName = $_POST['last-name'];
                $currentPassword = $_POST['current-password'];

                $newPassword;
                $errors = 0;

                // IF NEW PASSWORD IS SET
                if(isset($_POST['new-password']) && strlen($_POST['new-password']) > 0) {
                    if(!empty(trim($_POST['new-password'])) && !is_null($_POST['new-password'])) {
                        if(isset($_POST['confirm-new-password']) && strlen($_POST['confirm-new-password']) > 0) {
                            if($_POST['new-password'] == $_POST['confirm-new-password']) {
                                // NEW PASSWORDS MATCH
                                $newPassword = $_POST['new-password'];
                            } else {
                                errorMessage('New passwords do not match');
                                $errors++;
                            }
                        } else {
                            errorMessage('Please confirm new password');
                            $errors++;
                        }
                    } else {
                        errorMessage('New password cannot be empty');
                        $errors++;
                    }
                }

                // VERIFY CURRENT PASSWORD AND UPDATE
                if($errors == 0) {
                    if($user->getPassword() == $currentPassword) {
                        $updateEmployee = new UpdateEmployee($user);

                        if(!is_null($newPassword) && !empty($newPassword)) {
                            // UPDATE WITH NEW PASSWORD
                            if($updateEmployee->updateUserWithNewPassword($firstName, $lastName, $newPassword) == 1) {
                                successMessage('Successfully updated account info');
                                redirect_to('/dashboard');
                            } else {
                                errorMessage('An error occurred, please try again later');
                            }
                        } else {
                            // UPDATE WITHOUT NEW PASSWORD
                            if($updateEmployee->updateUser($firstName, $lastName) == 1) {
                                successMessage('Successfully updated account info');
                                redirect_to('/dashboard');
                            } else {
                                errorMessage('An error occurred, please try again later');
                            }
                        }
                    } else {
                        errorMessage('Current password is incorrect');
                    }
                }
            } else {
                errorMessage('Last name cannot be empty');
            }
        } else {
            errorMessage('First name cannot be empty');
        }
    } else {
        errorMessage('Please enter your current password');
    }
}