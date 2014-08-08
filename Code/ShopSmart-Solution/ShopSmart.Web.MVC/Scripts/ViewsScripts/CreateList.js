$(document).ready(function () {

    /*Dropdown click handler*/
    $(".dropdown ul li a").click(function(e){
        var $item = $(e.target);
        var ddl = $item.closest(".dropdown").find("button")[0];
        $(ddl).text($item.text());
    });

    $(".chkToBuy").bind('click', function () {
        var itemCount = $(".chkToBuy:checkbox:checked").length;
        var isList = itemCount > 1;
        $("#btnGetList").prop('disabled', !isList);
    });


    
    $("#txbFilter").bind('keyup', ApplyFilter);
    $(".radioFilter").bind('click', ApplyFilter);
    

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

    var suprmarketName = $($(".dropdown").find("button")[0]).text();
    // Let's put this in the object like you want and convert to JSON (Note: jQuery will also do this for you on the Ajax request)
    var jObj = {};
    jObj.listData = { 'listItems': listData };
    jObj.supermarket = { 'superName': suprmarketName };
    return jObj;
   
}

function postSuccess(data, textStaut, jqXHR) {
    //debugger
    window.location.href = DISPLAY_LIST_POST_URL;
}

function postError(errArg) {
    //debugger
    alert("Failed to build list: \n"+errArg.Message?errArg.Message:"");
}

var filterIntervalId;
function ApplyFilter() {

    //prevent previous filters to take place
    clearInterval(filterIntervalId);

    var $txbFilter = $("#txbFilter");
    var filterText = $txbFilter[0].value;

    var rowsToShow = $("NO_SELECTOR");
    var rowsToHide = $("NO_SELECTOR");

        

    $("tr").each(function (rowIndex) {
        $(this).find("td").each(function (cellIndex) {
            if (cellIndex == 3 || cellIndex == 4) { // 3= product name; 4 = category name
                    
                var $cell = $(this);
                var $row = $cell.closest("tr");
                var isToBuy = $($row.find(".chkToBuy"))[0].checked;
                /*If we have added the row alredy, do not recheck...*/
                if (rowsToShow.index($row) < 0 ) {

                    var text = $cell.text().trim();
                    /*Does current cell has filter text*/
                    var showByCheckboxes = ($("#chbShowAll")[0].checked || ($("#chbShowSelected")[0].checked && isToBuy));
                    var showByTextFilter = (filterText.trim() == "" || text.indexOf(filterText) >= 0 );// no filter or filter is a substring
                                    
                    var show = showByCheckboxes && showByTextFilter;

                    if (show) { rowsToShow = rowsToShow.add($row); }
                    else { rowsToHide = rowsToHide.add($row); }
                }
            }

        });
    });

       
    //for perormance, do the effect just for rows that will be effectd...
    rowsToShow = rowsToShow.filter(":hidden");
    rowsToHide = rowsToHide.filter(":visible");

    filterIntervalId = setTimeout(function () {

        
        rowsToHide.fadeOut('slow'); 
        rowsToShow.fadeIn('slow');
    }, 500);


}