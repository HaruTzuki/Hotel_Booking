﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Components.Data;
using Hotel_Booking.Components.Serialization;
using Hotel_Booking.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel_Booking.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Order(Guid Id)
        {
            ViewData["Url"] = $"{this.Request.Scheme}://{this.Request.Host}";
            Hotel Hotel = new Hotel();
            List<Booking> Bookings = new List<Booking>();

            // Taking Hotel
            Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(x=>x.Oid == Id).FirstOrDefault();
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings()).Where(x=>x.HotelOid == Id).ToList();

            if (Bookings is null)
                Bookings = new List<Booking>();


            Hotel.AvailableRooms -= Bookings.Select(x => x.Rooms).Sum();

            return View(Hotel);
        }

        [HttpPost()]
        public IActionResult CompleteOrder(Booking Booking)
        {
            // Save to Json File
            List<Booking> Bookings;
            // Taking Hotel Object
            Booking.Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(x => x.Oid == Booking.HotelOid).FirstOrDefault();

            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            if (Bookings is null)
                Bookings = new List<Booking>();

            Bookings.Add(Booking);

            Database.CommitBookings(JsonSerialize.JsonObjectSerialize(Bookings));

            return View("BookingComplete", Booking);
        }

        [HttpPost()]
        public IActionResult DeleteBooking(string BookingId)
        {
            List<Booking> Bookings = new List<Booking>();
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());
            Bookings.Remove(Bookings.Where(x => x.Oid == BookingId).FirstOrDefault());
            Database.CommitBookings(JsonSerialize.JsonObjectSerialize(Bookings));

            return RedirectToAction("Bookings", "Home");
        }
    }
}
