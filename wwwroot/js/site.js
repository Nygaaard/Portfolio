﻿const openIcon = document.querySelector('.menu-icon');
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

