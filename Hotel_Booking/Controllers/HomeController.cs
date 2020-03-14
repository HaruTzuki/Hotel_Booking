using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hotel_Booking.Models;
using Hotel_Booking.Components.Data;
using Hotel_Booking.Components.Serialization;

namespace Hotel_Booking.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        /// <summary>
        /// Basic method in Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // Initialize Properties
            List<Hotel> Hotels = new List<Hotel>();
            List<Booking> Bookings = new List<Booking>();

            // Get Values from DB.
            Hotels = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch());
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            // Checking if object is null.
            if (Hotels is null)
                Hotels = new List<Hotel>();

            if (Bookings is null)
                Bookings = new List<Booking>();

            // Substraction Available rooms from Bookings.
            Hotels.ForEach(h => h.AvailableRooms -= Bookings.Where(b => b.HotelOid == h.Oid).Select(b => b.Rooms).Sum());
           
            // Return our view.
            return View(Hotels.Where(h=>h.AvailableRooms > 0).ToList());
        }

        /// <summary>
        /// Method for Privacy
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Method to show our Booking list.
        /// </summary>
        /// <returns></returns>
        public IActionResult Bookings()
        {
            // Getting Basic Url
            ViewData["Url"] = $"{this.Request.Scheme}://{this.Request.Host}";

            // Initialize Properties
            List<Booking> Bookings = new List<Booking>();

            // Get values from DB.
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            // Initialize Hotel Object in each of the Booking Object.
            Bookings.ForEach(x => x.Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(y => y.Oid == x.HotelOid).FirstOrDefault());

            // Return our view.
            return View(Bookings);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
