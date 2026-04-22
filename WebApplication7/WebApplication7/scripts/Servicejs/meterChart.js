
    google.charts.load('current', {'packages': ['gauge'] });
    google.charts.setOnLoadCallback(drawGaugeChart);

    function drawGaugeChart() {
        var data = google.visualization.arrayToDataTable([
            ['Label', 'Value'],
            ['Label', 80], 
        ]);

        var options = {
        width: 300,
            height: 200,
            redFrom: 90, 
            redTo: 100,
            yellowFrom: 75,
            yellowTo: 90,
            greenFrom: 0,
            greenTo: 75,
            minorTicks: 5
        };

        var chart = new google.visualization.Gauge(document.getElementById('gaugeChart'));

        chart.draw(data, options);
    }

