<?php
    // LOGOUT
    if(isset($_REQUEST['logout'])) {
        header("Location: /login");
        session_destroy();
        exit();
    }
?>