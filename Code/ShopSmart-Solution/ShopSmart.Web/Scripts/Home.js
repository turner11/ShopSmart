$(document).ready(function () {
    // Handler for .ready() called.
    //alert("Home Document ready!");
    //GetProductsTableAsync();
    aaa();
    
   
    
});

function GetProductsTableAsync() {
    $.ajax({
        url: "../GenericHandlers/GetProductsTable.ashx",
        context: document.body,
        cache: false,
        success: function (productsJsonString) {
            jsonString = $.parseJSON(productsJsonString);
            InjectProductsTable(jsonString);            
            AddCheckBoxColumn();
        }
    });
}

function AddCheckBoxColumn() {
    //Add header
    $('#tblProducts tr:first ').append("<td class='TableHeading'> To Buy</td>");
    //Add columns
    var chxIdx = 1;
    $('#tblProducts tr:not(:first)').each(function () {
        $(this).append("<td class='tdMiddleCells'><input type='checkbox' Id='chbTobuy" + (chxIdx++) + "' value=' ' /></td>");

    });
}

function InjectProductsTable(productsJson) {
    //alert(productsJson);
    var table = JsonToTable(productsJson);
    if (table) {
        $("#tblProducts tbody").html(table);
        //Make sortable
        //$("#tblProducts").tablesorter({ sortList: [[0, 0], [2, 1]], widgets: ['zebra'] });
        //$("#tblProducts").tablesorter();
    } else {
        alert("Failed to parse products table.");
    }
    

}

function JsonToTable(json) {   
    var headerRow = GetProductsHeaderRow(json);
    var tbl_body = headerRow;
    $.each(json, function () {
        var tbl_row = "";
        $.each(this, function (k, v) {
            tbl_row += "<td>" + v + "</td>";
        })
        tbl_body += "<tr>" + tbl_row + "</tr>";
    })
    //alert(tbl_body);
    return tbl_body;
    
}

function GetProductsHeaderRow(json) {
    var headerRow = "<tr>";
    $.each(json[0], function (k, v) {
        headerRow += "<td>" + k + "</td>";
    })
    headerRow += "</tr>";
    return headerRow;
}

function aaa() {
     jQuery("#jsonmap").jqGrid({
        url: '../GenericHandlers/GetProductsTable.ashx',
        datatype: "json",
        colNames: ['ProductId', 'ProductName', 'CategoryId', 'CategoryName', 'Price'],
        colModel: [
            { name: 'ProductId', index: 'ProductId', width: 55, width:0 },
            { name: 'ProductName', index: 'ProductName', width: 90 },
            { name: 'CategoryId', index: 'CategoryId asc, CategoryId', width: 100 },
            { name: 'CategoryName', index: 'CategoryName', width: 80, align: "right" },
            { name: 'Price', index: 'Price', width: 80, align: "right" },
        ],
        rowNum: 10,
        rowList: [10, 20, 30],
        pager: '#pjmap',
        sortname: 'id',
        viewrecords: true,
        sortorder: "desc",
        jsonReader: {
            repeatitems: false,
            id: "0"
        },
        caption: "JSON Mapping",
        height: '100%'
    });
    jQuery("#jsonmap").jqGrid('navGrid', '#pjmap', { edit: false, add: false, del: false });
   
}
