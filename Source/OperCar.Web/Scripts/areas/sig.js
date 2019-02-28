document.addEventListener("DOMContentLoaded", function () {
    // Handler when all assets (including images) are loaded
    $('.collapse').collapse();
    $('.lista-ultimo-subArea').on("click", HabilitarActive);
    $('.lista-ultimo-subArea').on("click", HabilitarActive);
    $('.lista-ultimo-subArea.subAreaTodo').on("click", MostarTodosDocumentos);
    $('.titulosubarea').on("click", function () {
        $('.lista-ultimo-subArea.subAreaTodo').trigger("click");
    });
    $('#btnAddSubAreaPrim').on("click", ActualizarDatosSubArea);
    $('#btnGuardarSubArea').on("click", RegistrarSubArea);
    $('#btnGuardarDocumento').on("click", RegistrarDocumento);
    //$('#btnAddSubAreaSec').on("click", ActualizarDatosSubArea);
      
});
function HabilitarActive() {
    var clase = $(this).data("id");
    $(this).parent().find(".active").each(function () {
        $(this).removeClass("active");
    });
    $(this).addClass("active");
    $(".card-subArea").hide();
    $("."+clase).show();

}

function MostarTodosDocumentos() {
    $(".card-subArea").show();
}

function ActualizarDatosSubArea() {
    var codigoArea = $(this).data("codigo");
    var esUltimo = $(this).data("esultimo");
    $("#idArea").val(codigoArea);
    $("#indicadorEsUltimo").val(esUltimo);

    //var idPadre = $(this).data("idpadre");
    //$("#idPadre").val(idPadre);

}

function ActualizarDatosSubAreaSec(codArea,idPadre,esUltimo) {
    $("#idArea").val(codArea);
    $("#indicadorEsUltimo").val(esUltimo);
    $("#idPadre").val(idPadre);
}
function RegistrarSubArea() {
    var codigoArea = $("#idArea").val();
    var esUltimo = $("#indicadorEsUltimo").val();
    if (esUltimo === "1") {
        esUltimo = true;
    }
    var descripcion = $("#txtSubArea").val();
    if (descripcion == null || descripcion == "") {
        return;
    }
    var idPadre = $("#idPadre").val();
    if (idPadre === "") {
        idPadre = null;
    }
    var data = {
        request: {
            IdArea: codigoArea,
            IdHistorial: 1,
            EsUltimo: esUltimo,
            IndicadorHabilitado: true,
            Descripcion: descripcion,
            IdPadre:idPadre
            
        }
    };
    var jqxhr = $.ajax({
        type: "POST",
        url: "RegistrarSubArea",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
    .done(function (data) {
       // $('#myModal').modal('hide');
        $(".btnCloseModal").trigger("click");
        $('.alert').fadeIn();
        setTimeout(function () {
            $(".alert").fadeOut();
            location.reload();
        }, 2500);
        
        ActualizarSubArea();
    })
    .fail(function () {
        swal("Ocurrio un error", "comuniquese con su administrador", "error");
    })
    .always(function () {
    });
}

function ActualizarSubArea() {
    
}

function ActualizarComboSubArea(idArea,idPadre) {
    var data = {
        request: {
            IdArea: idArea,
            IdPadre: idPadre
        }
    };

    var jqxhr = $.ajax({
        type: "POST",
        url: "ListaComboSubArea",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
    .done(function (data) {
            $("#selSubArea").html("");
        //$("#selSubArea").options[select.selectedIndex] = null;
        $("#selSubArea").append('<option value=' + idPadre + '>Ninguno</option>');
        $.each(data, function (key, registro) {
            $("#selSubArea").append('<option value=' + registro.Codigo + '>' + registro.Descripcion + '</option>');
        });

    })
    .fail(function () {
        
    })
    .always(function () {
    });

}

function RegistrarDocumento() {
    var codigoSubArea = $("#selSubArea").val();
    var fileDoc = $("#fileDocumento").val();
    if (codigoSubArea == null || fileDoc == null || codigoSubArea == "" || fileDoc=="") {
        return;
    }
    
    var extensiones = fileDoc.substring(fileDoc.lastIndexOf("."));

    var formData = new FormData();
    //var file = document.getElementById("fileDocumento").files[0];
    //var file = $('#fileDocumento').prop("files")[0];

    //formData.append("file", file);

    formData = new FormData(document.getElementById("formfiledocumento"));
    //var formData = new FormData(document.getElementById("formfiledocumento"));

    //var descripcion = $("#txtSubArea").val();
    //var idPadre = $("#idPadre").val();
    //if (idPadre === "") {
    //    idPadre = null;
    //}

    formData.append("idSubArea", codigoSubArea);

    //var data = {
    //    request: {
    //        IdSubArea: codigoSubArea,
    //        IdHistorial: 1,
    //        EsUltimo: esUltimo,
    //        IndicadorHabilitado: true,
    //        Descripcion: descripcion,
    //        IdPadre: idPadre

    //    }
    //};
    try {
        var jqxhr = $.ajax({
            type: "POST",
            cache: false,
            contentType: false,
            processData: false,
            url: "RegistrarDocumento",
            data: formData,
            //contentType: "application/json; charset=utf-8",
            //dataType: "json"
        })
    .done(function (data) {
        // $('#myModal').modal('hide');
        $(".btnCloseModal").trigger("click");
        $('.alert').fadeIn();
        setTimeout(function () {
            $(".alert").fadeOut();
            location.reload();
        }, 2500);

    })
    .fail(function (error) {
        alert(error);
    })
    .always(function () {
    });
    }
    catch (error) {
        console.error(error);
        alert(error);
        // expected output: ReferenceError: nonExistentFunction is not defined
        // Note - error messages will vary depending on browser
    }
   
}