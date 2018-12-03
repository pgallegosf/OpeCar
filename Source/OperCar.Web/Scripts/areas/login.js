$(document).ready(function () {
    $("#txtEmail").focus();
    $("#btnLogin").on("click", Login);
});

function Login() {

    $("#contenedorMensaje").hide();
    $("#btnLogin").addClass("disabled");
    var usuario = $("#txtEmail").val().trim();
    var clave = $("#txtPassword").val().trim();
    if (usuario.length <= 0 || clave.length <= 0) {
        return;
    }
    var login = {
        Usuario: usuario,
        Clave: clave
    };
    if (login.Usuario === "admin" && login.Clave == "1234") {
        window.location.replace("Home");
    }
    else {
        $("#btnLogin").removeClass("disabled");
        $("#contenedorMensaje").show();
        $("#contenedorMensaje").text("Usuario y/o contraseña incorrectos");
    }

    //var ajax = $.ajax({
    //    type: "POST",
    //    url: "Login/Autenticar",
    //    contentType: "application/json; charset=utf-8",
    //    data: JSON.stringify(login),
    //    dataType: "json",
    //    success: function (data) {
    //        if (data.Success) {
    //            localStorage.setItem("tokenSW", JSON.stringify(data.Token));
    //            window.location.replace("Home");
    //        } else {
    //            $("#btnLogin").removeClass("disabled");
    //            $("#contenedorMensaje").show();
    //            $("#contenedorMensaje").text(data.Error);

    //        }

    //    }
    //});

}