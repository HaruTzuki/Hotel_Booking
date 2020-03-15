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
            // Initialize Properties
            Hotel Hotel = new Hotel();

            // Get Values from db
            Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(x => x.Oid == Id).FirstOrDefault();

            // Return our view
            return View(Hotel);
        } 
        #endregion
    }
}
