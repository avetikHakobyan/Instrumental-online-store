﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Idea from https://youtu.be/w67WctTPQFc?si=UF_EWcuULAI4P0KE
window.setTimeout(() => {
    $(".alert").slideUp(500, function() {
        $(this).remove();
    })
}, 4000)