let allOptions;

window.addEventListener("load", initialize);

function initialize() {
    console.log("Loaded");

    allOptions = document.querySelectorAll(".prop-item");

    console.log(allOptions);

    addCickEvents();
}


function addCickEvents() {

    allOptions.forEach(option => { option.addEventListener("click", selectOrDeselect)});

}

function selectOrDeselect() {
    console.log("yay");

    if (this.classList.contains("prop-item-selected")) {
        this.classList.remove("prop-item-selected")
    }
    else {
        this.classList.add("prop-item-selected")
    }
}
