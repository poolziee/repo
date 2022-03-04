<?php
    $page = 'dashboard';
    $content = '';
    $functionalityRequirements = ['preferences-functionality', 'absence-functionality', 'schedule-functionality', 'announcements-functionality'];
    
    require_once('includes/header.php');
    error_reporting(E_ERROR | E_PARSE);
    ini_set('display_errors', 0);
    
?>
    <!-- WELCOME MESSAGE -->
    <p id="welcome-message">Greetings, <span><?php echo $_SESSION['user']->getFirstName(); ?></span></p>
    <!-- DASHBOARD -->
    <div id="dashboard-wrapper">
        <h2 class="section-title">Announcements</h2>
        <div id="dashboard-container">
            <!-- ANNOUNCEMENTS -->
            <div class="dashboard-content visible" id="dashboard-announcements">
                <ul>
                <?php 
                    if(!empty($announcements)) {
                        foreach($announcements as $a) {
                ?>
                    <li>
                        <span><?php
                            if(is_null($a['objection']) && $a['status'] == 'confirmed') {
                                echo 'Day off request from <span class="semi-bold">' . $a['start_date'] . '</span> until <span class="semi-bold">' . $a['end_date'] . '</span> is <span class="color-success">approved</span>!';
                            } else {
                                echo 'Day off request from <span class="semi-bold">' . $a['start_date'] . '</span> until <span class="semi-bold">' . $a['end_date'] . '</span> is <span class="color-failure">denied</span>! <br> <span class="semi-bold">Objection:</span> ' . $a['objection'];
                            }
                        ?>
                        </span>
                        <i class="announcement-dismiss" id="<?php echo $a['request_id']; ?>"><ion-icon name="close-outline"></ion-icon></i>
                    </li>
                <?php
                        }
                    } 
                ?>
                </ul>
            </div>
            <!-- SCHEDULE -->
            <div class="dashboard-content" id="dashboard-schedule">
                <table>
                    <thead>
                        <tr>
                            <th>Monday</th>
                            <th>Tuesday</th>
                            <th>Wednesday</th>
                            <th>Thursday</th>
                            <th>Friday</th>
                            <th>Saturday</th>
                            <th>Sunday</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <?php foreach($scheduleDaysWeekOne as $key => $value) { 
                                $day = $value[0];
                                $shifts = $value[1];
                            ?>
                                <td>
                                    <span class="schedule-cell-date"><?php echo $day->getReadableDateWithoutYear(); ?></span>
                                    <span class="schedule-cell-shift"><?php echo (!is_null($shifts) && !empty($shifts)) ? $shifts : 'None'; ?></span>
                                </td>
                            <?php } ?>
                        </tr>
                        <tr>
                            <?php foreach($scheduleDaysWeekTwo as $key => $value) {
                                $day = $value[0];
                                $shifts = $value[1];
                            ?>
                                <td>
                                    <span class="schedule-cell-date"><?php echo $day->getReadableDateWithoutYear(); ?></span>
                                    <span class="schedule-cell-shift"><?php echo (!is_null($shifts) && !empty($shifts)) ? $shifts : 'None'; ?></span>
                                </td>
                            <?php } ?>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!-- PREFERENCES -->
            <div class="dashboard-content" id="dashboard-preferences">
                <div id="preferences-wrapper">
                    <form class="simple-form" action="dashboard" method="POST">
                        <h3>Set for specific day</h3>
                        <div class="form-group">
                            <label for="specific-preferences-day">Day:</label>
                            <label class="select-arrow-label">
                                <select name="specific-preferences-day" id="specific-preferences-day">
                                    <option value="monday">Monday</option>
                                    <option value="tuesday">Tuesday</option>
                                    <option value="wednesday">Wednesday</option>
                                    <option value="thursday">Thursday</option>
                                    <option value="friday">Friday</option>
                                    <option value="saturday">Saturday</option>
                                    <option value="sunday">Sunday</option>
                                </select>
                            </label>
                        </div>
                        <div class="form-group">
                            <label for="specific-preferences-shift">Preferred Shift:</label>
                            <label class="select-arrow-label">
                                <select name="specific-preferences-shift" id="specific-preferences-shift" required>
                                    <option value="none">None</option>
                                    <option value="morning" selected>Morning</option>
                                    <option value="midday">Midday</option>
                                    <option value="evening">Evening</option>
                                </select>
                            </label>
                        </div>
                        <div class="form-group submit">
                            <input type="submit" name="specific-preferences-submit" class="small-submit" value="Save" style="margin-top: 30px;" />
                        </div>
                    </form>
                    <p>OR</p>
                    <form class="simple-form" action="dashboard" method="POST" id="general-form">
                        <h3>Set in general</h3>
                        <div class="form-group">
                            <label for="general-preferences-shift">Preferred Shift:</label>
                            <label class="select-arrow-label">
                                <select id="general-preferences-shift" name="general-preferences-shift" id="general-preferences-shift" required>
                                    <option value="none">None</option>
                                    <option value="morning" selected>Morning</option>
                                    <option value="midday">Midday</option>
                                    <option value="evening">Evening</option>
                                </select>
                            </label>
                        </div>
                        <div class="form-group submit">
                            <input type="submit" name="general-preferences-submit" class="small-submit" value="Save" style="margin-top: 30px;" />
                        </div>
                    </form>
                </div>
            </div>
            <!-- ABSENCE -->
            <div class="dashboard-content" id="dashboard-absence">
                <div id="absence-wrapper">
                    <form class="simple-form" method="POST" action="dashboard" id="sick-report-form">
                        <h3>I'm feeling sick today</h3>
                        <div class="form-group">
                            <label for="until-date">I will be sick until:</label>
                            <input type="date" name="until-date" id="until-date" />
                        </div>
                        <div class="form-group">
                            <label for="symptoms">Describe your symptoms:</label>
                            <textarea name="symptoms" id="symptoms"></textarea>
                        </div>
                        <div class="form-group submit">
                            <input type="submit" class="small-submit" name="sick-report-submit" value="Submit" />
                        </div>
                    </form>
                    <p>OR</p>
                    <form class="simple-form" method="POST" action="dashboard" id="day-off-form">
                        <h3>I need a day off</h3>
                        <div class="form-group">
                            <label for="start-day">I need some days off from:</label>
                            <input type="date" name="start-day" id="start-day" />

                            <input type="checkbox" name="one-day-only" value="one-day-only" id="one-day-only" checked>
                            <label for="one-day-only">I will be needing only one day off</label>
                        </div>
                        <div class="form-group" id="end-day-form-group">
                            <label for="end-day">I need some days off until:</label>
                            <input type="date" name="end-day" id="end-day" />
                        </div>
                        <div class="form-group">
                            <label for="urgency">And it is:</label>
                            <label class="select-arrow-label">
                                <select name="urgency" id="urgency" required>
                                    <option value="not-urgent" selected>Not Urgent</option>
                                    <option value="urgent">Urgent</option>
                                </select>
                            </label>
                        </div>
                        <div class="form-group">
                            <label for="reason">I need a day off because:</label>
                            <textarea name="reason" id="reason"></textarea>
                        </div>
                        <div class="form-group submit">
                            <input type="submit" class="small-submit" name="day-off-submit" value="Request day off" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <a href="javascript:void(0)" class="dashboard-button" id="dashboard-button-announcements" page="dashboard-announcements">
            Announcements
        </a>
        <a href="javascript:void(0)" class="dashboard-button" id="dashboard-button-schedule" page="dashboard-schedule" onclick="loadSchedule();">
            Schedule
        </a>
        <a href="javascript:void(0)" class="dashboard-button" id="dashboard-button-preferences" page="dashboard-preferences">
            Preferences
        </a>
        <a href="javascript:void(0)" class="dashboard-button" id="dashboard-button-absence" page="dashboard-absence">
            Absence
        </a>
    </div>
<?php require_once('includes/footer.php'); ?>