
function AbrirDoc() {

    //var descripcion = $("#descripcionCobertura").val();
    var data = {};
    data.archivo = "archivo";
    

    var jqxhr = $.ajax({
        type: "POST",
        url: "Aplicacion/AbrirArchivo",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
      .done(function (data) {
          alert(data);
      });
    return false;
}