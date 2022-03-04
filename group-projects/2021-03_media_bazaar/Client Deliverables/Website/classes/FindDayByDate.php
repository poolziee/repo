<?php
class FindDayByDate extends Database {
    public function findDay($date) {
        $sql = "SELECT * FROM days WHERE date = ?";
        $query = Database::connect()->prepare($sql);
        $query->execute([$date]);

        $result = $query->fetch(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false && $count == 1) {
            // Day Found
            $result = array_values($result);

            $day = new Day(...$result);

            return $day;
        } else {
            errorMessage('No day was found with given date');
            return false;
        }
    }
}