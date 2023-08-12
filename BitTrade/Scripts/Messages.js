$(() => {
    let profileDiv = $(".Friends li");
    let chatDiv = $(".chat");
    profileDiv.click(function () {
        let al = $(this).find("div").attr("data-id");

        chatDiv.load("/Home/MessagesPartal");


    });
});