// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";

$(document).ready(function () {
    
});

$("#FromDate").change(function () {
    console.log($(this).val());
    CalculateCost();
});

$("#ToDate").change(function () {
    console.log($(this).val());
    CalculateCost();
});

$("#Rooms").change(function () {
    console.log($(this).val());
    CalculateCost();
});

function CalculateCost() {
    let FromDate = new Date($("#FromDate").val());
    let ToDate = new Date($("#ToDate").val());
    let Rooms = $("#Rooms").val();
    let CostPerNight = $("#HotelPrice").text();

    let DiffTime = Math.abs(ToDate - FromDate);
    let DiffDays = Math.ceil(DiffTime / (1000 * 60 * 60 * 24));
    console.log(CostPerNight + " " + DiffDays);
    // TODO Conditions

    $("#Cost").html((Math.round(CostPerNight * DiffDays * Rooms * 100) / 100).toFixed(2) + "€");
}

