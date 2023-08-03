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


function ajaxCall(url, type, data, successCallBack, errorCallBack) {
    $.ajax({
        url: url,
        type: type,
        data: data,
        success: successCallBack,
        error: errorCallBack
    });
};
function ajaxFormPost(url, selector,successCallBack, errorCallBack) {
    $.ajax({
        url: url,
        type: "POST",
        data: $(selector).serialize(),
        success: successCallBack,
        error: errorCallBack
    });
};
