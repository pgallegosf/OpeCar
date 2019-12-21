document.addEventListener("DOMContentLoaded", function () {
    $(".OpenDoc").on("click", AbrirDoc);
    $(".aplicacion-editar").on("click", ObtenerDatosEdicion);
    $(".aplicacion-eliminar").on("click", EliminarAplicacion);
    $('#btnAddAplicacion').on("click", LimpiarFormulario);
});

function LimpiarFormulario() {
    $("#txtIdAplicacion").val("");
    $("#fileImagen").val("");
    $("#txtAplicacion").val("");
    $("#txtEnlace").val("");
    $("#lblFileImagen").html("Seleccionar Imagen");
}
function AbrirDoc() {

    //var descripcion = $("#descripcionCobertura").val();
    var data = {};
    //data.archivo = "\\\\10.10.101.17\\shared\\Nue.txt";
    //"\\10.15.61.15\Bd_Cae\CAE_OSITRAN";
    //data.archivo = "\\\\10.10.101.25\\\dq_pv\\Incidencias.xlsx";
    data.archivo = "D:\\Cuentas\\Libro1.xlsx";
    

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

document.addEventListener("DOMContentLoaded", function () {
    $("#formAplicacion").on("submit", function (e) {
        e.preventDefault();
        var fileImg = $("#fileImagen").val();
        var descripcion = $("#txtAplicacion").val();
        var enlace = $("#txtEnlace").val();
        if (descripcion == null ||  enlace == "" || descripcion == "") {
            return;
        }
        if (fileImg !== "") {
            var extension = fileImg.substring(fileImg.lastIndexOf("."));
            if (extension !== ".jpg" && extension !== ".png" && extension !== ".jpeg") {
                alert("La extención de la imagen no es soportada");
                return;
            }
        }
       
        var formData = new FormData(document.getElementById("formAplicacion"));
        $.ajax({
            url: "RegistrarAplicacion",
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
    var idAplicacion = $(this).data("id");
    var enlace = $(this).data("enlace");
    var urlimg = $(this).data("urlimg");
    var descripcion = $(this).data("descripcion");
    
    var nombreImg = urlimg.replace("/Content/images/", "");
    
    $("#txtIdAplicacion").val(idAplicacion);
    $("#txtAplicacion").val(descripcion);
    $("#txtEnlace").val(enlace);

    setTextFileImage(nombreImg);

}

function setTextFileImage(nombreImg) {
    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        if (nombreImg.length > 20) {
            $("#lblFileImagen").html(nombreImg.substring(0, 20) + '...');
        }
    }
    else {
        $("#lblFileImagen").html(nombreImg);
    }
}


function EliminarAplicacion() {
    var opcion = confirm("¿Desea eliminar la aplicación?");
    if (!opcion) {
        return;
    }
    var idAplicacion = $(this).data("id");
    var data = {
        request: {
            IdEnlace: idAplicacion,
            IndicadorHabilitado: false

        }
    };
    var jqxhr = $.ajax({
        type: "POST",
        url: "/Aplicacion/EliminarAplicacion",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
    .done(function (data) {
        $(".alert-link").html("Se eliminó la aplicación");
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