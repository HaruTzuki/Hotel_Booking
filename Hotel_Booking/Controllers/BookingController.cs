using System;
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
        // GET: /<controller>/
        public IActionResult Order(Guid Id)
        {
            Booking _Booking = new Booking();

            // Taking Hotel
            _Booking.Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(x=>x.Oid == Id).FirstOrDefault();


            return View(_Booking);
        }
    }
}
