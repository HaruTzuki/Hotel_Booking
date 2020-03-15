using Hotel_Booking.Components.Data;
using Hotel_Booking.Components.Serialization;
using Hotel_Booking.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewComponents
{
    public class PagenationViewComponent : ViewComponent
    {
        public PagenationViewComponent() { }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Hotel> Hotels = new List<Hotel>();
            List<Booking> Bookings = new List<Booking>();

            Hotels = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch());
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            // Checking if object is null.
            if (Hotels is null)
                Hotels = new List<Hotel>();

            if (Bookings is null)
                Bookings = new List<Booking>();

            // Substraction Available rooms from Bookings.
            Hotels.ForEach(h => h.AvailableRooms -= Bookings.Where(b => b.HotelOid == h.Oid).Select(b => b.Rooms).Sum());

            return View(Hotels.Count());
        }
    }
}
