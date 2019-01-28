$(document).ready(function () {
    //var altoVentana = $('#Ventana').css('height').replace("px","");//usa este para que desaparezca despues de pasar el alto del div
    var altoVentana = 36;
    var posicionVentana = document.getElementById("topBar").offsetTop;
    $(window).scroll(function (event) {
        var posicionScroll = $(this).scrollTop();
        if (posicionScroll > (parseInt(posicionVentana) + parseInt(altoVentana))) {
            $("#masthead").addClass("navbar-scrolled navbar-stuck");
        } else {
            //$("#masthead").removeClass("navbar-scrolled navbar-stuck");
        }

    });
    OcultarTopBar();
    $(".OpenDoc").on("click", AbrirDoc);
    
});

function OcultarTopBar() {
    var altoVentana = 36;
    var posicionVentana = document.getElementById("topBar").offsetTop;
    $(window).scroll(function (event) {
        var scrollBottom =$(document).height() - $(window).height() - $(window).scrollTop();
        var posicionScroll = $(this).scrollTop();
        if (posicionScroll == (parseInt(posicionVentana) + 0)) {
            $("#masthead").removeClass("navbar-scrolled navbar-stuck");
            //$("#masthead").removeClass("navbar-scrolled navbar-stuck");
            //$("#masthead").addClass("navbar-scrolled navbar-stuck");
        } else {
            //$("#masthead").removeClass("navbar-scrolled navbar-stuck");
        }

    });
}
