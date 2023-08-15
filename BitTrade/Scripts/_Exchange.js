$(() => {

    $(".sell").click(function () {
        let bound = $(this).closest("tr").find(".price").text();
    });

});