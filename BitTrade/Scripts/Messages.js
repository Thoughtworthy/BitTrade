$(() => {
    let profileDiv = $(".Friends li");
    let chatDiv = $(".chat");
    let txtMessage = $("#message-text");
    let selectedUserID = 0;
    let sendButton = $("#send-button");
    let friendsList = $(".friend-list.div-scroll-friend"); // Corrected typo: frindsList -> friendsList

    sendButton.click(sendMessage);

    // Click event handler for selecting a friend
    profileDiv.click(function () {
        selectedUserID = $(this).find("div").attr("data-id");

        // Load messages and scroll to bottom after loading
        chatDiv.load(`${_messagesPartialURL}/${selectedUserID}`, function () {
            scrollToBottom(chatDiv);
        });
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

    let userByID = parseInt(window.location.search.substring(1));

    if (!isNaN(userByID)) {
        if ($(`div[data-id=${userByID}]`).length) {
            $(`div[data-id=${userByID}]`).click();
        } else {
            let ob = {};
            ajaxCall(`http://bitcypo.com/api/User/${userByID}`, "GET", null, function (data) {
                ob = data;

                friendsList.prepend(`
                <li class="active bounceInDown">
                    <div data-id="${userByID}">
                        <div class="friend-name">
                            <a href="http://bitcypo.com/Home/UserProfile/${userByID}" class="text-white">
                                <img src="https://bootdey.com/img/Content/user_1.jpg" alt="" class="img-circle">
                                ${ob["FirstName"]}
                            </a>
                        </div>
                        <div class="last-message text-muted"> . . . </div>
                        <small class="time text-muted"> . . . </small>
                        <small class="chat-alert label label-danger">0</small>
                    </div>
                </li>
            `);

                profileDiv = $(".Friends li");
                profileDiv.click(function () {
                    selectedUserID = $(this).find("div").attr("data-id");

                    chatDiv.load(`${_messagesPartialURL}/${selectedUserID}`, function () {
                        scrollToBottom(chatDiv);
                    });
                });

                // Manually trigger the click event after the new item is appended
                $(`div[data-id=${userByID}]`).click();
            });
        }
    }

});
