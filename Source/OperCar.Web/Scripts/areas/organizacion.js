document.addEventListener("DOMContentLoaded", function () {
    $(".organizacion-editar").on("click", ObtenerDatosEdicion);
    $(".organizacion-eliminar").on("click", EliminarOrganizacion);
    $('#btnAddOrganizacion').on("click", LimpiarFormulario);
});

function LimpiarFormulario() {
    $("#txtIdOrganizacion").val("");
    $("#fileImagen").val("");
    $("#txtTitulo").val("");
    $("#txtContenido").val("");
    $("#txtPosicion").val(0);
    $("#lblFileImagen").html("Seleccionar Imagen");
}

document.addEventListener("DOMContentLoaded", function () {
    $("#formOrganizacion").on("submit", function (e) {
        e.preventDefault();
        var fileImg = $("#fileImagen").val();
        var titulo = $("#txtTitulo").val();
        var contenido = $("#txtContenido").val();
        var posicion = $("#txtPosicion").val();
        if (titulo == "" || contenido == "") {
            return;
        }
        if (fileImg !== "") {
            var extension = fileImg.substring(fileImg.lastIndexOf("."));
            if (extension !== ".jpg" && extension !== ".png" && extension !== ".jpeg") {
                alert("La extención de la imagen no es soportada");
                return;
            }
        }

        var formData = new FormData(document.getElementById("formOrganizacion"));
        $.ajax({
            url: "RegistrarOrganizacion",
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

function MostrarNombreImagen() {
    var nombreImg = document.getElementById('fileImagen').files[0].name;
    $("#lblFileImagen").html(nombreImg);
}

function ObtenerDatosEdicion() {
    var idOrganizacion = $(this).data("id");
    var titulo = $(this).data("titulo");
    var urlimg = $(this).data("urlimg");
    var contenido = $(this).data("contenido");
    var posicion = $(this).data("posicion");
    if (urlimg !== "") {
        var nombreImg = urlimg.replace("/Content/images/", "");
        $("#lblFileImagen").html(nombreImg);
    }
    $("#txtIdOrganizacion").val(idOrganizacion);
    $("#txtTitulo").val(titulo);
    $("#txtContenido").val(contenido);
    $("#txtPosicion").val(posicion);

}
function EliminarOrganizacion() {
    var opcion = confirm("¿Desea eliminar el contenido?");
    if (!opcion) {
        return;
    }
    var idOrganizacion = $(this).data("id");
    var data = {
        request: {
            IdSeccion: idOrganizacion,
            IndicadorHabilitado: false

        }
    };
    var jqxhr = $.ajax({
        type: "POST",
        url: "/Organizacion/EliminarOrganizacion",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
    .done(function (data) {
        $(".alert-link").html("Se eliminó el contenido");
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