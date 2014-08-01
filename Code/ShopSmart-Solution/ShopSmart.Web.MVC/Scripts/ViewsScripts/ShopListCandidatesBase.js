var isModifyingQuntities = false;
window.onload = function ()
{
    $(".disabled").prop("disabled",true);
    //Initializing is within window load event in order to make sure that Jquery is already loaded
    
    $("input:checkbox.chkToBuy").click(function(e) {
        if (isModifyingQuntities) { return; }
        isModifyingQuntities = true;
        var chk = e.target;
        var currentRow = $(chk).closest('tr');
        var txbQuantity = currentRow.find(".txbQuantity");
        var txt = ""+(chk.checked ? 1 : 0);
        txbQuantity.val(txt);
        //alert("click!");
        SetTotalForRow(currentRow);
        isModifyingQuntities = false;
        
    });
    
    $(".txbPrice").keyup(function (e) {
        var currentRow = $(e.target).closest('tr');
        SetTotalForRow(currentRow);
    });
    $(".txbQuantity").keyup(function(e) {
        //debugger
        if (isModifyingQuntities) { return;}
        isModifyingQuntities = true;
        var txbQuantity = e.target;

        var currValue = txbQuantity.value;
        
        var isNumber = !isNaN(currValue);
        var toBuy = isNumber && currValue >0;

        var currentRow = $(txbQuantity).closest('tr');
        var chk = currentRow.find(".chkToBuy");
       
        chk.prop('checked',  toBuy); 
        if (isNumber) {
            var cleanValue = +currValue;
            txbQuantity.value = cleanValue;
        }
        SetTotalForRow(currentRow);
        //alert("keyup!");
        isModifyingQuntities = false;



    });

    function SetTotalForRow(row) {
        //debugger
        var txbQuantity = row.find(".txbQuantity")[0];
        var txbPrice = row.find(".txbPrice")[0];
        var txbTotalCost = row.find(".txbTotalCost")[0];

        var price = txbPrice.value;
        var quantity = txbQuantity.value;
        var legalvalues = !isNaN(quantity) && !isNaN(price);

        var val = legalvalues ? price * quantity : 0;
        txbTotalCost.value = val;
    } 
}

