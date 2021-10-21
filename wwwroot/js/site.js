// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var myChart;

function calculate() {
    
    let day = $('#daycount').val();
    let lifeSpanDay = [];
    let Count = [];
    if (day != '') {
        $.post("/Home/GetUserRetention", { days: day })
            .done(function (data) {
                console.log(data.rollingRetention)
                $('#result').text(data.rollingRetention.toFixed(2) + '%')
            });
        $.post("/Home/CalculateLifeSpanAllUsers")
            .done(function (data) {
                if (window.myChart instanceof Chart) {
                    window.myChart.destroy();
                };
                $.each(data.lifespan, function (x, y) {
                    lifeSpanDay.push(y.lifeSpanDays);
                    Count.push(y.count);
                });

                var ctx = document.getElementById('myChart').getContext('2d');
                ctx.clearRect(0, 0, 400, 400);

                window.myChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: lifeSpanDay,
                        datasets: [{
                            label: 'распределениe длительности жизни пользователей',
                            data: Count,
                            backgroundColor: 'rgba(75, 192, 192, 0.2)',
                            borderColor: 'rgba(75, 192, 192, 1)',
                            borderWidth: 1
                        }]
                    },
                    options: {
                        scales: {
                        }
                    }
                });
            })
    }
    
}

function addUserToTable() {
    id = $('#Id').val()
    dateRegistration = $('#dateRegistration').val()
    dateLastActivity = $('#datelastActivity').val()
    if (id != '' && dateRegistration != '' && dateLastActivity != '') {
        $('#dataTable').append('<tr id="tablebody"><td>' + id + '</td><td>' + dateRegistration + '</td><td>' + dateLastActivity + '</td></tr>')
        id = $('#Id').val('');
        dateRegistration = $('#dateRegistration').val('');
        dateLastActivity = $('#datelastActivity').val('');
    }
}



