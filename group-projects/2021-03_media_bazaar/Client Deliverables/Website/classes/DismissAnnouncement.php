<?php
class DismissAnnouncement extends Database {
    public function dismiss($announcement) {
        $id = $announcement->getId();
        $userId = $announcement->getUserId();

        $sql = "UPDATE dayoff_requests SET `emp_seen` = 1 WHERE request_id = ? AND employee_id = ?";
        $query = Database::connect()->prepare($sql);

        $result = $query->execute([$id, $userId]);

        return $result;
    }
}