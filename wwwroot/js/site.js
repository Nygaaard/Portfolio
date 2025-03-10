const openIcon = document.querySelector('.menu-icon');
const menu = document.querySelector('.menu');

const closeIcon = document.querySelector('.menu-close-icon');

const lightModeToggle = document.querySelector('.light-container'); 
const body = document.body; 
const icon = document.querySelector('.dark-light');

openIcon.addEventListener('click', function () {
    menu.classList.toggle('show'); 
    closeIcon.classList.toggle('show')
});

closeIcon.addEventListener('click', function () {
    menu.classList.toggle('show'); 
    closeIcon.classList.toggle('show')
});

lightModeToggle.addEventListener('click', function () {
    body.classList.toggle('light-mode');
    
    if (body.classList.contains('light-mode')) {
        icon.classList.remove('fa-circle-half-stroke');
        icon.classList.add('fa-sun');
    } else {
        icon.classList.remove('fa-sun');
        icon.classList.add('fa-circle-half-stroke');
    }
});

// Funktion för att visa/dölja Google Translate-widgeten
function toggleTranslateWidget() {
    var translateElement = document.getElementById("google_translate_element");
    if (translateElement.style.display === "none") {
        translateElement.style.display = "block"; // Visa widgeten
    } else {
        translateElement.style.display = "none"; // Dölja widgeten
    }
}

function changeLanguage() {
    var select = document.querySelector(".goog-te-combo");
    var langText = document.getElementById("lang-text");

    if (select) {
        if (select.value === "en") {
            select.value = "sv"; // Byt till svenska
            langText.innerText = "Språk"; 
        } else {
            select.value = "en"; // Byt till engelska
            langText.innerText = "Language";
        }
        select.dispatchEvent(new Event("change")); // Aktivera översättningen
    }
}


