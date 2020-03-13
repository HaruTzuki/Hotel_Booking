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
            List<Hotel> Hotels = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch());
            return View(Hotels);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
