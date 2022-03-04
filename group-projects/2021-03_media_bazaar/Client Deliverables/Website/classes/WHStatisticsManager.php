<?php
class WHStatisticsManager extends Database{

 private function array_flatten($array){
     if($array != null){
        $singleArray = [];
        foreach($array as $childArray){

          foreach($childArray as $value){
         $singleArray[] = $value;
        }
        }
        return $singleArray;
     }
     return false;

  }

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

    function Categories(){
        $query = "SELECT DISTINCT category FROM items";
        $categories = $this->QueryToArray($query);
        return $this->array_flatten($categories);
    }

    function Subcategories($category){
        $parameters = [];
        array_push($parameters, $category);
        $query = "SELECT DISTINCT subcategory FROM items WHERE category = ?";
        $subcategories = $this->QueryToArray($query,$parameters);
        return $this->array_flatten($subcategories);
    }

    function MonthlyRestocks(){
        
        $query = "SELECT MONTH(r.date) as Month, i.category as Category, SUM(ri.restock_quantity) as Amount
        FROM restocks_items ri INNER JOIN 
        items i ON ri.item_id = i.id
        INNER JOIN restocks r ON r.id = ri.restock_id
        GROUP BY MONTH(r.date), i.category";
        return json_encode($this->QueryToArray($query));

    }

    function MonthlySales(){

        $query = "SELECT MONTH(o.date) as Month, i.category as Category, SUM(oi.order_quantity) as Amount 
		FROM orders_items oi INNER JOIN 
		items i ON oi.item_id = i.id 
		INNER JOIN orders o ON o.id = oi.order_id
 		GROUP BY MONTH(o.date), i.category";
        return json_encode($this->QueryToArray($query));

    }

    function YearlyRestocks(){

        $query = "SELECT i.category as Category, SUM(ri.restock_quantity) as Amount
		FROM restocks_items ri INNER JOIN 
		items i ON ri.item_id = i.id
		INNER JOIN restocks r ON r.id = ri.restock_id
		GROUP BY i.category";
        return json_encode($this->QueryToArray($query));

    }

     function YearlySales(){

         $query = "SELECT i.category as Category, SUM(oi.order_quantity) as Amount
		FROM orders_items oi INNER JOIN 
		items i ON oi.item_id = i.id
		INNER JOIN orders o ON o.id = oi.order_id
		GROUP BY i.category";
        return json_encode($this->QueryToArray($query));
        
    }

    function TopSoldSubcategoriesFromCategory($category, $limit){
        $parameters = [];
        array_push($parameters, $category);

        $query = "SELECT i.subcategory as Subcategory, SUM(oi.order_quantity) as Amount 
		FROM orders_items oi 
		INNER JOIN items i ON oi.item_id = i.id
 		WHERE i.category = ?
		GROUP BY i.subcategory ORDER BY SUM(order_quantity) DESC LIMIT ".$limit;
         return json_encode($this->QueryToArray($query, $parameters));
    }

    function TopSoldBrandsFromSubcategory($subcategory, $limit){
        $parameters = [];
        array_push($parameters, $subcategory);

        $query = "SELECT i.brand as Brand, SUM(oi.order_quantity) as Amount 
		FROM orders_items oi INNER JOIN items i ON oi.item_id = i.id 
		WHERE i.subcategory = ?
		GROUP BY i.brand ORDER BY SUM(order_quantity) DESC LIMIT ".$limit;
        return json_encode($this->QueryToArray($query, $parameters));
    }


}

    
?>