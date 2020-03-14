using System;
using System.Collections.Generic;
using System.Linq;
using Hotel_Booking.Components.Data;
using Hotel_Booking.Components.Serialization;
using Hotel_Booking.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel_Booking.Controllers
{
    public class BookingController : Controller
    {
        /// <summary>
        /// Basic method for Booking Page
        /// </summary>
        /// <param name="Id">Hotel Id</param>
        /// <returns></returns>
        public IActionResult Order(Guid Id)
        {
            // Basic Url
            ViewData["Url"] = $"{this.Request.Scheme}://{this.Request.Host}";

            // Initialize Properties
            Hotel Hotel = new Hotel();
            List<Booking> Bookings = new List<Booking>();

            // Get values from DB
            Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(x=>x.Oid == Id).FirstOrDefault();
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings()).Where(x=>x.HotelOid == Id).ToList();

            // Check if our object is null after db call
            if (Bookings is null)
                Bookings = new List<Booking>();

            // Subtraction available rooms
            Hotel.AvailableRooms -= Bookings.Select(x => x.Rooms).Sum();

            // Return our view.
            return View(Hotel);
        }

        /// <summary>
        /// Post method to Complete Booking.
        /// </summary>
        /// <param name="Booking">Booking Object</param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult CompleteOrder(Booking Booking)
        {
            // Initialize Properties
            List<Booking> Bookings = new List<Booking>();

            // Get values from db
            Booking.Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(x => x.Oid == Booking.HotelOid).FirstOrDefault();
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            // Check if object is null
            if (Bookings is null)
                Bookings = new List<Booking>();

            // Add booking object to list.
            Bookings.Add(Booking);

            // Commit changes in db.
            Database.CommitBookings(JsonSerialize.JsonObjectSerialize(Bookings));

            // return our view
            return View("BookingComplete", Booking);
        }

        /// <summary>
        /// Post method to delete a booking
        /// </summary>
        /// <param name="BookingId">Booking Id</param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult DeleteBooking(string BookingId)
        {
            // Initialize Properties
            List<Booking> Bookings = new List<Booking>();

            // Get values from db
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            // Find and remove object based on booking id
            Bookings.Remove(Bookings.Where(x => x.Oid == BookingId).FirstOrDefault());

            // Commit changes in db
            Database.CommitBookings(JsonSerialize.JsonObjectSerialize(Bookings));

            // Return again same page.
            return RedirectToAction("Bookings", "Home");
        }
    }
}
