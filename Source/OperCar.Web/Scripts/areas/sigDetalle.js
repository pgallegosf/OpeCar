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
    $(".subArea-edit").on("dblclick", MostrarEdicionSubArea);
    $(".subareaUltimo-edit").on("dblclick", MostrarEdicionSubAreaUltimo);
    $(".subArea-eliminar").on("click", EliminarSubArea); 
    $(".txtDescripcionSubArea").keyup(function (event) {
        if (event.keyCode === 13) {
            var idSubArea = $(this).data("idsubarea");
            var descripcion = $(this).val();
            var btnDescripcion = ".descripcionSubArea" + "." + idSubArea + ">button.btn-titulo";
            var btnEliminar = ".descripcionSubArea" + "." + idSubArea + ">button.subArea-eliminar";

            var data = {
                request: {
                    Codigo: idSubArea,
                    IndicadorHabilitado: true,
                    Descripcion: descripcion

                }
            };

            var jqxhr = $.ajax({
                type: "POST",
                url: "/SIG/EditarSubArea",
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            })
    .done(function (data) {
        // $('#myModal').modal('hide');
        $(btnDescripcion).html(descripcion);
        $(btnEliminar).show();
        $(btnDescripcion).show();
    })
    .fail(function (e) {
        alert("Ocurrio un error", "comuniquese con su administrador", e);
    })
    .always(function () {
    });
            $(this).hide();
        }
    });

    $(".txtDescripcionSubAreaUltimo").keyup(function (event) {
        if (event.keyCode === 13) {
            var idSubArea = $(this).data("idsubarea");
            var descripcion = $(this).val();
            var btnDescripcion = ".descripcionSubArea" + "." + idSubArea + ">span";
            var btnEliminar = ".descripcionSubArea" + "." + idSubArea + ">button";

            var data = {
                request: {
                    Codigo: idSubArea,
                    IndicadorHabilitado: true,
                    Descripcion: descripcion

                }
            };

            var jqxhr = $.ajax({
                type: "POST",
                url: "/SIG/EditarSubArea",
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            })
    .done(function (data) {
        // $('#myModal').modal('hide');
        $(btnDescripcion).html(descripcion);
        $(btnEliminar).show();
        $(btnDescripcion).show();
    })
    .fail(function (e) {
        alert("Ocurrio un error", "comuniquese con su administrador", e);
    })
    .always(function () {
    });
            $(this).hide();
        }
    });

    //$('#btnGuardarDocumento').on("click", RegistrarDocumento);
    $(".alert").alert();
    //$('#btnAddSubAreaSec').on("click", ActualizarDatosSubArea);

});



