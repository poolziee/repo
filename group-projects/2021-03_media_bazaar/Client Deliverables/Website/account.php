<?php
    $page = 'account';
    $content = '';

    $functionalityRequirements = ['account-functionality'];
    
    require_once('includes/header.php');
?>
    <!-- LOGIN FORM -->
    <form class="simple-form" method="POST">
        <h2 class="section-title">Account Preferences</h2>
        <div class="form-group half">
            <label for="first-name">First Name:</label>
            <input type="text" name="first-name" id="first-name" value="<?php echo ucfirst(strtolower($user->getFirstName())); ?>">
        </div>
        <div class="form-group half">
            <label for="last-name">Last Name:</label>
            <input type="text" name="last-name" id="last-name" value="<?php echo ucfirst(strtolower($user->getLastName())); ?>">
        </div>
        <div class="form-group half">
            <label for="gender">Sex:</label>
            <input type="text" name="gender" id="gender" value="<?php echo ucfirst(strtolower($user->getGender())); ?>" disabled>
        </div>
        <div class="form-group half">
            <label for="birth-date">Birth Date:</label>
            <input type="text" name="birth-date" id="birth-date" value="<?php echo $user->getBirthDate(); ?>" disabled>
        </div>
        <div class="form-group full">
            <label for="email">Email:</label>
            <input type="email" name="email" id="email" value="<?php echo $user->getEmail(); ?>" disabled>
        </div>
        <div class="form-group full">
            <label for="new-password">New Password:</label>
            <input type="password" name="new-password" id="new-password">
        </div>
        <div class="form-group full">
            <label for="confirm-new-password">Confirm New Password:</label>
            <input type="password" name="confirm-new-password" id="confirm-new-password">
        </div>
        <div class="form-group full">
            <label for="current-password">Current Password:</label>
            <input type="password" name="current-password" id="current-password">
        </div>
        <div class="form-group submit">
            <input type="submit" name="submit" value="Save">
        </div>
    </form>
<?php require_once('includes/footer.php'); ?>