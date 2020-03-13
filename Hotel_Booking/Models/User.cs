using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    /// <summary>
    /// User Class. Keeps User information.
    /// </summary>
    public class User
    {
        /// <summary>
        /// First Name of your User.
        /// </summary>
        private string _FirstName = "";
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                if (value != this._FirstName)
                {
                    this._FirstName = value;
                }
            }
        }
        
        /// <summary>
        /// Last Name of your User.
        /// </summary>
        private string _LastName = "";
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                if (value != this._LastName)
                {
                    this._LastName = value;
                }
            }
        }
        
        /// <summary>
        /// Address of your User.
        /// </summary>
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
        
        /// <summary>
        /// E-Mail of your User.
        /// </summary>
        private string _Email = "";
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if (value != this._Email)
                {
                    this._Email = value;
                }
            }
        }
        
        /// <summary>
        /// Phone of your User.
        /// </summary>
        private string _Phone = "";
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                if (value != this._Phone)
                {
                    this._Phone = value;
                }
            }
        }
    }
}
