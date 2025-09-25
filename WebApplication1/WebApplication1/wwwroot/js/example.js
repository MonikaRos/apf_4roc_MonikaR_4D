const osoba = {
    meno: "Ján",
    vek: 25,
    mesto: "Bratislava"
};

const jsonString = JSON.stringify(osoba);
console.log(jsonString);

const jsonData = '{ "meno":"Ján", "vek":25, "mesto":"Bratislava"}';
const objekt = JSON.parse(jsonData);
console.log(objekt.meno);

function showPerson() {
    const output = document.getElementById("output");
    output.textContent = `Meno: ${objekt.meno}, Vek: ${objekt.vek}`;
}


const jsonDataOv = `
        {
            "produkty": [
                { "nazov": "Jablko", "cena": 1.2 },
                { "nazov": "Banán", "cena": 0.9 },
                { "nazov": "Pomaranč", "cena": 1.5 }
            ]
        }`;

const data = JSON.parse(jsonDataOv);

function showFirstProduct() {
    const prvyProdukt = data.produkty[0]; 
    const output1 = document.getElementById("output1");
    output1.textContent = `Názov: ${prvyProdukt.nazov}, Cena: ${prvyProdukt.cena} €`;
}

// JSON uloha3
const jsonDataMovie = `
        {
            "filmy": [
                "Pán prsteňov",
                "Harry Potter",
                "Inception",
                "Forrest Gump"
            ]
        }`;


const data_film = JSON.parse(jsonDataMovie);

function showMovies() {
    const output2 = document.getElementById("output2");
    
    output2.innerHTML = data_film.filmy.map(film => ` ${film}`).join("<br>");
}

//uloha studenti

const jsonDataStudent = `
        {
            "studenti": [
                { "meno": "Ján", "vek": 20 },
                { "meno": "Anna", "vek": 22 },
                { "meno": "Peter", "vek": 19 }
            ]
        }`;


const data_student = JSON.parse(jsonDataStudent);

function showStudents() {
    const output3 = document.getElementById("output3");
    output3.innerHTML = data_student.studenti
        .map(s => ` Meno: ${s.meno}, Vek: ${s.vek}`)
        .join("<br>");
}

//Uloha 5 filter
const jsonDataEmpolyers = `
        {
            "zamestnanci": [
                { "meno": "Ján", "pozicia": "programátor" },
                { "meno": "Anna", "pozicia": "HR" },
                { "meno": "Peter", "pozicia": "programátor" },
                { "meno": "Marek", "pozicia": "manažér" },
                { "meno": "Lucia", "pozicia": "programátor" }
            ]
        }`;
const data_employers = JSON.parse(jsonDataEmpolyers);
function showProgrammers() {
    const output4 = document.getElementById("output4");
    const programatori = data_employers.zamestnanci.filter(z => z.pozicia === "programátor");
    output4.innerHTML = programatori
        .map(p => ` Meno: ${p.meno}, Pozícia: ${p.pozicia}`)
        .join("<br>");
}

//Uloha6 table to html

const jsonDataBooks = `
        {
            "knihy": [
                { "nazov": "Malý princ", "autor": "Antoine de Saint-Exupéry" },
                { "nazov": "1984", "autor": "George Orwell" },
                { "nazov": "Hobit", "autor": "J.R.R. Tolkien" }
            ]
        }`;


const data_books = JSON.parse(jsonDataBooks);

function createTable() {
    const container = document.getElementById("table-container");

    let table = `<table border="1" cellpadding="8" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>Názov knihy</th>
                                    <th>Autor</th>
                                </tr>
                            </thead>
                            <tbody>
                                ${data_books.knihy.map(kniha => `
                                    <tr>
                                        <td>${kniha.nazov}</td>
                                        <td>${kniha.autor}</td>
                                    </tr>`).join('')}
                            </tbody>
                         </table>`;

    container.innerHTML = table;
}


//user form subjects
const addSubjectBtn = document.getElementById("addSubjectBtn");
const subjectForm = document.getElementById("subjectForm");
const saveSubjectBtn = document.getElementById("saveSubjectBtn");
const cancelSubjectBtn = document.getElementById("cancelSubjectBtn");
const subjectsContainer = document.getElementById("subjectsContainer");
const form = document.querySelector(".user-form");

addSubjectBtn.addEventListener("click", () => {
    subjectForm.style.display = "block";
});

cancelSubjectBtn.addEventListener("click", () => {
    subjectForm.style.display = "none";
});

saveSubjectBtn.addEventListener("click", () => {
    const name = document.getElementById("subName").value;
    const teacher = document.getElementById("subTeacher").value;
    const grade = document.getElementById("subGrade").value;
    const room = document.getElementById("subRoom").value;
    const image = document.getElementById("subImage").value;

    if (name) {
        const card = document.createElement("div");
        card.className = "subject-card";
        card.innerHTML = `
                    <p><strong>${name}</strong></p>
                    <p>Učiteľ: ${teacher}</p>
                    <p>Známka: ${grade}</p>
                    <p>Učebňa: ${room}</p>
                    ${image ? `<img src="${image}" alt="${name}" class="subject-img" />` : ''}
                `;
        subjectsContainer.appendChild(card);

        ["Name", "Teacher", "Grade", "Room", "ImageUrl"].forEach(field => {
            const hidden = document.createElement("input");
            hidden.type = "hidden";
            hidden.name = `Subjects[${subjectsContainer.children.length - 1}].${field}`;
            hidden.value = eval(field.toLowerCase());
            form.appendChild(hidden);
        });

        subjectForm.style.display = "none";
        document.getElementById("subName").value = "";
        document.getElementById("subTeacher").value = "";
        document.getElementById("subGrade").value = "";
        document.getElementById("subRoom").value = "";
        document.getElementById("subImage").value = "";
    }
});