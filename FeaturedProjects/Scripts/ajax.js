function sync() {
    $(".show-modal").click(function () {
        $("#modal-loading").modal({
            backdrop: 'static',
            keyboard: false
        });
    });

    $.get("/Home/Synchronize", function (data, status) {
        $('#modal-loading').modal('hide');
        alert("A sincronização com o GitHub foi completada com sucesso");
    });
}