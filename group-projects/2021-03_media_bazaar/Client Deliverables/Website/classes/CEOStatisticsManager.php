<?php
class CEOStatisticsManager extends Database{

    private function QueryToArray($sql, $parameters = null){
         $conn = null;
     try{
        $conn =  Database::connect();
        $query = $conn->prepare($sql);
        if($parameters == null){
        $query->execute();
        }
        else{
            $query->execute($parameters);
        }
        $result = $query->fetchAll(PDO::FETCH_ASSOC);
        $count = $query->rowCount();

        if($query != false) {
            return $result;
        }
        else{
            return null;
        }
     }
     finally{
         if($conn != null){
             $conn = null;
         }
     }

    }

    function RevenuePerMonth(){
        $query = "SELECT MONTH(date) as Month ,SUM(total_price) as Revenue 
                  FROM orders 
                  GROUP BY MONTH(date)";
        return json_encode($this->QueryToArray($query));

    }

     function RevenuePerCategory(){
        $query = "SELECT i.category as Category, SUM(oi.order_quantity * i.price) as Revenue FROM orders_items oi INNER JOIN items i ON oi.item_id = i.id INNER JOIN orders o ON o.id = oi.order_id GROUP BY i.category";
        return json_encode($this->QueryToArray($query));
    }

      function MarketSpendingPerMonth(){
        $query = "SELECT MONTH(date) as Month, SUM(total_price) as MarketSpending FROM restocks GROUP BY MONTH(date)";
        return json_encode($this->QueryToArray($query));
    }

    function TotalSpendingPerMonth(){
        $query = "SELECT MONTH(date) as Month, (SUM(total_price)+(SELECT SUM(salary) FROM employees e)) as TotalSpending 
        FROM restocks 
        GROUP BY MONTH(date)";
        return json_encode($this->QueryToArray($query));
    }

    function SpendingPerDepartment(){
        $query = "SELECT e.job_position as Department, SUM(salary) * 12 AS SalariesSpending
		FROM employees e
		GROUP BY e.job_position";
        return json_encode($this->QueryToArray($query));
    }


}

    
?>