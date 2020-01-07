$(document).ready(function () {
   
    //$('#btnSave').on('click', function () {
    //    var checkedIds = tree.getCheckedNodes();
    //    $.ajax({ url: '/Locations/SaveCheckedNodes', data: { checkedIds: checkedIds }, method: 'POST' })
    //        .fail(function () {
    //            alert('Failed to save.');
    //        });
    //});
});
document.addEventListener("DOMContentLoaded", function () {
    $("tbody> tr").on("click", ActivarFila);
    $("#tableUser>tbody> tr").on("click", ActualizarTablaRol);
    
    $("#btnBuscarUsuario").on("click", ObtenerUsuariosAd);
    $("#btnGuardarRol").on("click", GuardarRol);
    $("#btnDeleteRol").on("click", EliminarRol);
    $("#btnDeleteUser").on("click", EliminarUsuario);
    $("#btnRegistrarDetalle").on("click", RegistrarDetalleRol);
    
    ActivarPrimeraFila();
    
    //var tree = $('#tree').tree({
    //    primaryKey: 'id',
    //    uiLibrary: 'bootstrap4',
    //    dataSource: '/Seguridad/ListarPermisoDetalle',
    //    checkboxes: true
    //});

    $("#txtUsuario").keyup(function (event) {
        if (event.keyCode === 13) {
            var requestBuscar = $(this).val();
            var control = ".descripcionArea" + "." + idArea + ">span";

            var data = {
                usuario: requestBuscar
            };

            var jqxhr = $.ajax({
                type: "POST",
                url: "/Seguridad/ListarUsuariosAD",
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            })
    .done(function (data) {
        var tbody = '<tbody>';
        if (data.length > 0) {
            $.each(data, function (i, o) {
                tbody += '<tr  data-user="' + o.NombreCuenta + ' data-nombre="' + o.NombreCompleto + '">';
                tbody += '<td>' + o.NombreCuenta + '</td>';
                tbody += '</tr>';
                tbody += '<tr>';
                tbody += '<td>' + o.NombreCompleto + '</td>';
                tbody += '</tr>';
            });
        } else {
            tbody += '<tr><td colspan="2">Sin registros para mostrar</td></tr>';
        }

        tbody += '</tbody>';

        $("#tableBusquedaUser > tbody").remove();
        $("#tableBusquedaUser").append(tbody);
        $("#tableBusquedaUser > tbody> tr").on("click", ActivarFila);
        $("#tableBusquedaUser > tbody> tr").on("dblclick", AceptarUsuarioAdd);
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

function ActualizarTablaRol() {
    var id = $(this).data("id");

    var data = {
        idUsuario: id
    };


    var jqxhr = $.ajax({
        type: "POST",
        url: "/Seguridad/ListarPermisos",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
    .done(function (data) {
        var tbody = '<tbody>';
        if (data.length > 0) {
            $.each(data, function (i, o) {
                tbody += '<tr data-id="' + o.IdRol + '" data-idusuario="' + o.IdUsuario + '"  >';
                tbody += '<td>' + o.NombreRol + '</td>';
                tbody += '</tr>';
            });
        } else {
            tbody += '<tr><td colspan="1">Sin registros para mostrar</td></tr>';
        }

        tbody += '</tbody>';

        $("#tableRol > tbody").remove();
        $("#tableRol").append(tbody);

        $("tbody> tr").on("click", ActivarFila);
        $("#tableRol>tbody> tr").on("click", ActualizarPermisoDetalle);
        $("#tableRol>tbody> tr").first().click();
    })
    .fail(function () {
        alert("Ocurrio un error", "comuniquese con su administrador", "error");
    })
    .always(function () {
        
        
    });
    
}

function ActivarPrimeraFila() {
    
    $("#tableUser > tbody").find('tr:first').trigger("hover");
    $("#tableUser > tbody").find('tr:first').trigger("click");
}
function ActivarFila() {
    $(this).parent().find(".active-tr").each(function () {
        $(this).removeClass("active-tr");
    });
    $(this).addClass("active-tr");
}



function ObtenerUsuariosAd() {
    var requestBuscar = $("#txtUsuario").val();

        var data = {
            usuario: requestBuscar
        };

        var jqxhr = $.ajax({
            type: "POST",
            url: "/Seguridad/ListarUsuariosAD",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
.done(function (data) {
    var tbody = '<tbody>';
    if (data.length > 0) {
        console.log(data);
        $.each(data, function (i, o) {
            //if (o.Correo == null) {
            //    alert("usuario no cuenta con correo");
            //    return;
            //}
            //var nameuser = o.Correo.split("@", 1);
            tbody += '<tr  data-user="' + o.Usuario + '" data-nombre="' + o.NombreCompleto + '">';
            tbody += '<td>' + o.Usuario + '</td>';
            tbody += '<td>' + o.NombreCompleto + '</td>';
            tbody += '</tr>';
        });
    } else {
        tbody += '<tr><td colspan="2">Sin registros para mostrar</td></tr>';
    }

    tbody += '</tbody>';

    $("#tableBusquedaUser > tbody").remove();
    $("#tableBusquedaUser").append(tbody);
    $("#tableBusquedaUser > tbody> tr").on("click", ActivarFila);
    $("#tableBusquedaUser > tbody> tr").on("dblclick", AceptarUsuarioAdd);
})
.fail(function (e) {
    alert("Ocurrio un error", "comuniquese con su administrador", e);
})
.always(function () {
});
    
}


function AceptarUsuarioAdd(parameters) {
    var user = $(this).data("user");
    var nombre = $(this).data("nombre");
    

    var data = {
        request: {
            Usuario: user,
            NombreCompleto: nombre
        }
    };

    var jqxhr = $.ajax({
        type: "POST",
        url: "/Seguridad/AgregarUsuario",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
.done(function (data) {
    $(".btnCloseModal").trigger("click");
    $('.alert').fadeIn();
    setTimeout(function () {
        $(".alert").fadeOut();
        location.reload();
    }, 2500);

    
})
.fail(function (e) {
    alert("Ocurrio un error", "comuniquese con su administrador", e);
})
.always(function () {
});

}

function GuardarRol() {
    var filaSeleccionada = $("#tableUser >tbody> .active-tr");
    var id = filaSeleccionada.data("id");
    var rolSeleccionado = $("#selRol").val();
    if (rolSeleccionado == null) {
        alert("Seleccione un rol");
        return;
    }

    var data = {
        request: {
            IdUsuario: id,
            IdRol: rolSeleccionado
        }
    };

    var jqxhr = $.ajax({
        type: "POST",
        url: "/Seguridad/AgregarPermiso",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
.done(function (data) {
    $(".btnCloseModal").trigger("click");
    $('.alert').fadeIn();
    setTimeout(function () {
        $(".alert").fadeOut();
        location.reload();
    }, 2500);


})
.fail(function (e) {
    alert("Ocurrio un error", "comuniquese con su administrador", e);
})
.always(function () {
});

}

function EliminarRol() {
    var opcion = confirm("¿Desea eliminar el rol asociado al usuario seleccionado?");
    if (!opcion) {
        return;
    }
    var filaSeleccionadaUser = $("#tableUser >tbody> .active-tr");
    var idUser = filaSeleccionadaUser.data("id");

    var filaSeleccionadaRol = $("#tableRol >tbody> .active-tr");
    if (filaSeleccionadaRol == null) {
        alert("Seleccione un rol");
        return;
    }
    var idRol = filaSeleccionadaRol.data("id");
    var rolSeleccionado = $("#selRol").val();

    var data = {
        request: {
            IdUsuario: idUser,
            IdRol: idRol
        }
    };

    var jqxhr = $.ajax({
        type: "POST",
        url: "/Seguridad/EliminarPermiso",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
.done(function (data) {
            filaSeleccionadaRol.removeClass("active-tr");
            filaSeleccionadaRol.hide();

        })
.fail(function (e) {
    alert("Ocurrio un error", "comuniquese con su administrador", e);
})
.always(function () {
});

}

function EliminarUsuario() {
    var opcion = confirm("¿Desea eliminar el usuario seleccionado?");
    if (!opcion) {
        return;
    }
    var filaSeleccionadaUser = $("#tableUser >tbody> .active-tr");
    if (filaSeleccionadaUser == null) {
        alert("Seleccione un usuario");
        return;
    }
    var idUser = filaSeleccionadaUser.data("id");


    var data = {
        idUsuario: idUser
    };

    var jqxhr = $.ajax({
        type: "POST",
        url: "/Seguridad/DeshabilitarUsuario",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
.done(function (data) {
    filaSeleccionadaUser.removeClass("active-tr");
    filaSeleccionadaUser.hide();

})
.fail(function (e) {
    alert("Ocurrio un error", "comuniquese con su administrador", e);
})
.always(function () {
});
}
var tree = $('#tree').tree();
var idUsuario = 0;
var idRol = 0;
function ActualizarPermisoDetalle() {

    
    
    tree.destroy();

    idUsuario = $(this).data("idusuario");
    idRol = $(this).data("id");
    if (idRol == 1) {
        $('#btnDeleteRol').hide();
        $('#btnRegistrarDetalle').show();
        
        //var tree = $('#tree').tree({
        tree = $('#tree').tree({
            primaryKey: 'id',
            uiLibrary: 'bootstrap4',
            dataSource: '/Seguridad/ListarPermisoDetalle?idUsuario=' + idUsuario + '&idRol=' + idRol,
            checkboxes: true
        });
    } else {
        $('#btnDeleteRol').show();
        $('#btnRegistrarDetalle').hide();
    }
    
}

function RegistrarDetalleRol() {
    var checkedIds = tree.getCheckedNodes();
    $.ajax({ url: '/Seguridad/RegistrarPermisoDetalle', data: { checkedIds: checkedIds,idUsuario:idUsuario,idRol:idRol }, method: 'POST' })
        .done(function(data) {
            $('.alert').fadeIn();
            setTimeout(function () {
                $(".alert").fadeOut();
            }, 2500);
        })
        .fail(function () {
            alert('Failed to save.');
        });
}