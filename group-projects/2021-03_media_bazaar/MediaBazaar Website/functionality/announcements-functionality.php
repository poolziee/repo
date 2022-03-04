<?php
// GET ALL ANNOUNCEMENTS
$getAnnouncements = new GetAnnouncements;
$announcements = $getAnnouncements->getAllDayOffRequestAnnouncements($_SESSION['user']->getId());

// DISMISS (DELETE) ANNOUNCEMENT FUNCTIONALITY
if(isset($_GET['aId'])) {
    if(isset($_GET['aText'])) {
        $id = $_GET['aId'];
        $text = $_GET['aText'];

        echo $id;
        echo $text;

        $announcement = new Announcement($id, $text, $_SESSION['user']->getId());
        $dismissAnnouncement = new DismissAnnouncement;

        if($dismissAnnouncement->dismiss($announcement)) {
            echo 'true';
        } else {
            echo 'false';
        }
    }
}