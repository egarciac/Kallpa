function BindEventHandlers() {
    $('#VisualizarImageButton').on('click', function () {
        $('#contenedor-reportes').show();
    });
}

$(function () {
    $(".date-picker").datepicker({
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true
    });
    BindEventHandlers();
});