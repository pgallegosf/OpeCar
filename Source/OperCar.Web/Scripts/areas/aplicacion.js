
function AbrirDoc() {

    //var descripcion = $("#descripcionCobertura").val();
    var data = {};
    //data.archivo = "\\\\10.10.101.17\\shared\\Nue.txt";
    //"\\10.15.61.15\Bd_Cae\CAE_OSITRAN";
    data.archivo = "\\\\10.10.101.25\\\dq_pv\\Incidencias.xlsx";
    

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