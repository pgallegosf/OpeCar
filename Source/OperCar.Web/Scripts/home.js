$(document).ready(function () {
    var altoVentana = 36;
    var posicionVentana = document.getElementById("topBar").offsetTop;
    $(window).scroll(function (event) {
        var posicionScroll = $(this).scrollTop();
        if (posicionScroll > (parseInt(posicionVentana) + parseInt(altoVentana))) {
            $("#masthead").addClass("navbar-scrolled navbar-stuck");
        } 
    });
    OcultarTopBar();
    initInfoMantenimiento();

    $("#btn-search-document").on('click', function() {
        $('#txt-search-document').val('');
        $('.div-document').html(`<div style="text-align:center;width:100%;">
        <i class="fa fa-search" style="color:gray;font-size:50px;"></i>
        </div>`);
        $('#modal-search-document').modal({backdrop: 'static', keyboard: false});
        setTimeout(() => {
            $('#txt-search-document').focus();
        }, 500);
    });

    $('#txt-search-document').on('keyup', function() {
        $('.div-document').empty();
        let descripcionDocumento = $(this).val();
        if(descripcionDocumento != '') {
            let data = {};
            data.descripcion = descripcionDocumento;

            fetch('../SIG/BuscarDocumento', {
                method : 'POST',
                body   : JSON.stringify(data),
                headers: { 'Content-Type': 'application/json' }
            })
            .then((response) => response.json())
            .catch((error) => console.error('Error:', error))
            .then((response) => {
                if(response.length > 0) {
                    response.forEach(element => {
                        let imageTypeDoc = getIconTypeDocument(element.IdTipoDocumento);
                        $('.div-document').append(`<div class="col-sm-6 col-lg-3" style="padding-bottom: 15px;">
                            <div class="card">
                                <img class="card-img-top" src="${ imageTypeDoc }" height="auto" width="auto" alt="img descarga"/>
                                <div class="card-body card-body-doc">
                                    <h5 class="nombre-doc">${ element.Descripcion }</h5>
                                    <div class="div-btn-descarga">
                                        <a href="${ (element.UrlDocumento).replace('~', '..') }" target="_blank" class="botondescarga" data-doccode="${ element.Codigo }">
                                            Descargar
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>`);
                    });    
                }
                else {
                    $('.div-document').html(`<div style="text-align:center;width:100%;">
                    <i class="fa fa-search" style="color:gray;font-size:50px;"></i>
                    </div>`);
                }
            });
        }
        else {
            $('.div-document').html(`<div style="text-align:center;width:100%;">
            <i class="fa fa-search" style="color:gray;font-size:50px;"></i>
            </div>`);
        }
    });
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
const getIconTypeDocument = (idTipoDocumento) => {
    let imageTypeDoc = '';
    switch(idTipoDocumento) {
        case 1:
            imageTypeDoc = '../Content/images/pdf_imagev4.jpg';
            break;
        case 2:
            imageTypeDoc = '../Content/images/word_imagev4.png';
            break;
        case 3:
            imageTypeDoc = '../Content/images/excel_imagev4.png';
            break;
        case 4:
            imageTypeDoc = '../Content/images/ppt_imagev4.png';
            break;
        default:
            imageTypeDoc = '../Content/images/otro_imagev4.png';
            break;                            
    }
    return imageTypeDoc;
}
//================================================================================================================================
const createOptionPosition = ( selCbo, index ) => {
    const option = document.createElement('option');
    option.setAttribute('value', ( index + 1) );
    option.innerText = `${( index + 1)}`;
    selCbo.appendChild(option);
}
//================================================================================================================================
const rebuildOptionsPosition = ( selCbo, selCboAllOption, count ) => {
    selCboAllOption.forEach( item => item.remove() );
    for(let i = 0; i < count; i++) {
        createOptionPosition( selCbo, i );
    }
}
//================================================================================================================================
