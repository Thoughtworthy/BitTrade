$(() => {
    let btn = $("#my-btn");

    btn.click(function () {

        $.ajax({
            url: `http://bitcypo.com/Test/Test`,
            type: "POST",
            data: $("#my-form-id").serialize(),
            success: function (data) {
                { };
            }
        })

        })

});