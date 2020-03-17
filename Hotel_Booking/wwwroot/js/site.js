// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";

// Rooms control event.
$("#Rooms").change(function () {
    console.log($(this).val());
    CalculateCost();
});

// Datetime Pickers

// Arrival date picker
$("#arrival-date").datepicker({
    altField: "#FromDate",
    altFormat: "yy-mm-dd",
    onSelect: function () {
        CalculateCost();
    }
});

// Departure date picker
$("#departure-date").datepicker({
    altField: "#ToDate",
    altFormat: "yy-mm-dd",
    defaultDate: +1,
    onSelect: function () {
        CalculateCost();
    }
});

// Form submit validation
$("#btn-complete-booking").click(function (event) {
    let FromDate = Date.parse($("#FromDate").val());
    let ToDate = Date.parse($("#ToDate").val());

    if (FromDate > ToDate) {
        alert("Η Ημ/νία Άφιξης δεν μπορεί να είναι μεγαλύτερη από την Ημ/νία Αναχώρησης.");
        event.preventDefault();
    }

    if (FromDate === ToDate) {
        alert("Η Ημ/νία Άφιξης και Ημ/νία Αναχώρησης δεν μπορεί να είναι ίδιες.");
        event.preventDefault();
    }
});

// Delete booking
$("#btn-booking-delete").click(function (event) {
    let Message = confirm("Θέλετε να διαγράψετε την κράτηση;");

    if (!Message) {
        event.preventDefault();
    }
});

// Functions

// Calculate cost of booking.
function CalculateCost() {
    let FromDate = Date.parse($("#FromDate").val());
    let ToDate = Date.parse($("#ToDate").val());
    let Rooms = $("#Rooms").val();
    let CostPerNight = $("#HotelPrice").text();

    let DiffTime = Math.abs(ToDate - FromDate);
    let DiffDays = Math.ceil(DiffTime / (1000 * 60 * 60 * 24));
    
    $("#Cost").html((Math.round(CostPerNight * DiffDays * Rooms * 100) / 100).toFixed(2) + "€");
}



