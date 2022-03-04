<?php
    // AUTOLOAD REQUIRED CLASSES
    spl_autoload_register(function($class) {
        include('./classes/' . $class . '.php');
    });

    require_once('initialize.php');

    // INCLUDE REQUIRED FUNCTIONALITY FILES
    require_once('functionality/redirect-functionality.php');
    require_once('functionality/logout-functionality.php');

    if(!empty($functionalityRequirements)) {
        foreach($functionalityRequirements as $functionality) {
            require_once('functionality/' . $functionality . '.php');
        }
    }

    $user = null;
    $position = "";

    if(!empty($_SESSION['user'])){

     $user = $_SESSION['user'];
     $position = 'ceo';
     if($user != 'ceo'){
     $position = $user->getJobPosition();
     }
    }
    
    if($position == "HRManager" && $page == 'dashboard'){
        redirect_to('/account');
    }
    else if($position == "ceo" && $page == 'dashboard'){
        redirect_to('/stats_ceo_expenses');
    }
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>MediaBazaar: Dashboard</title>
    <!-- GOOGLE FONTS -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@300;400;600;700&display=swap" rel="stylesheet">
    <!-- IONICONS -->
    <script type="module" src="https://unpkg.com/ionicons@5.4.0/dist/ionicons/ionicons.esm.js"></script>
    <script nomodule="" src="https://unpkg.com/ionicons@5.4.0/dist/ionicons/ionicons.js"></script>
    <!-- CSS IMPORTS -->
    <link rel="stylesheet" href="../css/essentials.css" type="text/css">
    <?php
        if($page == 'dashboard') {
    ?>
        <link rel="stylesheet" href="../css/dashboard.css" type="text/css">
    <?php
        }
    ?>
    <?php
        if($position == 'HRManager' || $position == 'WarehouseManager' || $position == 'ceo' ) {
    ?>
        <link rel="stylesheet" href="../css/statistics.css" type="text/css">
    <?php
   }
    ?>
</head>
<body>
<!-- BODY WRAPPER -->
<div id="body-wrapper">
    <!-- ERROR MESSAGES -->
    <div id="messages-container">
        <ul id="success-messages">
            <?php 
                if(!empty($_SESSION['successMessages'])) {
                    foreach($_SESSION['successMessages'] as $message) {
            ?>
                    <li>
                        <p><?php echo $message; ?></p>
                        <i><ion-icon name="close-outline"></ion-icon></i>
                    </li>
            <?php
                    }
                    $_SESSION['successMessages'] = [];
                }
            ?>
        </ul>
        <ul id="error-messages">
            <?php 
                if(!empty($_SESSION['errorMessages'])) {
                    foreach($_SESSION['errorMessages'] as $message) {
            ?>
                    <li>
                        <p><?php echo $message; ?></p>
                        <i><ion-icon name="close-outline"></ion-icon></i>
                    </li>
            <?php
                    }
                    $_SESSION['errorMessages'] = [];
                }
            ?>
        </ul>
    </div>
    <!-- TOP NAV -->
    <nav id="top-nav">
    <?php 
    if($position != null){

      if($position == "WarehouseManager"){

      include("navbar/whmanager_navbar.php");
      }
      else if($position == "HRManager"){

      include("navbar/hrmanager_navbar.php");
      }
      else if($position =="ceo"){
          include("navbar/ceo_navbar.php");
      }
      else{
          include("navbar/employee_navbar.php");
      }

    }

      else{
        ?>
         <a href="/login" id="logo"><span>Media</span>Bazaar</a>
            <ul>
                <li>
                    <a href="/login" id="top-nav-sign-in-button">Sign In</a>
                </li>
            </ul>
        <?php
    }
        ?>
    </nav>