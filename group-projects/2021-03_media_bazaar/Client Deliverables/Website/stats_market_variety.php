<?php
    $page = 'statistics';
    $content ='variety';
    $functionalityRequirements = ['login-functionality'];

    require_once('includes/header.php');
?>
    <div id="statistics-wrapper">
        <h2 class="section-title">Statistics: Market Variety</h2>
        <div id="statistics-filters-container">
                    <form class="simple-form">
                        <h3>Filters</h3>
                        <div class="select-group">
                            <label>TOP:</label>
                            <label class="select-arrow-label">
                                <select name="statistics-select" class = "statistics-select" id="select-limit">
                                    <option value="3">3</option>
                                    <option value="5">5</option>
                                    <option value="10">MAX</option>
                                </select>
                            </label>
                        </div>
                        <div class="select-group">
                            <label>Category:</label>
                            <label class="select-arrow-label">
                                <select name="statistics-select" class = "statistics-select" id="select-categories">
                                </select>
                            </label>
                        </div>
                       <div class="select-group">
                            <label>Subcategory:</label>
                            <label class="select-arrow-label">
                                <select name="statistics-select" class = "statistics-select" id="select-subcategories">
                                </select>
                            </label>
                        </div>
                    </div>
                    </form>
                    <input id="title" name="title" type="hidden" value="title">
                    <div class ="charts-wrapper" id ="charts-wrapper">
                       </div>
        </div>
    </div>

<?php require_once('includes/footer.php'); ?>
