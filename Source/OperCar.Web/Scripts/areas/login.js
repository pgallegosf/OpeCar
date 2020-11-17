$(document).ready(function () {
    $("#txtEmail").focus();
    $("#btnLogin").on("click", Login);
});

function Login() {
    $(".alert").alert();
    $("#contenedorMensaje").hide();
    $("#btnLogin").addClass("disabled");
    var usuario = $("#txtEmail").val().trim();
    var clave = $("#txtPassword").val().trim();
    if (usuario.length <= 0 || clave.length <= 0) {
        return;
    }

    //var data = {
    //    login: {
    //        Usuario: usuario,
    //        Clave: clave
    //    }
    //};

    var login = {
        Usuario: usuario,
        Clave: clave
    };

    var ajax = $.ajax({
        type: "POST",
        url: "Login/Autenticar",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(login),
        dataType: "json",
        success: function (data) {
            if (data.Success) {
                localStorage.setItem("tokenSW", JSON.stringify(data.Token));
                var url = $("#RedirectTo").val();
                location.href = url;
            } else {
                $("#btnLogin").removeClass("disabled");
                $("#contenedorMensaje").html(divmensaje);
                $("#textAlert").text(data.Error);
                $("#contenedorMensaje").show();

            }

        },
        error: function (data, errorThrown) {
            $("#btnLogin").removeClass("disabled");
            $("#contenedorMensaje").html(divmensaje);
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            $("#textAlert").text(data.Error);
            $("#contenedorMensaje").show();
        }
    });




}

function OcultarMensaje() {
    $("#contenedorMensaje").hide();
}

var divmensaje = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
    "<strong>Error</strong> <span id='textAlert'></span>" +
    "<button type='button' class='close' data-dismiss='alert' aria-label='Close' onclick='OcultarMensaje'>" +
    "<span aria-hidden='true'>&times;</span></button> </div>";