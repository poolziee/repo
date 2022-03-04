</div>
<!-- FOOTER -->
<footer id="footer">
	<a href="/dashboard">&copy; 2021 MediaBazaar Inc. All rights reserved</a>
</footer>

<!-- JAVASCRIPT IMPORTS -->
<script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
<script src="../js/essentials.js"></script>


  <?php
    if($page == 'statistics') {
?>
     <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
     <script type="text/javascript" src="js/charts-config.js"></script>
<?php

        if($content != 'variety'){
        require_once('charts/charts.php');
       }
}
    if($content == 'variety') {
?>
     <script type="text/javascript" src="js/categories-variety.js"></script>
     <script type="text/javascript" src="js/statistics-variety.js"></script>
<?php
    }
    if($page == 'dashboard') {
?>
    <script src="../js/dashboard.js"></script>
<?php
    }
?>
</body>
</html>