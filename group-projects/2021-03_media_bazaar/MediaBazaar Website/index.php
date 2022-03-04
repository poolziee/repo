<?php
    $page = 'index';
    $content = '';
    require_once('includes/header.php');

    if(empty($_SESSION['user_id'])) {
        header("Location: /login");
    } else {
        header("Location: /dashboard");
    }
?>