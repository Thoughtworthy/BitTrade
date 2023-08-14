$(() => {
    let searchButton = $("#search");
    let personInputData = $("#personInfo");
    let container = $(".people-container");

    searchButton.click(() => {

        ajaxCall(`http://bitcypo.com/api/User/Get?term=${personInputData.val()}`, "GET", null, function (data) {
            container.load(`http://bitcypo.com/Home/SearchPartial?data=${encodeURIComponent(JSON.stringify(data))}`);
        });
    });

});