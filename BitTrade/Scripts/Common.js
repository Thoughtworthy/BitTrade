// Ajax call animation
function showLoadingAnimation() {
    $("#loading").removeClass("d-none");
    $(".container").addClass("d-none");
}

function hideLoadingAnimation() {
    setTimeout(function () {
        $("#loading").addClass("d-none");
        $(".container").removeClass("d-none");
    }, 0);
}

$(document).on({
    ajaxStart: showLoadingAnimation,
    ajaxStop: hideLoadingAnimation
});


//
function ajaxCall(url, type, data, successCallBack, errorCallBack) {
    $.ajax({
        url: url,
        beforeSend: showLoadingAnimation,
        type: type,
        data: data,
        success: successCallBack,
        error: errorCallBack,
        complete: hideLoadingAnimation
    });
}

function ajaxFormPost(url, selector, successCallBack, errorCallBack) {
    $.ajax({
        url: url,
        type: "POST",
        data: $(selector).serialize(),
        success: successCallBack,
        error: errorCallBack
    });
}


// Burger Menue Button click event
let navOpen = false;
function toggleNav() {
    if (navOpen) {
        closeNav();
    } else {
        openNav();
    }
    navOpen = !navOpen;
}
function openNav() {
    $("#mySidepanel").css("width", "250px");
}
function closeNav() {
    $("#mySidepanel").css("width", "0px");
}


