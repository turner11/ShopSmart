function TableToJson() {
    debugger
    // Loop through grabbing everything
    var myRows = [];
    var $headers = $("th");
    var $rows = $("tbody tr").each(function(index) {
        $cells = $(this).find("td");
        var $chkToBuy = $cells.find(".chkToBuy");
        if ($chkToBuy.length >0 && $chkToBuy[0].checked) {
    
        
            myRows[index] = {}; 
            $cells.each(function (cellIndex) {
                var prodNameIdx = 2;
                //for somewht of optimization get only fields that are editable => input
                //or will be used for identification
                $inputs = $(this).find('input');
                if ($inputs.length > 0 || cellIndex == prodNameIdx) {
                    myRows[index][$($headers[cellIndex]).html()] = $(this).html();

                }
            });  
        }
    });

    // Let's put this in the object like you want and convert to JSON (Note: jQuery will also do this for you on the Ajax request)
    var myObj = {};
    myObj.myrows = myRows;
   //alert(JSON.stringify(myObj));​
}
