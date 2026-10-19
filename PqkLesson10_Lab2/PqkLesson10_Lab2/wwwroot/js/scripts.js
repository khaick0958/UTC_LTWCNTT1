document.addEventListener("DOMContentLoaded", function () {
    const toggle = document.getElementById("sidebarToggle");
    if (toggle) toggle.addEventListener("click", function () {
        document.body.classList.toggle("sidebar-toggled");
    });
});
