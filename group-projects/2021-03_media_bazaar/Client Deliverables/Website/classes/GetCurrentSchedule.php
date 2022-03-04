<?php
class GetCurrentSchedule extends Database {
    function getSchedule($date) {
        $sql = "SELECT * FROM schedules WHERE start_date <= ? AND end_date >= ?";
        $query = Database::connect()->prepare($sql);
        $query->execute([$date, $date]);

        $result = $query->fetch(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false && $count == 1) {
            // Schedule Found
            $result = array_values($result);

            $schedule = new Schedule(...$result);

            $_SESSION['schedule'] = $schedule;

            return $schedule;
        } else {
            errorMessage('Could not find current schedule, please contact your HR manager');
            return false;
        }
    }
}