<?php
    $page = 'statistics';
    $content = 'expenses';
    $functionalityRequirements = ['login-functionality'];
    
    require_once('includes/header.php');
?>

    <div id="statistics-wrapper">
        <h2 class="section-title">Statistics: Expenses</h2>
                    <div class ="charts-wrapper">
                      <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="TotalSpendingPerMonth"></canvas>
                       </div>
                       <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="MarketSpendingPerMonth"></canvas>
                       </div>

                        <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="SpendingPerDepartment"></canvas>
                       </div>
                       </div>
        </div>
    </div>
<?php require_once('includes/footer.php'); ?>

 