$(() => {
    let edit = $("#edit");
    let saveChanges = $("#savechanges");
    let cencelEdit = $("#cenceledit")
    let userProfileData = $(".userprofile-data");
    let userProfileInput = $(".userprofileinput-data");
    let messege = $("#message");

    messege.click(function () {
        let Id = $("#ID").val();
        location.href = `${_messageURL}/${Id}`;
    });

    edit.click(() => {
        userProfileData.addClass("d-none");
        userProfileInput.removeClass("d-none");
    });

    cencelEdit.click(() => {
        userProfileInput.addClass("d-none");
        userProfileData.removeClass("d-none");
    });

    saveChanges.click(() => { 
        let updatedProfile = {
            ID: $("#ID").val(),
            FirstName: $("#FirstName").val(),
            LastName: $("#LastName").val(),
            Email: $("#Email").val(),
            DateOfBirth: $("#DateOfBirthInput").val(),
            Gender: $("#Gender").val(),
            Role: $("#Role").text()
        };

        ajaxCall(_editURL, "PUT", updatedProfile, () => {
            userProfileInput.addClass("d-none");
            userProfileData.removeClass("d-none");
            location.reload();
        });

    });

});