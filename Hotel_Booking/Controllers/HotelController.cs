using System;
using System.Collections.Generic;
using System.Linq;
using Hotel_Booking.Components.Data;
using Hotel_Booking.Components.Serialization;
using Hotel_Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking.Controllers
{
    public class HotelController : Controller
    {
        #region Controller Actions
        public IActionResult Information(Guid Id)
        {
            // Basic Url
            ViewData["Url"] = $"{this.Request.Scheme}://{this.Request.Host}/";
            // Initialize Properties
            Hotel Hotel = new Hotel();
            List<Booking> Bookings = new List<Booking>();
            // Get Values from db
            Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(x => x.Oid == Id).FirstOrDefault();
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            // Check if our object is null after db call
            if (Bookings is null)
                Bookings = new List<Booking>();

            // Subtraction available rooms
            Hotel.AvailableRooms -= Bookings.Where(x => x.HotelOid == Id).Select(x => x.Rooms).Sum();

            // Return our view
            return View(Hotel);
        } 
        #endregion
    }
}
