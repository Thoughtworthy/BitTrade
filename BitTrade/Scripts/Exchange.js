$(() => {

    let currencyBody = $(".currency-body");

    function updateCurrencyData() {
        ajaxCall("https://api.coinstats.app/public/v1/markets?coinId=bitcoin", "GET", null, function (data) {
            let currencyData = data.slice(0, 12);

            let url = `http://bitcypo.com/Home/ExchangesPartial?data=${encodeURIComponent(JSON.stringify(currencyData))}`;
            currencyBody.load(url, function (response, status, xhr) {
                if (status === "error") {
                    console.error("Error loading partial view:", xhr.statusText);
                }
            });
        });
    }


    updateCurrencyData();
   /* setInterval(updateCurrencyData, 800);*/

});