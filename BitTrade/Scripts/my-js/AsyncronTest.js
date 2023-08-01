$(() => {
    let btn = $("#my-btn");
    let div = $("#my-div");

    btn.click(function () {
        /*URLaction*/
        div.load(URLaction);
    });

})