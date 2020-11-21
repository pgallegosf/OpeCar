var date = new Date();
var dateMax = new Date();
date.setDate(date.getDate() - 30);
dateMax.setDate(date.getDate() - 2);
$("#divCalendario").hide();
document.addEventListener("DOMContentLoaded", function () {
    $('#cmbTipoRestauracion').on("change", MostrarMetodoRestauracion);
    $('#btnRestaurar').on("click", RestaurarBD);
});
//$.datepicker.regional['es'] = {
//    closeText: 'Cerrar',
//    prevText: '< Ant',
//    nextText: 'Sig >',
//    currentText: 'Hoy',
//    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
//    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
//    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
//    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
//    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
//    weekHeader: 'Sm',
//    dateFormat: 'dd/mm/yy',
//    firstDay: 1,
//    isRTL: false,
//    showMonthAfterYear: false,
//    yearSuffix: ''
//};
//$.datepicker.setDefaults($.datepicker.regional['es']);
//jQuery(function ($) {
//    $.datepicker.regional['es'] = {
//        closeText: 'Cerrar',
//        prevText: '&#x3c;Ant',
//        nextText: 'Sig&#x3e;',
//        currentText: 'Hoy',
//        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
//            'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'
//        ],
//        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
//            'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'
//        ],
//        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
//        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
//        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
//        weekHeader: 'Sm',
//        dateFormat: 'yy/mm/dd',
//        firstDay: 1,
//        isRTL: false,
//        showMonthAfterYear: false,
//        yearSuffix: ''
//    };
//    $.datepicker.setDefaults($.datepicker.regional['es']);

//});
//$.datepicker.dates['es'] = {
//    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
//    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
//    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
//    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
//    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
//    weekHeader: 'Sm',
//    dateFormat: 'dd/mm/yy',
//    firstDay: 1,
//    isRTL: false,
//    showMonthAfterYear: false,
//    yearSuffix: ''
//};
//; (function ($) {
//    $.fn.datepicker.dates['es'] = {
//        days: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
//        daysShort: ["Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"],
//        daysMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
//        months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
//        monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
//        today: "Hoy",
//        monthsTitle: "Meses",
//        clear: "Borrar",
//        weekStart: 1,
//        format: "dd/mm/yyyy"
//    };
//}(jQuery));
$(document).ready(function () {
    //$.datepicker.setDefaults($.datepicker.regional["es"]);
    $('#datepicker').datepicker({
        weekStart: 1,
        daysOfWeekHighlighted: "6,0",
        autoclose: true,
        todayHighlight: true,
        minDate: date,
        maxDate: dateMax,
        language: 'es',
    });
    
    //$('#datepicker').datepicker.regional['es'];
});

function MostrarMetodoRestauracion() {
    
    var tipoRestauracionSeleccionado = $("#cmbTipoRestauracion").val();
    if (tipoRestauracionSeleccionado == 1) {
        $("#divCalendario").hide();
        $("#divMes").show();
    } else {
        $("#divMes").hide();
        $("#divCalendario").show();
    }
   
}

function RestaurarBD() {
    var dia;
    var mes;
    var anio;
    var tipoRestauracionSeleccionado = $("#cmbTipoRestauracion").val();
    var fecha = new Date($('#datepicker').val());//$("#datepicker").val();
    if (tipoRestauracionSeleccionado == 2 & (fecha == "" || fecha == null)) {
        alert("Datos incompletos", "Ingrese una fecha", "error");
        return;
        //alert("Ocurrio un error", "comuniquese con su administrador", "error");
    }
    else if (tipoRestauracionSeleccionado == 2) {
        dia = fecha.getDate();
        mes = fecha.getMonth() + 1;
        anio = fecha.getFullYear();
    }
    else {
        dia = 0;
        mes = $("#cmbMes").val();
        if (mes > new Date().getMonth()) {
            anio = new Date().getFullYear() - 1;
        } else {
            anio = new Date().getFullYear();
        }
        
    }
    alert(anio);
    
    var data = {
        request: {
            IDBaseDatos: 1,
            IDTipoRestauracion: tipoRestauracionSeleccionado,
            Anio: anio,
            Mes: mes,
            Dia: dia
        }
    };
    var jqxhr = $.ajax({
        type: "POST",
        url: "/RestauracionBD/RestaurarBaseDatos",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
        .done(function (data) {
            if (data.Estado) {
                $(".alert-link").html(data.Mensaje);
                $('.alert').fadeIn();
                setTimeout(function () {
                    $(".alert").fadeOut();
                }, 2500);
            }
            else {
                alert(data.Mensaje);
            }
            
        })
        .fail(function (e) {
            alert("Ocurrio un error", "comuniquese con su administrador", e);
        });
}