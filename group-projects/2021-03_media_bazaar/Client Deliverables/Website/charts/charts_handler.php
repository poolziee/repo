<?php
require_once('../classes/Database.php');
 require_once('../classes/WHStatisticsManager.php');

    $manager = new WHStatisticsManager();

if(isset($_POST['top_subs'])){
    $category = $_POST['category'];
    $limit = $_POST['limit'];
    $subs = json_encode($manager->Subcategories($category));

    $query = $manager->TopSoldSubcategoriesFromCategory($category, $limit);
    echo json_encode(array($query,$subs));
}

else if(isset($_POST['top_brands'])){
     $subcategory = $_POST['subcategory'];
     $limit = $_POST['limit'];
     $query = $manager->TopSoldBrandsFromSubcategory($subcategory, $limit);
     echo $query;
}

else if(isset($_POST['limit_change'])){
    $query = null;
    $category = $_POST['category'];
    $subcategory = $_POST['subcategory'];
    $limit = $_POST['limit'];

    if($subcategory != 'x'){
    $query = $manager->TopSoldBrandsFromSubcategory($subcategory, $limit);
    }
    else{
     $query = $manager->TopSoldSubcategoriesFromCategory($category, $limit);
    }
    echo $query;

}


if(isset($_POST['append'])){
    echo json_encode($manager->Categories());
}
?>