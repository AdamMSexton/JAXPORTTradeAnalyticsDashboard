console.log("JAXPORT map loaded.");

// Create map
const tradeMap = L.map("tradeMap").setView(
    [25.0, -80.0],
    4
);

// Add OpenStreetMap tiles
L.tileLayer(
    "https://tile.openstreetmap.org/{z}/{x}/{y}.png",
    {
        maxZoom: 19,
        attribution: '&copy; OpenStreetMap contributors'
    }
).addTo(tradeMap);