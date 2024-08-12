document.addEventListener("DOMContentLoaded", function () {
    const brandDropdownSearch = document.getElementById("brandDropdown");
    const modelSearchDropdown = document.getElementById("modelSearchDropdown");
    const modelSearchDropdownMenu = document.querySelector("#modelSearchDropdown + .dropdown-menu.custom-dropdown-menu");

    const brandDropdownCreate = document.getElementById("brandDropdown");
    const modelDropdown = document.getElementById("modelDropdown");

    function populateModelsForSearch(selectedBrandId) {
        if (selectedBrandId !== "") {
            modelSearchDropdown.disabled = false;
            modelSearchDropdownMenu.innerHTML = "";

            fetch(`/GetModelsByBrandSearch?brandId=${selectedBrandId}`)
                .then(response => response.json())
                .then(data => {
                    data.forEach(model => {
                        const listItem = document.createElement("li");
                        listItem.innerHTML = `
                            <input type="checkbox" name="SelectedModelIds" value="${model.modelId}" id="model_${model.modelId}">
                            <label class="lbl-checkbox" for="model_${model.modelId}">${model.name}</label>
                        `;
                        modelSearchDropdownMenu.appendChild(listItem);
                    });
                })
                .catch(error => console.error('Error:', error));
        } else {
            modelSearchDropdown.disabled = true;
            modelSearchDropdownMenu.innerHTML = "<li><a class='dropdown-item' href='#'>---Select Model---</a></li>";
        }
    }

    function populateModelsForCreate(selectedBrandId) {
        if (selectedBrandId !== "") {
            modelDropdown.disabled = false;
            modelDropdown.innerHTML = "<option value=''>---Select Model---</option>";

            fetch(`/GetModelsByBrand?brandId=${selectedBrandId}`)
                .then(response => response.json())
                .then(data => {
                    data.forEach(model => {
                        const option = document.createElement("option");
                        option.value = model.modelId;
                        option.textContent = model.name;
                        modelDropdown.appendChild(option);
                    });
                })
                .catch(error => console.error('Error:', error));
        } else {
            modelDropdown.disabled = true;
            modelDropdown.innerHTML = "<option value=''>---Select Model---</option>";
        }
    }

    brandDropdownSearch.addEventListener("change", function () {
        const selectedBrandId = this.value;
        populateModelsForSearch(selectedBrandId);
    });

    brandDropdownCreate.addEventListener("change", function () {
        const selectedBrandId = this.value;
        populateModelsForCreate(selectedBrandId);
    });

    const selectedBrandId = brandDropdown.value;
    populateModelsForSearch(selectedBrandId);

    // Prevent dropdown from closing on click inside
    const dropdowns = document.querySelectorAll('.custom-dropdown-menu');
    dropdowns.forEach(dropdown => {
        dropdown.addEventListener('click', function (event) {
            event.stopPropagation();
        });
    });
});
