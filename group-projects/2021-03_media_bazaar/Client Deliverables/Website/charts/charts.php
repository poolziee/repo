<?php
if($content == "departments"){
    $manager = new HRStatisticsManager();
    $salaries = json_encode($manager->GetAverageSalaryPerDepartment());
    $hrsPerDeptY = json_encode($manager->GetHoursPerDepartmentForYear());
    $hrsPerDeptM = json_encode($manager->GetHoursPerDepartmentPerMonth());
    $topEmpsPerDept = json_encode($manager->GetTopEmployeesPerDepartment());
    $whPerMonth = json_encode($manager->GetHoursPerMonth());


 require_once('charts/hr_charts/salariesChart.php');
 require_once('charts/hr_charts/whDeptChart.php');
 require_once('charts/hr_charts/whDeptChartM.php');
 require_once('charts/hr_charts/topEmpsChart.php');
 require_once('charts/hr_charts/whPerMonth.php');
}

else if($content == 'market' || $content =='restocks'){
        $manager = new WHStatisticsManager();
      
    if($content == 'market'){
        $monthlySales = $manager->MonthlySales();
        $yearlySales = $manager->YearlySales();

        require_once('charts/wh_charts/MonthlySales.php');
        require_once('charts/wh_charts/YearlySales.php');

    }
    else if($content == 'restocks'){
        $monthlyRestocks = $manager->MonthlyRestocks();
        $yearlyRestocks = $manager->YearlyRestocks();

        require_once('charts/wh_charts/MonthlyRestocks.php');
        require_once('charts/wh_charts/YearlyRestocks.php');
        
    }

}

else if($position = "ceo"){
  $manager = new CEOStatisticsManager();
 $revenuePerMonth = $manager->RevenuePerMonth();
 $totalSpendingPerMonth = $manager->TotalSpendingPerMonth();

    if($content == 'expenses'){
        
        $marketSpendingPerMonth = $manager->MarketSpendingPerMonth();
        $spendingPerDepartment = $manager->SpendingPerDepartment();

        require_once('charts/ceo_charts/TotalSpendingPerMonth.php');
        require_once('charts/ceo_charts/MarketSpendingPerMonth.php');
        require_once('charts/ceo_charts/SpendingPerDepartment.php');
        
    }
    else if($content == 'revenue'){
        
         $revenuePerCategory = $manager->RevenuePerCategory();

          require_once('charts/ceo_charts/RevenuePerMonth.php');
          require_once('charts/ceo_charts/RevenuePerCategory.php');

    }
}

?>