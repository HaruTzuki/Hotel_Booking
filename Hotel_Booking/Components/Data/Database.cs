using System;
using System.IO;

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
            try
            {
                using (StreamReader _SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Context", "hotel_db.json")))
                {
                    mRet = _SR.ReadToEnd();
                    _SR.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
            try
            {
                using (StreamReader _SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Context", "bookings.json")))
                {
                    mRet = _SR.ReadToEnd();
                    _SR.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return mRet;
        }

        /// <summary>
        /// Save bookings to db
        /// </summary>
        /// <param name="JsonText"></param>
        public static void CommitBookings(string JsonText)
        {
            try
            {
                using (StreamWriter _SW = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Context", "bookings.json")))
                {
                    _SW.Write(JsonText);
                    _SW.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Getting Email Body from Text.
        /// </summary>
        /// <returns></returns>
        public static string GetEmailBody()
        {
            string mRet = "";
            try
            {
                using (StreamReader _SW = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Context", "EmailBody.txt")))
                {
                    mRet = _SW.ReadToEnd();
                    _SW.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return mRet;
        }
    }
}
