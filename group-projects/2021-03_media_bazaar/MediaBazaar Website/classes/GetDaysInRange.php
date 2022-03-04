<?php
class GetDaysInRange extends Database {
    public function getDays($startDate, $endDate) {
        $sql = "SELECT * FROM days WHERE date BETWEEN ? AND ?";
        $query = Database::connect()->prepare($sql);
        $query->execute([$startDate, $endDate]);

        $results = $query->fetchAll(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false && $count >= 1) {
            // Days Found
            $days = [];

            foreach($results as $r) {
                $dayValues = array_values($r);
                
                $day = new Day(...$dayValues);

                array_push($days, $day);
            }

            return $days;
        } else {
            errorMessage('Could not find days within the given range');
            return false;
        }
    }
}