$(() => {
    let searchButton = $("#search");
    let personInputData = $("#personInfo");
    let container = $(".people-container");

    searchButton.click(() => {

        ajaxCall(`${RurlApi}/Get?term=${personInputData.val()}`, "GET", null, function (data) {
            container.load(`${Rurl}?data=${encodeURIComponent(JSON.stringify(data))}`);
        });
    });

});