function HabilitarActive() {
    var clase = $(this).data("id");
    $(this).parent().find(".active").each(function () {
        $(this).removeClass("active");
    });
    $(this).addClass("active");
    $(".card-subArea").hide();
    $("." + clase).show();

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

function ActualizarDatosSubAreaSec(codArea, idPadre, esUltimo) {
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
            IdPadre: idPadre

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

function ActualizarComboSubArea(idArea, idPadre) {
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
    if (codigoSubArea == null || fileDoc == null || codigoSubArea == "" || fileDoc == "") {
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
        $(".alert-link").html("Se realizó el registro correctamente");
        $('.alert').fadeIn();
        setTimeout(function () {
            $(".alert").fadeOut();
            location.reload();
        }, 2500);

    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        alert('Uncaught Error: ' + jqXHR.responseText);
        console.log(jqXHR);
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
document.addEventListener("DOMContentLoaded", function () {
    $("#formfiledocumento").on("submit", function (e) {
        e.preventDefault();
        var f = $(this);
        var codigoSubArea = $("#selSubArea").val();
        var formData = new FormData(document.getElementById("formfiledocumento"));
        //formData.append("idSubArea", codigoSubArea);
        //formData.append(f.attr("name"), $(this)[0].files[0]);
        $.ajax({
            url: "RegistrarDocumento",
            type: "post",
            dataType: "html",
            data: formData,
            cache: false,
            contentType: false,
            processData: false
        })
            .done(function (res) {
                $("#mensaje").html("Respuesta: " + res);
                $(".btnCloseModal").trigger("click");
                $(".alert-link").html("Se realizó el registro correctamente");
                $('.alert').fadeIn();
                setTimeout(function () {
                    $(".alert").fadeOut();
                    location.reload();
                }, 2500);

            })
    .fail(function (jqXHR, textStatus, errorThrown) {
        alert('Uncaught Error: ' + jqXHR.responseText);

    })
    .always(function () {
    });
    });
});
function MostrarNombreArchivo() {
    var nombreDoc = document.getElementById('fileDocumento').files[0].name;
    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        if (nombreDoc.length > 20) {
        nombreDoc = nombreDoc.substring(0, 20)+"...";
        }      
    }
    else if (nombreDoc.length>35){
        nombreDoc = nombreDoc.substring(0, 35) + "...";
    }
    $("#lblFileDocumento").html(nombreDoc);

}

function EliminarDocumento(codigo) {

    var data = {
        idDocumento: codigo
    };
    var jqxhr = $.ajax({
        type: "POST",
        url: "EliminarDocumento",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
    .done(function (data) {
        $(".alert-link").html("Se eliminó el documento");
        $('.alert').fadeIn();
        setTimeout(function () {
            $(".alert").fadeOut();
            location.reload();
        }, 2500);

    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        alert('Uncaught Error: ' + jqXHR.responseText);

    })
    .always(function () {
    });
}

function MostrarEdicionSubArea() {
    var idSubArea = $(this).data("idsubarea");
    var control = ".descripcionSubArea" + "." + idSubArea + ">button";
    var controlTxt = ".descripcionSubArea" + "." + idSubArea + ">.txtDescripcionSubArea";
    $(control).hide();
    var descripcion = $(controlTxt).val();
    $(controlTxt).val(descripcion);
    $(controlTxt).show();
    $(controlTxt).focus();
}
function MostrarEdicionSubAreaUltimo() {
    var idSubArea = $(this).data("idsubarea");
    var control = ".descripcionSubArea" + "." + idSubArea + ">span";
    var controlEliminar = ".descripcionSubArea" + "." + idSubArea + ">button";
    var controlTxt = ".descripcionSubArea" + "." + idSubArea + ">.txtDescripcionSubAreaUltimo";
    $(control).hide();
    $(controlEliminar).hide();
    var descripcion = $(controlTxt).val();
    $(controlTxt).val(descripcion);
    $(controlTxt).show();
    $(controlTxt).focus();
}
function EliminarSubArea() {
    var opcion = confirm("¿Desea eliminar la carpeta?");
    if (!opcion) {
        return;
    } 
    var idSubArea = $(this).data("idsubarea");
    var data = {
        request: {
            Codigo: idSubArea,
            IndicadorHabilitado: false

        }
    };
    var jqxhr = $.ajax({
        type: "POST",
        url: "/SIG/EliminarSubArea",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
    .done(function (data) {
        $(".alert-link").html("Se eliminó la carpeta");
        $('.alert').fadeIn();
        setTimeout(function () {
            $(".alert").fadeOut();
            location.reload();
        }, 2500);

    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        alert('Uncaught Error: ' + jqXHR.responseText);

    })
    .always(function () {
    });
}
//================================================================================================================================

/*****************************************
| Mover carpeta o archivo
******************************************/
let level       = 0;
let idarea      = 0;
let idpadre     = 0;
let idSubarea   = 0;
let idDocumento = 0;
let descSubArea  = "";
//================================================================================================================================
function seleccionarSubAreaDocumento() {
    level       = parseInt($(this).attr("data-level"));
    idarea      = $(this).attr("data-idarea");
    idpadre     = $(this).attr("data-idpadre");
    idSubarea   = $(this).attr("data-idsubarea");
    idDocumento = $(this).attr("data-doccode");
    descSubArea = $(this).attr("data-descsubarea");
    
    switch(level) {
        case 1:
            $(".div-carpeta").hide();
            $(".div-subcarpeta").hide();
            break;
        case 2:
            $(".div-carpeta").show();
            $(".div-subcarpeta").hide();
            break;
        case 3:
            $(".div-carpeta").show();
            $(".div-subcarpeta").show();
            break;
    }
    ListarArea(idarea);
}
//================================================================================================================================
function ListarArea(idarea) {
    var data = {
        request: {IdTipoArea: 2}
    };
    $.ajax({
        type: "POST",
        url: "/SIG/ListarArea",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
    .done(function (data) {
        if(data.length > 0) {
            $("#mov-area").empty();
            $.each(data, function (key, item) {
                $("#mov-area").append('<option value=' + item.IdArea + '>' + item.Descripcion + '</option>');
            });
            $("#mov-area").val(idarea).trigger("change");
            $("#modalMoverDocumento").modal({backdrop: 'static', keyboard: false});
        }
    })
    .fail(function () {})
    .always(function () {});
}
//================================================================================================================================
function ListarSubArea($select, idarea, idpadre, idsubarea, isfather) {
    var data = {
        request: {
            IdArea: idarea,
            IdPadre: isfather ? idpadre : null
        }
    };
    $.ajax({
        type: "POST",
        url: "ListaComboSubArea",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })

    .done(function (data) {
        $select.html('<option value="0">Seleccione...</option>');
        if(data.length > 0) {
            let isIdExist = false;
            let idSelected = isfather ? idsubarea : idpadre;
            $.each(data, function (key, item) {
                $select.append('<option value=' + item.Codigo + '>' + item.Descripcion + '</option>');
                if(idSelected == item.Codigo) {
                    isIdExist = true;
                }
            });
            $select.val(isIdExist ? idSelected : 0).trigger("change");
        }
        else {
            $select.val(0).trigger("change");
        }        
    })
    .fail(function () {})
    .always(function () {});
}
//================================================================================================================================
function moverDocumento() {
    let isVisibleSubArea = $("#mov-subarea").is(':visible');
    let isSelectedSubArea = $("#mov-subarea").val() != 0;
    if(isVisibleSubArea && !isSelectedSubArea) {
        return;
    }
    idSubarea = idSubarea == 0 ? idpadre: idSubarea;
    idpadre   = idpadre ? idpadre: null;

    if(idSubarea != 0) {
        let data = {};
        data.idDocumento = idDocumento ? idDocumento : null;
        data.idSubArea   = idSubarea;
        data.idArea      = idarea;
        data.idPadre     = idpadre;
        data.isDocument  = level == 3;

        fetch('../SIG/MoverDocumento', {
            method : 'POST',
            body   : JSON.stringify(data),
            headers: { 'Content-Type': 'application/json' }
        })
        .then(response => {
            $("#modalMoverDocumento").modal("hide");
            $(".alert-link").html("Se movió correctamente");
            $('.alert').fadeIn();
            setTimeout(function () { $(".alert").fadeOut(); location.reload(); }, 2500);
        })
        .catch(error => console.error(error));
    }
    else {
        $("#label-error-subarea").html('<div style="padding-top:10px;">Es Obligatorio</div>');
    }
}
//================================================================================================================================
$(".subArea-mover").on("click", seleccionarSubAreaDocumento);

$("#mov-area").on("change", function() {    
    idarea = $(this).val();
    ListarSubArea($("#mov-subarea"), idarea, idpadre, idSubarea, false);
});

$("#mov-subarea").on("change", function() {
    if(level != 1) {
        idpadre = $(this).val();
    }
    if(idpadre != 0 && idpadre != null) {
        $("#label-error-subarea").empty();       
    }
    else {
        $("#label-error-subarea").html('<div style="padding-top:10px;">Es Obligatorio</div>');
    }
    ListarSubArea($("#mov-subarea-2"), idarea, idpadre, idSubarea, true);
});

$("#mov-subarea-2").on("change", function() {
    if(level == 3) {
        idSubarea = $(this).val();
    }
});

$("#btn-mover-documento").on("click", moverDocumento);
//================================================================================================================================