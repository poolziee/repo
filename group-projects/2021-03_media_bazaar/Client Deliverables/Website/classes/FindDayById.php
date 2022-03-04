<?php
class FindDayById extends Database {
    public function findDay($dayId) {
        $sql = "SELECT * FROM days WHERE id = ?";
        $conn = Database::connect();
        if($conn != null){
        $query = $conn->prepare($sql);
        $query->execute([$dayId]);

        $result = $query->fetch(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false && $count == 1) {
            // Day Found
            $result = array_values($result);

            $day = new Day(...$result);

            return $day;
        } else {
            return false;
        }
        }
        else{
         errorMessage("Connection went down.Try again later.");
        }
       
    }
}