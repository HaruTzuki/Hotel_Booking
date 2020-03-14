using Hotel_Booking.Components.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Components.Data
{
    public class Database
    {
        /// <summary>
        /// Fetch Available Hotel
        /// </summary>
        /// <returns></returns>
        public static string Fetch()
        {
            string mRet = "";
            using (StreamReader _SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Context", "hotel_db.json")))
            {
                mRet = _SR.ReadToEnd();
                _SR.Close();
            }

            return mRet;
        }

        /// <summary>
        /// Fetch Bookings
        /// </summary>
        /// <returns></returns>
        public static string FetchBookings()
        {
            string mRet = "";
            using(StreamReader _SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Context", "bookings.json")))
            {
                mRet = _SR.ReadToEnd();
                _SR.Close();
            }

            return mRet;
        }

        /// <summary>
        /// Save bookings to db
        /// </summary>
        /// <param name="JsonText"></param>
        public static void CommitBookings(string JsonText)
        {
            using (StreamWriter _SW = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Context", "bookings.json")))
            {
                _SW.Write(JsonText);
                _SW.Close();
            }
        }
    }
}
