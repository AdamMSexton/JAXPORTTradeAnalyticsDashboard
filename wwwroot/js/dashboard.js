console.log("JAXPORT dashboard loaded.");

const tabs = document.querySelectorAll(".view-tab");
const views = document.querySelectorAll(".dashboard-view");

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