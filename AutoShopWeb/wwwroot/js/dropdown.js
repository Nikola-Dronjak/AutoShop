document.addEventListener("DOMContentLoaded", function () {
    // Elements for Search Bar
    const brandDropdownSearch = document.getElementById("brandSearchDropdown");
    const modelSearchDropdown = document.getElementById("modelSearchDropdown");
    const modelSearchDropdownMenu = document.querySelector("#modelSearchDropdown + .dropdown-menu.custom-dropdown-menu");

    // Elements for Create Page
    const brandDropdownCreate = document.getElementById("brandDropdown");
    const modelDropdownCreate = document.getElementById("modelDropdown");

    function populateModelsForSearch(selectedBrandId) {
        if (modelSearchDropdown && modelSearchDropdownMenu) {
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
    }

    function populateModelsForCreate(selectedBrandId, selectedModelId = null) {
        if (modelDropdownCreate) {
            if (selectedBrandId !== "") {
                modelDropdownCreate.disabled = false;
                modelDropdownCreate.innerHTML = "<option value=''>---Select Model---</option>";

                fetch(`/GetModelsByBrand?brandId=${selectedBrandId}`)
                    .then(response => response.json())
                    .then(data => {
                        data.forEach(model => {
                            const option = document.createElement("option");
                            option.value = model.modelId;
                            option.textContent = model.name;
                            modelDropdownCreate.appendChild(option);
                        });

                        if (selectedModelId) {
                            modelDropdownCreate.value = selectedModelId;
                        }
                    })
                    .catch(error => console.error('Error:', error));
            } else {
                modelDropdownCreate.disabled = true;
                modelDropdownCreate.innerHTML = "<option value=''>---Select Model---</option>";
            }
        }
    }

    if (brandDropdownSearch) {
        brandDropdownSearch.addEventListener("change", function () {
            const selectedBrandId = this.value;
            populateModelsForSearch(selectedBrandId);
        });

        const selectedBrandIdSearch = brandDropdownSearch.value;
        populateModelsForSearch(selectedBrandIdSearch);
    }

    if (brandDropdownCreate) {
        brandDropdownCreate.addEventListener("change", function () {
            const selectedBrandId = this.value;
            populateModelsForCreate(selectedBrandId);
        });

        const selectedBrandIdCreate = brandDropdownCreate.value;
        const selectedModelIdCreate = modelDropdownCreate.getAttribute("data-selected-model-id");
        populateModelsForCreate(selectedBrandIdCreate, selectedModelIdCreate);
    }

    // Prevent dropdown from closing on click inside
    const dropdowns = document.querySelectorAll('.custom-dropdown-menu');
    dropdowns.forEach(dropdown => {
        dropdown.addEventListener('click', function (event) {
            event.stopPropagation();
        });
    });
});
