<?php
    $page = 'statistics';
    $content ='market';
    $functionalityRequirements = ['login-functionality'];
    
    require_once('includes/header.php');
?>

    <div id="statistics-wrapper">
        <h2 class="section-title">Statistics: Market Overall</h2>
                    <div class ="charts-wrapper">
                     <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="yearlySales"></canvas>
                       </div>
                       <div class="chart-container" style="position: relative; height:40vh; width:80vw">
                             <canvas id="monthlySales"></canvas>
                       </div>

                       </div>
        </div>
    </div>
<?php require_once('includes/footer.php'); ?>

 