console.log("JAXPORT dashboard loaded.");

const tabs = document.querySelectorAll(".view-tab");
const views = document.querySelectorAll(".dashboard-view");

document.addEventListener("DOMContentLoaded", () => {
    updateDatabaseStatus();
    setInterval(updateDatabaseStatus, 60000);

    tabs.forEach(tab => {

        tab.addEventListener("click", () => {

            // Remove active state from everything
            tabs.forEach(t => t.classList.remove("active"));
            views.forEach(v => v.classList.remove("active-view"));

            // Activate selected tab
            tab.classList.add("active");

            // Find the view named by data-view
            const viewId = tab.dataset.view;
            const selectedView = document.getElementById(viewId);

            selectedView.classList.add("active-view");
        });

    });
});


async function getDatabaseStatus() {
    try {
        const response = await fetch("/api/health/database");

        if (!response.ok)
            return { connected: false, host: "Unknown.host" };

        return await response.json();
    }
    catch {
        return { connected: false, host: "Unknown.host" };
    }
}

async function updateDatabaseStatus() {
    const status = await getDatabaseStatus();

    const dot = document.getElementById("db-status-dot");

    dot.className = status.connected ? "connected" : "disconnected";

    document.getElementById("db-status-text").textContent =
        status.connected ? "DB ONLINE" : "DB OFFLINE";

    document.getElementById("db-host").textContent = status.host;
}