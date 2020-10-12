//================================================================================================================================
/**
 * @fileOverview    Script de mantenimiento
 * @since           1.0.0 - 17/12/2019
 * @version         1.0.0 - 01/10/2020
 * @author          Jean Carlos Sánchez Castromonte
*/
//================================================================================================================================
let countMenuFooter   = 0;
let cboPosition       = null;
document.addEventListener("DOMContentLoaded", function () {
    window.scrollTo(0, 0);
    initDropify($('.dropify'));
    cboPosition = document.querySelector('#cbo-mf-position');
    const btnEditMenuFooter = document.getElementsByClassName("btn-edit-menu-footer");
    Array.from(btnEditMenuFooter).forEach(function ( element, index ) {
        element.addEventListener('click', setFormEditMenuFooter);
        createOptionPosition( cboPosition, index );
    });
    countMenuFooter = btnEditMenuFooter.length;

    document.getElementById("btn-add-menu-footer").addEventListener("click", clearFormMenuFooter);    
    document.getElementById("btn-save-maintenance").addEventListener("click", (event) => saveFormMaintenance(event));
    document.getElementById("btn-save-menu-footer").addEventListener("click", (event) => saveFormMenuFooter(event));   
});
//================================================================================================================================
function initDropify($selector) {
    $selector.dropify({
        messages: {
            'default': 'Arrastra y suelta un archivo aqui o haz clic',
            'replace': 'Arrastra y suelta o haz clic para reemplazar',
            'remove': 'Eliminar',
            'error': 'Vaya, algo malo sucedió.'
        },
        error: {
            'fileSize': 'El tamaño de la imagen es muy grande ({{ value }} max).',
            'fileExtension': 'El archivo no está permitido (Sólo imágenes)'
        }
    });    
}
//================================================================================================================================

function setFormEditMenuFooter() {
    const cboPositionOption = document.querySelectorAll('#cbo-mf-position option');
    rebuildOptionsPosition( cboPosition, cboPositionOption, countMenuFooter );

    document.getElementById("txt-mf-id").value       = this.getAttribute("data-id");
    document.getElementById("txt-mf-nombre").value   = this.getAttribute("data-nombre");
    document.getElementById("txt-mf-url").value      = this.getAttribute("data-url");
    document.getElementById("cbo-mf-position").value = this.getAttribute("data-position");

    if(this.getAttribute("data-status") == "True") {
        document.getElementById("rd-mf-active").checked = true;
    }
    else {
        document.getElementById("rd-mf-inactive").checked = true;
    }
    document.getElementById("chk-mf-is-super-user").checked = this.getAttribute("data-is-super-user") == "True";    
}
//================================================================================================================================

function clearFormMenuFooter() {
    const lastPosition = ( countMenuFooter + 1 );
    const cboPositionOption = document.querySelectorAll('#cbo-mf-position option');
    rebuildOptionsPosition( cboPosition, cboPositionOption, lastPosition );

    document.getElementById("txt-mf-id").value              = "";
    document.getElementById("txt-mf-nombre").value          = ""
    document.getElementById("txt-mf-url").value             = "";
    document.getElementById("cbo-mf-position").value        = lastPosition;
    document.getElementById("rd-mf-active").checked         = true;
    document.getElementById("chk-mf-is-super-user").checked = false;
}
//================================================================================================================================

function saveFormMaintenance( event ) {
    event.preventDefault();    

    let maintenaceId            = document.getElementById("txt-maintenance-id").value;
    let maintenaceLogo          = document.getElementById("txt-maintenance-logo");
    let maintenaceTelefono      = document.getElementById("txt-maintenance-telefono").value;
    let maintenaceSobreNosotros = document.getElementById("txt-maintenance-sobre-nosotros").value;
    let maintenaceDereReserv    = document.getElementById("txt-maintenance-derechos-reservados").value;

    var data = new FormData();
    data.append('MantenimientoId', maintenaceId);
    if(maintenaceLogo.files[0]) {
        data.append('MantenimientoLogoImage', maintenaceLogo.files[0]);
    }
    data.append('MantenimientoTelefono', maintenaceTelefono);
    data.append('MantenimientoSobreNosotros', maintenaceSobreNosotros);
    data.append('MantenimientoDerechosReservados', maintenaceDereReserv);

    fetch("GuardarMantenimiento", {
        method : 'POST',
        body   : data
    })
    .then(response => {
        document.querySelectorAll(".btnCloseModal")[0].click();
        $(".alert").fadeIn();
        setTimeout(() => { $(".alert").fadeOut(); location.reload();}, 2000);
    })
    .catch(error => console.log(error));
}
//================================================================================================================================

function saveFormMenuFooter( event ) {
    event.preventDefault();

    let data                   = {};
    data.MenuFooterId          = document.getElementById("txt-mf-id").value;
    data.MantenimientoId       = 1;
    data.MenuFooterName        = document.getElementById("txt-mf-nombre").value;
    data.MenuFooterUrl         = document.getElementById("txt-mf-url").value;
    data.MenuFooterPosition    = document.getElementById("cbo-mf-position").value;
    data.MenuFooterStatus      = document.querySelector('input[name="rd-status"]:checked').value == "true";   
    data.MenuFooterIsSuperUser = document.getElementById("chk-mf-is-super-user").checked;
    
    fetch("GuardarMenuFooter", {
        method : 'POST',
        body   : JSON.stringify(data),
        headers: { 'Content-Type': 'application/json' }
    })
    .then(response => {
        document.querySelectorAll(".btnCloseModal")[1].click();
        $(".alert").fadeIn();
        setTimeout(() => { $(".alert").fadeOut(); location.reload();}, 2000);
    })
    .catch(error => console.log(error));
}
//================================================================================================================================
