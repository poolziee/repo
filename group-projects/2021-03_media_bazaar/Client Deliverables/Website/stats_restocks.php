<?php
    $page = 'statistics';
    $content ='restocks';
    $functionalityRequirements = ['login-functionality'];
    
    require_once('includes/header.php');
?>

    <div id="statistics-wrapper">
        <h2 class="section-title">Statistics: Restocks Overall</h2>
                    <div class ="charts-wrapper">
                     <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="yearlyRestocks"></canvas>
                       </div>
                       <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="monthlyRestocks"></canvas>
                       </div>

                       </div>
        </div>
    </div>
<?php require_once('includes/footer.php'); ?>
