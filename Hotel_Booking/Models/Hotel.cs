using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class Hotel
    {
        private string _Name = "";
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
        private string _Description = "";
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
        private double _Price = 0;
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
        private string _Image = "";
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
        private string _Address = "";
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
        private int _AvailableRooms = 0;
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
