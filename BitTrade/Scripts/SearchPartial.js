$(() => {
    let addFriend = $(".add-friend");
    let removeFriend = $(".remove-from-frinds");
    let writeMessage = $(".write-message");


    writeMessage.click(function () {
        var buttonContainer = $(this).closest(".button-container"); // Capture the container
        selectedUserID = buttonContainer.attr("data-id");
        location.href = `${_messageURL}/${selectedUserID}`;
    });
});