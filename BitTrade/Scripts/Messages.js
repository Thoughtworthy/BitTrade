$(() => {
    let profileDiv = $(".friends li");
    let chatDiv = $(".chat");
    let txtMessage = $("#message-text");
    let selectedUserID = 0;
    let sendButton = $("#send-button");
    let chatContainer = $(".chat-container");

    sendButton.click(sendMessage);

    // Click event handler for selecting a friend
    profileDiv.click(function () {
        // Remove "selected" class from any previously selected user
        $('.friend-prof.selected').removeClass('selected');

        // Add "selected" class to the clicked user's div
        selectedUserID = $(this).find("div").attr("data-id");
        chatContainer.removeClass("chat-default");
        let selectedUser = $(`div[data-id=${selectedUserID}]`);
        selectedUser.addClass("selected");

        // Load messages and scroll to bottom after loading
        chatDiv.load(`${_messagesPartialURL}/${selectedUserID}`, function () {
            scrollToBottom(chatDiv);
        });
    });

    txtMessage.keypress(function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            sendButton.click();
        }
    });

    function sendMessage() {
        if (selectedUserID == 0) {
            alert("Please select a conversation.");
            return;
        }

        let text = txtMessage.val();
        if (!text) {
            return;
        }

        ajaxCall(_messageURL, "POST", {
            ToUserID: selectedUserID,
            Text: text
        }, function () {
            chatDiv.load(`${_messagesPartialURL}/${selectedUserID}`, function () {
                scrollToBottom(chatDiv);
                txtMessage.val('');
            });
        });
    }




    function scrollToBottom(element) {
        element.scrollTop(element.prop("scrollHeight"));
    }

    $(`div[isSelected="True"]`).click();

});
