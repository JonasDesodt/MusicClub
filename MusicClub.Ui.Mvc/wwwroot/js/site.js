﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onscroll = function () {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.body.classList.add('scroll');
    }
    else {
        document.body.classList.remove('scroll');
    }
}

document.getElementById('scroll-to-top').onclick = () => window.scrollTo(0, 0);

document.querySelectorAll('.toggle-container').forEach(toggleContainer => toggleContainer.querySelectorAll("[class^='toggle-button-']").forEach(toggleButton => toggleButton.addEventListener('click', () => toggle(toggleContainer, toggleButton))));
function toggle(toggleContainer, toggleButton) {
    toggleContainer.classList.toggle(Array.from(toggleButton.classList).find(classItem => classItem.startsWith('toggle-button-')).replace('toggle-button-', ''))
}

