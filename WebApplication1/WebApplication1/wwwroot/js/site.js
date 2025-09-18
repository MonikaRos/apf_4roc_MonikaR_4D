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

function countChars() {
    const textarea = document.getElementById("textInput");
    const charCount = document.getElementById("charCount");
    const count = textarea.value.length;

    charCount.textContent = `Minimálne 20 znakov, aktuálny počet znakov: ${count}`;

    if (count < 20) {
        textarea.classList.remove("valid");
        textarea.classList.add("invalid");
    } else {
        textarea.classList.remove("invalid");
        textarea.classList.add("valid");
    }
}


