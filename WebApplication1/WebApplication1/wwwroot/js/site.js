// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggleText() {
    const p = document.getElementById("toggle-text");
    if (p.style.display === "none") {
        p.style.display = "block";
    } else {
        p.style.display = "none";
    }
}

let count = 0;
function countClick() {
    count++;
    const box = document.getElementById("box");
    box.textContent = count;

    if (count >= 5) {
        box.style.backgroundColor = "lightgreen";
    } else {
        box.style.backgroundColor = "lightgray";
    }
}
