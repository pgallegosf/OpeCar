

function MostrarReporteAcceso (periodo) {
    
    var data = {
        anio: periodo
    };

    var jqxhr = $.ajax({
        type: "POST",
        url: "Log/ListarAccesos",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    })
    .done(function (data) {
        var objLabel = [];
        var objData = [];
            if (data.length > 0) {
                $.each(data, function(i, o) {
                    objLabel.push(o.Mes);
                    objData.push(o.TotalVisitas);
                    
                });
                var ctx = document.getElementById('myChart').getContext('2d');
                var chart = new Chart(ctx, {
                    // The type of chart we want to create
                    type: 'line',

                    // The data for our dataset
                    data: {
                        labels: objLabel,
                        datasets: [{
                            label: 'Total Accesos',
                            //backgroundColor: 'rgb(255, 99, 132)',
                            backgroundColor: '#a5e05c',
                            borderColor: '#78b82d',
                            //borderColor: 'rgb(255, 99, 132)',
                            data: objData
                        }]
                    },

                    // Configuration options go here
                    options: {}
                });
            }
        })
    .fail(function (e) {
            //alert(e);
        })
    .always(function () {
    });

    
}