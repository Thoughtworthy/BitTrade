$(() => {
    let btn = $("#my-btn");
    let txt = $("#my-txt");
    btn.click(function () {
        ajaxCall("http://bitcypo.com/Home/GetUsers", "GET", { term: txt.val() }, function (data) {
            console.log(data);
        }, null);
    })

});