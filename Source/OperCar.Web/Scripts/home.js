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
    initInfoMantenimiento();
});
//================================================================================================================================

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
//================================================================================================================================
/**
 * Inicializar información de la organización.
 * 
 * @author  Jean Carlos Sánchez Castromonte
 */
async function initInfoMantenimiento() {   
    let mantenimientoId = await listarMantenimiento();
    await listarMenuFooter(mantenimientoId);
}
//================================================================================================================================
/**
 * Mostrar información de la organización.
 * 
 * @author  Jean Carlos Sánchez Castromonte
 * @return  {Number} mantenimientoId
 */
async function listarMantenimiento() { 
    let mantenimientoId        = 0;
    let mantLogo               = document.getElementById("mant-logo");
    let mantTelefono           = document.getElementById("mant-telefono");
    let mantDerechosReservados = document.getElementById("mant-derechos-reservados");
    let mantSobreNosotros      = document.getElementById("mant-sobre-nosotros");
    await fetch("/Organizacion/ListarMantenimiento", {
        method : 'GET',
        headers: { 'Content-Type': 'application/json' }
    })
    .then((response) => response.json())
    .then((response) => {
        mantenimientoId                  = response[0].MantenimientoId;
        mantLogo.innerHTML               = `<img src = "${response[0].MantenimientoLogo}" alt = "logo" style = "width: 100%;max-height: 60px;height: auto;"></img>`;
        mantTelefono.innerHTML           = response[0].MantenimientoTelefono;
        mantSobreNosotros.innerHTML      = response[0].MantenimientoSobreNosotros;
        mantDerechosReservados.innerHTML = response[0].MantenimientoDerechosReservados;
    });
    return mantenimientoId;
}
//================================================================================================================================
/**
 * Mostrar menu de pie de pagina.
 *
 * @param   {Number}  mantenimientoId
 */
async function listarMenuFooter(mantenimientoId) {
    let isSuperAdmin = document.getElementById("txtEsSuperAdmin").value == 'True' ? 1 : 0;
    let data = {};
    data.mantenimientoId = mantenimientoId;
    await fetch("/Organizacion/ListarMenuFooter", {
        method : 'POST',
        body   : JSON.stringify(data),
        headers: { 'Content-Type': 'application/json' }
    })
    .then((response) => response.json())
    .then((response) => {
        response.forEach(function (item, index) {
            let itemIsSuperAdmin = item.MenuFooterIsSuperAdmin ? 1 : 0;
            if(isSuperAdmin >= itemIsSuperAdmin) {
                if(item.MenuFooterStatus == true) {
                    document.getElementById("mant-menu-footer").innerHTML += `
                    <li class="list-group-item">
                        <a href="${item.MenuFooterUrl}">${item.MenuFooterName}</a>
                    </li>`;
                }
            }
        });
    });
}
//================================================================================================================================