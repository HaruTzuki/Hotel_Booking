using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotel_Booking.Models;
using Hotel_Booking.Components.Data;
using Hotel_Booking.Components.Serialization;
using Microsoft.AspNetCore.Hosting;
using Hotel_Booking.Components.IO;

namespace Hotel_Booking.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            List<Hotel> Hotels = new List<Hotel>();
            List<Booking> Bookings = new List<Booking>();

            Hotels = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch());
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            if (Hotels is null)
                Hotels = new List<Hotel>();

            if (Bookings is null)
                Bookings = new List<Booking>();

            Hotels.ForEach(h => h.AvailableRooms -= Bookings.Where(b => b.HotelOid == h.Oid).Select(b => b.Rooms).Sum());
           
            return View(Hotels.Where(h=>h.AvailableRooms > 0).ToList());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Bookings()
        {
            List<Booking> Bookings = new List<Booking>();

            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            Bookings.ForEach(x => x.Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(y => y.Oid == x.HotelOid).FirstOrDefault());

            ViewData["Url"] = $"{this.Request.Scheme}://{this.Request.Host}";

            return View(Bookings);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
