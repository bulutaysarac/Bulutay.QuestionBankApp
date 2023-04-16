document.addEventListener("DOMContentLoaded", () => {
    const cbDepartments = document.querySelector("#DepartmentId");
    const cbLectures = document.querySelector("#LectureId");
    const cbCategories = document.querySelector("#CategoryId");
    const isCorrectContainer = document.querySelector("#IsCorrect").parentNode;
    const optionsContainer = document.querySelector("#OptionsContainer");
    const btnAddOption = document.querySelector("#BtnAddOption");
    const lectureIdFromModel = document.querySelector("#DataLectureId").value;
    let optionsCount = optionsContainer.querySelectorAll("input").length;
    let firstRun = true;

    const showHideInputsForCategory = (e) => {
        const categoryId = cbCategories.value;
        if (categoryId == 3) {
            isCorrectContainer.classList.remove("d-none");
            optionsContainer.classList.add("d-none");
        } else if (categoryId == 2) {
            optionsContainer.classList.remove("d-none");
            isCorrectContainer.classList.add("d-none");
        } else {
            isCorrectContainer.classList.add("d-none");
            optionsContainer.classList.add("d-none");
        }
    };

    const loadLectures = (e) => {
        const departmentId = cbDepartments.value;
        
        fetch(`http://localhost:5817/api/departments/${departmentId}/lectures`, {
            method: "GET",
            headers: { "Content-Type": "application/json" },
        })
            .then((response) => response.json())
            .then((data) => {
                cbLectures.innerHTML = "<option value=0>Ders Seç...</option>";
                data.forEach((lecture) => {
                    const optionString = `<option value="${lecture.id}">${lecture.name}</option>`;
                    cbLectures.insertAdjacentHTML('beforeend', optionString);
                });
                if (firstRun) {
                    cbLectures.value = lectureIdFromModel;
                    firstRun = false;
                } else {
                    cbLectures.value = "0";
                }
            })
            .catch((error) =>
                console.error("Error requesting data from API", error)
            );
    };

    const btnAddOptionClicked = (e) => {
        const container = document.createElement("div");
        container.classList.add("mb-3");

        const emptyDiv = document.createElement("div");
        const inputDiv = document.createElement("div");
        inputDiv.classList.add("flex-grow-1");
        inputDiv.classList.add("d-flex");

        container.appendChild(emptyDiv);
        container.appendChild(inputDiv);

        const inputElement = document.createElement("input");

        inputElement.setAttribute("type", "text");
        inputElement.setAttribute(
            "name",
            "Options[" + (optionsCount) + "].Body"
        );
        optionsCount++;
        inputElement.classList.add("form-control");
        inputElement.classList.add("mr-2");

        const btnRemove = document.createElement("span");
        btnRemove.classList.add("btn");
        btnRemove.classList.add("btn-danger");
        btnRemove.innerHTML = "&minus;";
        btnRemove.addEventListener("click", (e) => btnRemoveOptionClicked(e));

        inputDiv.appendChild(inputElement);
        inputDiv.appendChild(btnRemove);
        container.appendChild(inputDiv);
        optionsContainer.appendChild(container);
    };

    const btnRemoveOptionClicked = (e) => {
        const elementToRemove = e.target.parentNode.parentNode;
        elementToRemove.parentNode.removeChild(elementToRemove);
        optionsCount--;
        const inputElements = document.querySelectorAll("#OptionsContainer input");
        inputElements.forEach((inputElement, index) => {
            inputElement.setAttribute("name", "Options[" + index + "].Body");
        });
    };

    cbCategories.addEventListener("input", (e) => showHideInputsForCategory(e));
    cbDepartments.addEventListener("input", (e) => loadLectures(e));
    btnAddOption.addEventListener("click", (e) => btnAddOptionClicked(e));

    if (lectureIdFromModel > 0) {
        loadLectures();
    }

    const btnRemoveList = optionsContainer.querySelectorAll(".btn.btn-danger");
    for (var i = 0; i < btnRemoveList.length; i++) {
        btnRemoveList[i].addEventListener("click", btnRemoveOptionClicked);
    }

    showHideInputsForCategory();
    $("#Body").trumbowyg();
});
