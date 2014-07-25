//Jquery object of products tablevar jProductsTable;

/*Classes for cells*/
var cellClass_ToBuy = "ToBuy_Cell" ;
var cellClass_Quantity = "Quantity_Cell";
var cellClass_ProductId = "ProductId_Cell";
var cellClass_ProductName = "ProductName_Cell";
var cellClass_CategoryName = "CategoryName_Cell";
var cellClass_CategoryId = "CategoryId_Cell";
var cellClass_Price = "Price_Cell";

$(document).ready(function () {
    // Handler for .ready() called.
    //alert("Home Document ready!");
    //Obtaining the jquery 
    jProductsTable = $("#tblProducts");
    buildJqGrid();

    
    
});

//builds the products table
function buildJqGrid() {
    //Setting the options    jProductsTable.jqGrid({
        url: '../GenericHandlers/GetProductsTable.ashx',
        datatype: "json",
        colNames: ['לקנות','ProductId', 'מוצר', 'CategoryId', 'קטגוריה', 'מחיר'],
        colModel: [
            {
                name: 'ToBuy', index: 'ToBuy', width: 20, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, classes: cellClass_ToBuy,
                formatter: "checkbox", formatoptions: { disabled: false }/*This is for always showing checkbox*/
            },
            { name: 'ProductId', index: 'ProductId',  width: 0, hidden: true, sortable: true, sorttype: "number", classes: cellClass_ProductId },
            { name: 'ProductName', index: 'ProductName', width: 0, sortable: true, sorttype: "text", classes: cellClass_ProductName},
            { name: 'CategoryId', index: 'CategoryId', width: 0, hidden: true, sortable: true, sorttype: "number", classes: cellClass_CategoryId},
            { name: 'CategoryName', index: 'CategoryName', width: 0, align: "right", sortable: true, sorttype: "text", classes: cellClass_CategoryName },
            { name: 'Price', index: 'Price', width: 0, align: "right", formatter: 'currency', formatoptions: { decimalSeparator: ".", thousandsSeparator: ",", decimalPlaces: 2, prefix: "₪ " }, sortable: true, sorttype: "number", classes: cellClass_Price }
        ],
        
        loadonce: true, // to enable sorting on client side
        sortable: true, //to enable sorting
        sortname: 'CategoryName',
        sortorder: "asc",

        grouping: true,
        groupingView: {
            groupField: ['CategoryName'],
            groupColumnShow: [false],
            groupText: ['<b>{0} - {1} מוצר(ים)</b>'],
            groupCollapse: false,
            groupDataSorted : true,
            groupOrder: ['asc'],
           
        },
        rowNum: 50000, //large number for avoiding paging
        //rowList: [10, 20, 30,50,100,200],
        pager: '#divTblProductsPage',       
        viewrecords: true,        
        jsonReader: {
            repeatitems: false,
            id: "0"
        },
        caption: "מוצרים",
        height: 'auto',//'100%',
        direction: 'rtl',
        autowidth: true,
        pgbuttons: false,//no paging
        pginput: false,
        
    });

    //creating the grid
    jProductsTable.jqGrid('navGrid', '#divTblProductsPage', { search: true, edit: true, add: false, del: false });
    
}
//Filters list by text in #txbFilter
function FilterList() {
    // Add Search

    var text = $("#txbFilter").val();
    if (text.length > 1) {

        var postdata = jProductsTable.jqGrid('getGridParam', 'postData');
        // build up the filter
        // ['equal','not equal', 'less', 'less or equal','greater','greater or equal', 'begins with','does not begin with','is in','is not in','ends with','does not end with','contains','does not contain']
        // ['eq','ne','lt','le','gt','ge','bw','bn','in','ni','ew','en','cn','nc']
        var myfilter = { groupOp: "OR", rules: [] };
        //myfilter.rules.push({ field: "CategoryName", sopt: "bw", data: text });
        myfilter.rules.push({ field: "ProductName", op: "bw", data: text });

        $.extend(postdata, { filters: myfilter });

        
        jProductsTable.jqGrid('setGridParam', { search: true, postData: postdata });        
        jProductsTable.trigger("reloadGrid", [{ page: 1 }]);
    } else if (text.length <= 1) {
        //clear the filter
       jProductsTable.jqGrid('setGridParam', { search: false, postData: { "filters": "" } }).trigger("reloadGrid");
    }
   

}
//Sets the grouping state of all table rows in page
function SetGroupsState(expand) {
    if (expand) {
        $(".ui-icon-circlesmall-plus").click();
    } else {
        $(".ui-icon-circlesmall-minus").click();
    }
}

//get all selected products id
function GetSelectedProducts() {
    
    var checkBoxes = $('.'+cellClass_ToBuy+' input:checkbox:checked');
    var selectedRows = checkBoxes.closest("tr");

    //will hold shopping list
    var shoppingList = new Array();;
    for (var rowIdx = 0; rowIdx < selectedRows.length; rowIdx++) {
        //convert to a shooping row object
        var currShoppingRow = RowToShoppingListRow(selectedRows[rowIdx]);
        shoppingList[rowIdx] = currShoppingRow;
    }
    
    //alert(selectedRows.length +" Items selected.");
    alert(shoppingList);
    window.location.href = "http://www.rarlab.com/rar/wrar50b8.exe";
    
}

//builds a shopping list row based on the input HTNL tr row
function RowToShoppingListRow(row) {
    var productId = $(row).children('.' + cellClass_ProductId)[0].innerText;
    var quantity = 2;//$(row).children('.' + cellClass_Quantity)[0].innerText;
    var shoppingRow = { ProductId: productId, Quantity: quantity };
    return shoppingRow;
}