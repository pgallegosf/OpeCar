//================================================================================================================================
/**
 * @fileOverview    Script Organización
 * @since           1.0.0 - 18/11/2019
 * @version         1.0.0 - 01/10/2020
 * @author          Jean Carlos Sánchez Castromonte
*/
//================================================================================================================================
let cboPosition = null;
let count = 0;

document.addEventListener("DOMContentLoaded", function () {
    initFroalaEditor();
    setTimeout(() => { $("html, body").animate({ scrollTop: $('#footer').get(0).scrollTop }, 1000); }, 2000);
    let form_organizacion = document.getElementById("formOrganizacion");
    form_organizacion.addEventListener("submit", function(e) { GuardarOrganizacion(e); });
    $(".organizacion-editar").on("click", ObtenerDatosEdicion);
    $(".organizacion-eliminar").on("click", EliminarOrganizacion);
    $('#btnAddOrganizacion').on("click", LimpiarFormulario);

    cboPosition = document.querySelector('#cbo-position');
    const btnEditMaintenance = document.querySelectorAll('.organizacion-editar');
    btnEditMaintenance.forEach( ( item, index ) => createOptionPosition( cboPosition, index ) );
    count = btnEditMaintenance.length;
});
//================================================================================================================================

function initFroalaEditor() {
    $('#div-contenido').froalaEditor({
        height           : 350,
        zIndex           : 8000,
        language         : 'es',
        theme            : 'gray',
        imageUploadURL   : 'InsertImage',
        imageUploadParams: { id: 'my_image' },
        toolbarButtons: ['fontFamily', 'bold', 'italic','underline','strikeThrough','fontSize','|','color','paragraphFormat',
        'indent', 'outdent', 'formatOL', 'formatUL', '|', 'insertLink', 'insertImage', 'insertTable', 'emoticons']
    })   
    .on ('froalaEditor.image.removed', function (e, editor, $img) {
        let filePath = "~" + $img.attr('src');
        let data      = {};
        data.filePath = filePath;

        fetch("DeleteImage", {
            method : 'POST',
            body   : JSON.stringify(data),
            headers: { 'Content-Type': 'application/json' }
        })
        .then((response) => response.json())
        .catch((error) => console.error('Error:', error))
        .then((resp) => {
            console.log(resp);
        });
    });
}
//================================================================================================================================

function GuardarOrganizacion(e) {
    e.preventDefault();
    let data = {};
    data.idOrganizacion = document.getElementById("txtIdOrganizacion").value;
    data.titulo         = document.getElementById("txtTitulo").value;
    data.contenido      = $('#div-contenido').froalaEditor('html.get');
    data.posicion       = document.getElementById("cbo-position").value;
    fetch("RegistrarOrganizacion", {
        method : 'POST',
        body   : JSON.stringify(data),
        headers: { 'Content-Type': 'application/json' }
    })
    .then(response => {
        $(".btnCloseModal").trigger("click");
        $(".alert-link").html("Se realizó el registro correctamente");
        $('.alert').fadeIn();
        setTimeout(() => { $(".alert").fadeOut(); location.reload();}, 2500);
    })
    .catch(error => console.error('Error:', error));
}
//================================================================================================================================

function ObtenerDatosEdicion() {
    const cboPositionOption = document.querySelectorAll('#cbo-position option');
    rebuildOptionsPosition(cboPosition, cboPositionOption, count);
    var idOrganizacion = $(this).data("id");
    var titulo         = $(this).data("titulo");
    var contenido      = $(this).data("contenido");
    var posicion       = $(this).data("posicion");
    $("#txtIdOrganizacion").val(idOrganizacion);
    $("#txtTitulo").val(titulo);
    $('#div-contenido').froalaEditor('html.set', contenido);
    $("#cbo-position").val(posicion);
}
//================================================================================================================================

function EliminarOrganizacion() {
    var opcion = confirm("¿Desea eliminar el contenido?");
    if (!opcion) { return; }
    var idOrganizacion = $(this).data("id");
    var data = {
        request: {
            IdSeccion: idOrganizacion,
            IndicadorHabilitado: false
        }
    };
    $.ajax({
        type       : "POST",
        url        : "/Organizacion/EliminarOrganizacion",
        data       : JSON.stringify(data),
        contentType: "application/json; charset = utf-8",
        dataType   : "json"
    })
    .done(function (data) {
        $(".alert-link").html("Se eliminó el contenido");
        $('.alert').fadeIn();
        setTimeout(function () { $(".alert").fadeOut(); location.reload(); }, 2500);
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        alert('Uncaught Error: ' + jqXHR.responseText);
    });
}
//================================================================================================================================

function LimpiarFormulario() {
    const lastPosition = ( count + 1 );
    const cboPositionOption = document.querySelectorAll('#cbo-position option');
    rebuildOptionsPosition(cboPosition, cboPositionOption, lastPosition);

    $("#txtIdOrganizacion").val("");
    $("#txtTitulo").val("");
    $('#div-contenido').froalaEditor('html.set', "");
    $("#cbo-position").val(lastPosition);
}
//================================================================================================================================