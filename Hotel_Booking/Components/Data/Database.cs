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
        public static string Fetch()
        {
            string mRet = "";
            using (StreamReader _SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Data", "hotel_db.json")))
            {
                mRet = _SR.ReadToEnd();
            }

            return mRet;
        }
    }
}
