let allOptions, selectList;

window.addEventListener("load", initialize);

function initialize() {
    console.log("Loaded");

    allOptions = document.querySelectorAll(".prop-item");
    selectList = document.getElementById("selectList");
    
    console.log(allOptions);


    addCickEvents();
    checkForSelectedValues();
}


function addCickEvents() {

    allOptions.forEach(option => { option.addEventListener("click", selectOrDeselect)});

}

function checkForSelectedValues() {


    Array.from(selectList).forEach(option => { if (option.selected == true) { allOptions[(option.index)].classList.add("prop-item-selected")} });
}

function selectOrDeselect() {
    console.log("yay");
    const itemIndex = (Array.from(allOptions).indexOf(this));
    /*const selectList = document.getElementById("selectList");*/

    console.log(selectList);
    /*selectList.querySelectorAll("option")[itemIndex]*/
    
    if (this.classList.contains("prop-item-selected")) {
        this.classList.remove("prop-item-selected");
        selectList[itemIndex].selected = false;
        console.log(itemIndex);
    }
    else {
        this.classList.add("prop-item-selected")
        selectList[itemIndex].selected = true;
        console.log(itemIndex);
    }
}


