using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    /// <summary>
    /// Booking Class. Organize your Booking.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Hotel Class. Keep Hotel information of your booking.
        /// </summary>
        private Hotel _Hotel = new Hotel();
        public Hotel Hotel
        {
            get
            {
                return this._Hotel;
            }
            set
            {
                if (value != this._Hotel)
                {
                    this._Hotel = value;
                }
            }
        }
        
        /// <summary>
        /// From Date Booking.
        /// </summary>
        private DateTime _FromDate = DateTime.Now;
        public DateTime FromDate
        {
            get
            {
                return this._FromDate;
            }
            set
            {
                if (value != this._FromDate)
                {
                    this._FromDate = value;
                }
            }
        }
        
        /// <summary>
        /// To Date Booking.
        /// </summary>
        private DateTime _ToDate = DateTime.Now.AddDays(1);
        public DateTime ToDate
        {
            get
            {
                return this._ToDate;
            }
            set
            {
                if (value != this._ToDate)
                {
                    this._ToDate = value;
                }
            }
        }
        
        /// <summary>
        /// How much Rooms want to rent our User.
        /// </summary>
        private int _Rooms = 0;
        public int Rooms
        {
            get
            {
                return this._Rooms;
            }
            set
            {
                if (value != this._Rooms)
                {
                    this._Rooms = value;
                }
            }
        }
        
        /// <summary>
        /// How much cost our booking.
        /// </summary>
        private double _BookingCost = 0;
        public double BookingCost
        {
            get
            {
                return this._BookingCost;
            }
            private set
            {
                this._BookingCost = this._Hotel.Price * (this._ToDate - this._FromDate).TotalDays * this._Rooms;
            }
        }
        
        /// <summary>
        /// User Class. Keeps information our user.
        /// </summary>
        private User _User = new User();
        public User User
        {
            get
            {
                return this._User;
            }
            set
            {
                if (value != this._User)
                {
                    this._User = value;
                }
            }
        }
    }
}
