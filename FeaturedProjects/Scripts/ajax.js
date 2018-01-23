function sync() {
    $.get("http://localhost:61006/Home/Synchronize", function (data, status) {
        $('#modal-loading').modal('hide');
        alert("A sincronização com o GitHub foi completada com sucesso");
    });
}