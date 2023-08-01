$(() => {
    let btn = $("#my-btn");
    let div = $("#my-div");

    btn.click(function () {

        let name = $("#flag").val();

        $.ajax({
            url: `http://bitcypo.com/Test/JsonFoo?flag=${name}`,
            type: "GET",
            success: function (data) {
                div.empty();
                for (var i = 0; i < data.length; i++) {

                    div.append(`<div>${data[i]} </div>`)
                }
            }

        })

    });

})