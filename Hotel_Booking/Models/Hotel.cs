using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    /// <summary>
    /// Hotel Class. Keeping your hotel information
    /// </summary>
    public class Hotel
    {
        private Guid _Oid = Guid.NewGuid();
        [JsonProperty("id")]
        public Guid Oid
        {
            get
            {
                return this._Oid;
            }
            set
            {
                if(value != this._Oid)
                {
                    this._Oid = value;
                }
            }
        }

        /// <summary>
        /// Name of your Hotel.
        /// </summary>
        private string _Name = "";
        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (value != this._Name)
                {
                    this._Name = value;
                }
            }
        }
        
        /// <summary>
        /// Description of your Hotel.
        /// </summary>
        private string _Description = "";
        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                if (value != this._Description)
                {
                    this._Description = value;
                }
            }
        }
        
        /// <summary>
        /// Cost per day of your Hotel.
        /// </summary>
        private double _Price = 0;
        [JsonProperty("price")]
        public double Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                if (value != this._Price)
                {
                    this._Price = value;
                }
            }
        }
        
        /// <summary>
        /// Image path of your Hotel.
        /// </summary>
        private string _Image = "";
        [JsonProperty("image")]
        public string Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                if (value != this._Image)
                {
                    this._Image = value;
                }
            }
        }
        
        /// <summary>
        /// Address of your Hotel.
        /// </summary>
        private string _Address = "";
        [JsonProperty("address")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                if (value != this._Address)
                {
                    this._Address = value;
                }
            }
        }
        
        /// <summary>
        /// How much available Rooms have our Hotel.
        /// </summary>
        private int _AvailableRooms = 0;
        [JsonProperty("available_rooms")]
        public int AvailableRooms
        {
            get
            {
                return this._AvailableRooms;
            }
            set
            {
                if (value != this._AvailableRooms)
                {
                    this._AvailableRooms = value;
                }
            }
        }
    }
}
