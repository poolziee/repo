<?php
class GetAnnouncements extends Database {
    public function getAllDayOffRequestAnnouncements($userId) {
        $sql = "SELECT * FROM dayoff_requests WHERE employee_id = ? AND emp_seen = 0";
        $query = Database::connect()->prepare($sql);
        $query->execute([$userId]);
        $result = $query->fetchAll(PDO::FETCH_ASSOC);

        $announcements = [];
        $findDay = new FindDayById;
        $lastDay = false;
        if($result != null){

            foreach($result as $r) {
            $firstDay = $findDay->findDay($r['first_day_id'])->getReadableDateWithoutYear();
            if($r['last_day_id'] != false){
            $lastDay = $findDay->findDay($r['last_day_id'])->getReadableDateWithoutYear();
            }

            $newAnnouncement = $r;
            $newAnnouncement['start_date'] = $firstDay;
            $newAnnouncement['end_date'] = $lastDay;

            array_push($announcements, $newAnnouncement);
        }
        }

        return $announcements;
    }
}