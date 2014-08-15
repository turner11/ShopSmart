$(document).ready(function () {

   

   

    
  

    $("#btnShowList").click(function () {
        var listId = $(".rdbArchiveList").filter(':checked').closest("div").find(".idContainer").val();
        $.ajax({
            url: SHOPLISTHISTORY_POST_URL,
            cache:false,
            type: "POST",
            dataType: 'text',
            //contentType: 'application/x-www-form-urlencoded.',
            //contentType: "application/json; charset=utf-8",
            data: { listIndex: listId },
            success: postSuccess,
            error: postError
        });

    });
});



function postSuccess(data, textStaut, jqXHR) {
    //debugger
    window.location.href = CREATE_LIST_POST_URL;
}

function postError(errArg) {
    //debugger
    alert("Failed to send information to server: \n"+errArg.Message?errArg.Message:"");
}
