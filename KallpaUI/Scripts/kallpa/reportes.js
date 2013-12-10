function BindEventHandlers() {    
}

$(function () {
    $(".date-picker").datepicker({
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true
    });
    BindEventHandlers();
});