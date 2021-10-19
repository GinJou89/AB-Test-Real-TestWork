// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function calculate() {
    let day = $('#daycount').val()
    if (day != null) {
        $.post("/Home/GetUserRetention", { days: day })
            .done(function (data) {
                console.log(data.rollingRetention)
                $('#result').text(data.rollingRetention.toFixed(2))
            });
    }
    
}