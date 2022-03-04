<?php
    $page = 'statistics';
    $content = 'departments';
    $functionalityRequirements = ['login-functionality'];
    
    require_once('includes/header.php');
?>

    <div id="statistics-wrapper">
        <h2 class="section-title">Statistics: Departments</h2>
                    <div class ="charts-wrapper">
                       <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="salariesChart"></canvas>
                       </div>

                        <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="whPerMonth"></canvas>
                       </div>

                       <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="whDeptChart"></canvas>
                       </div>

                       <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="whDeptChartM"></canvas>
                       </div>
                       <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="topEmps"></canvas>
                       </div>
                       </div>
        </div>
    </div>
<?php require_once('includes/footer.php'); ?>

 