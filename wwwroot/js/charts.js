console.log("JAXPORT charts loaded.");

const chartCanvas = document.getElementById("tradeChart");

const tradeChart = new Chart(chartCanvas, {
    type: "bar",

    data: {
        labels: [
            "Jacksonville",
            "Miami",
            "Port Everglades",
            "Tampa",
            "West Palm Beach"
        ],

        datasets: [{
            label: "Example TEUs",
            data: [45, 80, 95, 25, 35]
        }]
    },

    options: {
        responsive: true,
        maintainAspectRatio: false,

        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});