<?php
class HRStatisticsManager extends Database{

    //HR MANAGER DEPARTMENTS
    
    function GetAverageSalaryPerDepartment(){
         $conn = null;
     try{
        $sql = "SELECT job_position as Department, ROUND(AVG(salary)) as Average FROM employees WHERE job_position != 'HRManager' GROUP BY job_position";
        
        $conn =  Database::connect();
        $query = $conn->prepare($sql);
        $query->execute();
        $result = $query->fetchAll(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false) {
           
            $result = array_values($result);
            return $result;
        }
     }
     finally{
         if($conn != null){
             $conn = null;
         }
     }
        
        
    }

     public function GetHoursPerMonth(){
        $conn = null;
     try{
        $sql = "SELECT MONTH(d.date) as Month, SUM(hours) as Hours
                FROM worked_hours wh
                INNER JOIN weeks_months d ON wh.week_id = d.week_id
                GROUP BY MONTH(d.date)";

        $conn =  Database::connect();
        $query = $conn->prepare($sql);
        $query->execute();
        $result = $query->fetchAll(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false) {
           return $result;
        }
     }
     finally{
         if($conn != null){
             $conn = null;
         }
     }
        
    }

    public function GetHoursPerDepartmentForYear(){
        $conn = null;
     try{
        $sql = "SELECT e.job_position as Department, SUM(hours) as Hours FROM worked_hours wh 
        INNER JOIN employees e on wh.employee_id = e.id 
        GROUP BY e.job_position";

        $conn =  Database::connect();
        $query = $conn->prepare($sql);
        $query->execute();
        $result = $query->fetchAll(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false) {
           return $result;
        }
     }
     finally{
         if($conn != null){
             $conn = null;
         }
     }
        
    }

    public function GetHoursPerDepartmentPerMonth(){
          $conn = null;
     try{
        $sql = "SELECT MONTH(d.date) as Month, e.job_position as Department, SUM(hours) as Hours
        FROM worked_hours wh INNER JOIN employees e on wh.employee_id = e.id 
        INNER JOIN weeks_months d ON wh.week_id = d.week_id
        GROUP BY e.job_position , MONTH(d.date)";
        
        $conn =  Database::connect();
        $query = $conn->prepare($sql);
        $query->execute();
        $result = $query->fetchAll(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false) {
           
            $result = array_values($result);
            return $result;
        }
     }
     finally{
         if($conn != null){
             $conn = null;
         }
     }
        

    }

        //HR MANAGER EMPLOYEES
      public function GetTopEmployeesPerDepartment(){

        $res = [];
        $depts = ['Cashier','SalesAssistant','Security','Stocker','WarehouseManager'];
        $conn = null;
        foreach($depts as $position){
        try{
        $sql = "SELECT e.job_position as Department, CONCAT( e.first_name, ' ', e.last_name ) AS Employee , SUM(hours) as Hours FROM worked_hours wh INNER JOIN employees e ON wh.employee_id = e.id WHERE e.job_position = ? GROUP BY e.id  ORDER BY SUM(hours) DESC LIMIT 1 ";
        
        $conn =  Database::connect();
        $query = $conn->prepare($sql);
        $query->execute([$position]);
        $result = $query->fetch(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false) {
           
            array_push($res, $result);
        }
     }

     finally{
         if($conn != null){
             $conn = null;
         }
     }
        
    }
     return $res;
    }


    function GetTopEmployeesPerDepartmentPerMonth(){

       $res = [];
        $depts = ["Cashier","SalesAssistant","Security","Stocker","WarehouseManager"];
        $conn = null;
        foreach($depts as $position){
            for($i = 1; $i <= 12; $i++){
                 try{
        $sql = "SELECT MONTH(whd.date) as Month , e.job_position as Department , CONCAT( e.first_name, ' ', e.last_name ) AS Employee , SUM(wh.hours) as Hours
FROM worked_hours wh INNER JOIN employees e ON wh.employee_id = e.id
INNER JOIN weeks_months whd ON wh.week_id = whd.week_id
WHERE  e.job_position = '$position' AND MONTH(whd.date) = $i
GROUP BY wh.employee_id
ORDER BY SUM(wh.hours) DESC LIMIT 3";
        $conn =  Database::connect();
        $query = $conn->prepare($sql);
        $query->execute();
        $result = $query->fetchAll(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false) {
            $index = array_rand($result);
            array_push($res, $result[$index]);
        }
     }

     finally{
         if($conn != null){
             $conn = null;
         }
     }

            }
        
    }
        return $res;

    }
}
    
?>