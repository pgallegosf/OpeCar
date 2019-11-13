document.addEventListener("DOMContentLoaded", function () {
    $(".area-edit").on("dblclick", MostrarEdicionArea);
    $('#btnGuardarArea').on("click", RegistrarArea);
    $(".area-eliminar").on("click", EliminarArea);
    $(".txtDescripcionArea").keyup(function (event) {
        if (event.keyCode === 13) {
            var idArea = $(this).data("idarea");
            var descripcion = $(this).val();
            var control = ".descripcionArea" + "." + idArea + ">span";

            var data = {
                request: {
                    Codigo: idArea,
                    IndicadorHabilitado: true,
                    Descripcion: descripcion

                }
            };

            var jqxhr = $.ajax({
                type: "POST",
                url: "/SIG/EditarArea",
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            })
    .done(function (data) {
        // $('#myModal').modal('hide');
        $(control).html(descripcion);

        $(control).show();
    })
    .fail(function (e) {
        alert("Ocurrio un error", "comuniquese con su administrador", e);
    })
    .always(function () {
    });
            $(this).hide();
        }
    });
});
function MostrarEdicionArea() {
    var idArea = $(this).data("idarea");
    var control = ".descripcionArea" + "." + idArea + ">span";
    var controlTxt = ".descripcionArea" + "." + idArea + ">.txtDescripcionArea";
    $(control).hide();
    var descripcion = $(controlTxt).val(); //$(this).data("descripcion");
    $(controlTxt).val(descripcion);
    $(controlTxt).show();
    //$(control).html('<input type="text" class="form-control txtDescripcionAra" >');
}


function RegistrarArea() {
    //var codigoArea = $("#idArea").val();
    //var esUltimo = $("#indicadorEsUltimo").val();
    //if (esUltimo === "1") {
    //    esUltimo = true;
    //}
    var descripcion = $("#txtArea").val();
    if (descripcion == null || descripcion == "") {
        return;
    }
    
    var data = {
        request: {
            IdHistorial: 1,
            IndicadorHabilitado: true,
            Descripcion: descripcion

        }
    };
    var jqxhr = $.ajax({
        type: "POST",
        url: "/SIG/RegistrarArea",
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

        //ActualizarArea();
    })
    .fail(function () {
        alert("Ocurrio un error", "comuniquese con su administrador", "error");
    })
    .always(function () {
    });
}

function EliminarArea() {
    var opcion = confirm("¿Desea eliminar la carpeta?");
    if (!opcion) {
        return;
    }
    var idArea = $(this).data("idarea");
    var data = {
        request: {
            Codigo: idArea,
            IndicadorHabilitado: false

        }
    };
    var jqxhr = $.ajax({
        type: "POST",
        url: "/SIG/EliminarArea",
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