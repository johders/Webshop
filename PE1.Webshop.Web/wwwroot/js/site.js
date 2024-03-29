// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function openDialog() {
    const termsConditions = document.getElementById("terms-conditions");
    const closeModal = document.getElementById("close-dialog");

    termsConditions.showModal();

    closeModal.addEventListener("click", () => { termsConditions.close(); });
}