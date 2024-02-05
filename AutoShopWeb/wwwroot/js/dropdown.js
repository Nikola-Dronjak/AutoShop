document.addEventListener('DOMContentLoaded', function () {
    const dropdowns = document.querySelectorAll('.custom-dropdown-menu');

    dropdowns.forEach(dropdown => {
        dropdown.addEventListener('click', function (event) {
            event.stopPropagation();
        });
    });
});
