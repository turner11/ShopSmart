$(document).ready(function () {
    
});


function chbCompleted_clicked(chb) {
    //debugger
    var $currentRow = $(chb).closest('tr');
    $currentRow.find("*").toggleClass("strikeout");
    //debugger
    //display("Clicked, new value = " + chb.checked);
}