<?php
    // START SESSION AND INCLUDE REQUIRED FILES
    session_start();

    require_once('helper-methods.php');

    // SET UP SUCCESS / ERROR MESSAGES
    if(!isset($_SESSION['successMessages'])) {
        $_SESSION['successMessages'] = [];
    }

    if(!isset($_SESSION['errorMessages'])) {
        $_SESSION['errorMessages'] = [];
    }
?>