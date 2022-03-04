<?php
$valid_days = ['monday', 'tuesday', 'wednesday', 'thursday', 'friday', 'saturday', 'sunday'];
$valid_shifts = ['none', 'morning', 'midday', 'evening'];

// GENERAL PREFERENCES
if(isset($_POST['general-preferences-submit']) && isset($_POST['general-preferences-shift'])) {
    $shift = $_POST['general-preferences-shift'];

    if(in_array($shift, $valid_shifts)) {
        $userId = $_SESSION['user']->getId();
        
        $preference = new GeneralShiftPreference($userId, $shift);
        $setPreference = new SetGeneralShiftPreference();

        if($setPreference->setShiftPreference($preference) == 1) {
            // SUCCESSFULLY SET GENERAL PREFERENCES
            successMessage('Successfully set general shift preferences');
        } else {
            $updatePreference = new UpdateGeneralShiftPreference();

            if($updatePreference->updateShiftPreference($preference) == 1) {
                // SUCCESSFULLY UPDATED GENERAL PREFERENCES
                successMessage('Successfully updated general shift preferences');
            } else {
                errorMessage('An error occurred, please try again later');
            }
        }
    } else {
        errorMessage('Invalid preferred shift value');
    }
}
// SPECIFIC PREFERENCES
else if(isset($_POST['specific-preferences-submit']) && isset($_POST['specific-preferences-day']) && isset($_POST['specific-preferences-shift'])) {
    $day = $_POST['specific-preferences-day'];
    $shift = $_POST['specific-preferences-shift'];

    if(in_array($day, $valid_days)) {
        if(in_array($shift, $valid_shifts)) {
            $userId = $_SESSION['user']->getId();

            $preference = new SpecificShiftPreference($userId, $shift, $day);
            $setPreference = new SetSpecificShiftPreference();

            if($setPreference->setShiftPreference($preference) == 1) {
                // SUCCESSFULLY SET SPECIFIC PREFERENCES
                successMessage('Successfully set specific shift preference');
            } else {
                $updatePreference = new UpdateSpecificShiftPreference();

                if($updatePreference->updateShiftPreference($preference) == 1) {
                    // SUCCESSFULLY UPDATED GENERAL PREFERENCES
                    successMessage('Successfully updated specific shift preference');
                } else {
                    errorMessage('An error occurred, please try again later');
                }
            }
        } else {
            errorMessage('Invalid preferred shift value');
        }
    } else {
        errorMessage('Invalid day of the week');
    }
}