using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hotel_Booking.Models;
using Hotel_Booking.Components.Data;
using Hotel_Booking.Components.Serialization;
using Hotel_Booking.Components.Enumeration;

namespace Hotel_Booking.Controllers
{
    public class HomeController : Controller
    {
        #region Constructor
        public HomeController()
        {

        }
        #endregion

        #region Controller Actions
        /// <summary>
        /// Basic method in Index
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult Index(int Page = 1, OrderType OrderBy = 0)
        {
            // Getting Basic Url
            GetBasicUrl();

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
            return View(Hotels.Where(h => h.AvailableRooms > 0).OrderBy(x => x.Price).Skip((Page * 5) - 5).Take(5).ToList());
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
            GetBasicUrl();

            // Initialize Properties
            List<Booking> Bookings = new List<Booking>();

            // Get values from DB.
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            if (Bookings is null)
                Bookings = new List<Booking>();

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
        #endregion

        #region Custom Methods
        /// <summary>
        /// Getting Basic Url
        /// </summary>
        private void GetBasicUrl()
        {
            ViewData["Url"] = $"{this.Request.Scheme}://{this.Request.Host}";
        }
        #endregion
    }
}
