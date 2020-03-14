using Hotel_Booking.Components.Data;
using Hotel_Booking.Components.Security;
using Hotel_Booking.Components.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    /// <summary>
    /// Booking Class. Organize your Booking.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Booking
    {
        private string _Oid = Crypt.GenerateSHA256(DateTime.Now.ToString());
        [JsonProperty("order_id")]
        public string Oid
        {
            get
            {
                return this._Oid;
            }
            set
            {
                if (value != this._Oid)
                {
                    this._Oid = value;
                }
            }
        }

        /// <summary>
        /// Hotel Oid. Keep Hotel information of your booking.
        /// </summary>
        private Guid _HotelOid = Guid.NewGuid();
        [JsonProperty("hotel_id")]
        public Guid HotelOid
        {
            get
            {
                return this._HotelOid;
            }
            set
            {
                if (value != this._HotelOid)
                {
                    this._HotelOid = value;
                }
            }
        }

        /// <summary>
        /// Hotel Object. Keep Hotel information of your booking.
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
        [JsonProperty("from_date")]
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
        [JsonProperty("to_date")]
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
        private int _Rooms = 1;
        [JsonProperty("rooms")]
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
                return this._BookingCost = this._Hotel.Price * (this._ToDate - this._FromDate).TotalDays * this._Rooms;
            }
            set
            {
                if (value != this._BookingCost)
                {
                    this._BookingCost = value;
                }
            }
        }
        
        /// <summary>
        /// User Class. Keeps information our user.
        /// </summary>
        private User _User = new User();
        [JsonProperty("user")]
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
