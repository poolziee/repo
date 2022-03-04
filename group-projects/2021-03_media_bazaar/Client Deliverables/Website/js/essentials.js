$(document).ready(function() {
    // SET BODY WRAPPER HEIGHT
    let bodyHeight = $(document).outerHeight()
    let footerHeight = $('#footer').outerHeight()

    let bodyWrapperHeight = bodyHeight - footerHeight
    $('#body-wrapper').css('min-height', `${bodyWrapperHeight}px`)

    // CLOSE MESSAGES
    $("#messages-container ul li i").click(function() {
        let parentLi = $(this).parent()

        $(parentLi).slideUp()
    })

    // AUTOMATICALLY CLOSE SUCCESS MESSAGES AFTER 3 SECONDS
    $("#messages-container #success-messages li").delay(3000).slideUp(500)
})