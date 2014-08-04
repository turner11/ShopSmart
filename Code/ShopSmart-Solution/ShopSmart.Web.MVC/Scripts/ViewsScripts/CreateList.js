$(document).ready(function () {

    $("#btnGetList").click(function() {        
        var JsonObj = TableToJson();
        //alert(JSON.stringify(myJsonObj));        
        var listAsJsonArg = JSON.stringify(JsonObj);
        $.ajax({
            url: CREATE_LIST_POST_URL,
            cache:false,
            type: "POST",
            dataType: "json",
            //contentType: 'application/x-www-form-urlencoded.',
            //contentType: "application/json; charset=utf-8",
            data: "listAsJson="+listAsJsonArg,
            success: postSuccess,
            error: postError
        });

    });
});

function TableToJson() {    
    // Loop through grabbing everything
    var listData = [];
    var $headers = $("th");
    var $rows = $("tbody tr").each(function(index) {
        $cells = $(this).find("td");
        var $chkToBuy = $cells.find(".chkToBuy");
        if ($chkToBuy.length >0 && $chkToBuy[0].checked) {
    
        
            listData[index] = {}; 
            $cells.each(function (cellIndex) {
                var prodNameIdx = 3; //just for easier debugging...
                //for somewhat of optimization get only fields that are editable => input
                //or will be used for identification
                $inputs = $(this).find('input');
                if ($inputs.length > 0 || cellIndex == prodNameIdx) {
                    var header = $($headers[cellIndex]).text().trim();
                    var text = $(this).text().trim();
                    var value = text? text : $inputs.context.childNodes['1'].value;
                    listData[index][header] = value;

                }
            });  
        }
    });

    // Let's put this in the object like you want and convert to JSON (Note: jQuery will also do this for you on the Ajax request)
    var jObj = {};
    jObj.listData = {'listItems ' : listData};
    return jObj;
   
}

function postSuccess(data, textStaut, jqXHR) {
    var a = 1;
}

function postError(errArg) {
    var b = 2;
}