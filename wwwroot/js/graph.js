const graphCanvas = document.getElementById("tradeGraph");

const tradeGraph = new Chart(graphCanvas, {
    type: "line",

    data: {
        labels: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],

        datasets: [{
            label: "Example Trade Value",
            data: [20, 35, 28, 50, 45, 65, 60, 75, 82, 95],
            tension: 0.3
        }]
    },

    options: {
        responsive: true,
        maintainAspectRatio: false,

        scales: {
            x: {
                title: {
                    display: true,
                    text: "Example X Value"
                }
            },

            y: {
                beginAtZero: true,
                title: {
                    display: true,
                    text: "Example Y Value"
                }
            }
        }
    }
});