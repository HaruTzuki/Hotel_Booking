using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class Booking
    {
        private Hotel _Hotel = new Hotel();
        private DateTime _FromDate = DateTime.Now;
        private DateTime _ToDate = DateTime.Now.AddDays(1);
        private int _Rooms = 0;
        private decimal _BookingCost;
        private User _User = new User();
    }
}
