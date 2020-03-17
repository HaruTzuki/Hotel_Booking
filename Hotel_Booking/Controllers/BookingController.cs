using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Components.Data;
using Hotel_Booking.Components.Network;
using Hotel_Booking.Components.Serialization;
using Hotel_Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking.Controllers
{
    public class BookingController : Controller
    {

        #region Properties
        private EmailHandler EmailHandler;
        private string HostUrl = string.Empty;
        #endregion

        #region Constructor
        public BookingController(EmailHandler EmailHandler)
        {
            this.EmailHandler = EmailHandler;
        } 
        #endregion

        #region Controller Actions
        /// <summary>
        /// Basic method for Booking Page
        /// </summary>
        /// <param name="Id">Hotel Id</param>
        /// <returns></returns>
        public IActionResult Order(Guid Id)
        {
            // Basic Url
            ViewData["Url"] = HostUrl = $"{this.Request.Scheme}://{this.Request.Host}";

            // Initialize Properties
            Hotel Hotel = new Hotel();
            List<Booking> Bookings = new List<Booking>();

            // Get values from DB
            Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(x => x.Oid == Id).FirstOrDefault();

            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            // Check if our object is null after db call
            if (Bookings is null)
                Bookings = new List<Booking>();

            // Subtraction available rooms
            Hotel.AvailableRooms -= Bookings.Where(x => x.HotelOid == Id).Select(x => x.Rooms).Sum();

            // Return our view.
            return View(Hotel);
        }

        /// <summary>
        /// Post method to Complete Booking.
        /// </summary>
        /// <param name="Booking">Booking Object</param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult CompleteOrder(Booking Booking)
        {
            // Basic Url
            HostUrl = $"{this.Request.Scheme}://{this.Request.Host}";

            // Initialize Properties
            List<Booking> Bookings = new List<Booking>();

            // Get values from db
            Booking.Hotel = JsonSerialize.JsonObjectDeserialize<List<Hotel>>(Database.Fetch()).Where(x => x.Oid == Booking.HotelOid).FirstOrDefault();
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            // Check if object is null
            if (Bookings is null)
                Bookings = new List<Booking>();

            // Add booking object to list.
            Bookings.Add(Booking);

            // Commit changes in db.
            Database.CommitBookings(JsonSerialize.JsonObjectSerialize(Bookings));

            // Send Confirmation E-Mail
            Task EmailTask = new Task(() => EmailBookingConfirmation(Booking));
            EmailTask.Start();

            // return our view
            return View("BookingComplete", Booking);
        }

        /// <summary>
        /// Post method to delete a booking
        /// </summary>
        /// <param name="BookingId">Booking Id</param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult DeleteBooking(string BookingId)
        {
            // Initialize Properties
            List<Booking> Bookings = new List<Booking>();

            // Get values from db
            Bookings = JsonSerialize.JsonObjectDeserialize<List<Booking>>(Database.FetchBookings());

            // Find and remove object based on booking id
            Bookings.Remove(Bookings.Where(x => x.Oid == BookingId).FirstOrDefault());

            // Commit changes in db
            Database.CommitBookings(JsonSerialize.JsonObjectSerialize(Bookings));

            // Return again same page.
            return RedirectToAction("Bookings", "Home");
        } 
        #endregion

        #region Custom Methods
        /// <summary>
        /// Sending Email Confirmation
        /// </summary>
        /// <param name="Booking"></param>
        private void EmailBookingConfirmation(Booking Booking)
        {
            // Build Body
            string EmailBody = Database.GetEmailBody()
                .Replace("@FirstName", Booking.User.FirstName)
                .Replace("@LastName", Booking.User.LastName)
                .Replace("@Address", Booking.User.Address)
                .Replace("@Email", Booking.User.Email)
                .Replace("@Phone", Booking.User.Phone)
                .Replace("@BookingId", Booking.Oid)
                .Replace("@HotelName", Booking.Hotel.Name)
                .Replace("@HotelAddress", Booking.Hotel.Address)
                .Replace("@HotelDescription", Booking.Hotel.Description)
                .Replace("@HotelPrice", Booking.Hotel.Price.ToString())
                .Replace("@HotelAvailableRooms", Booking.Hotel.AvailableRooms.ToString())
                .Replace("@BookingFromDate", Booking.FromDate.ToString("dd/MM/yyyy"))
                .Replace("@BookingToDate", Booking.ToDate.ToString("dd/MM/yyyy"))
                .Replace("@BookingRooms", Booking.Rooms.ToString())
                .Replace("@BookingCost", Booking.BookingCost.ToString())
                .Replace("@Url", HostUrl)
                ;

            // Send Email
            this.EmailHandler.SendEMail("info@hotelbooking.com", "Hotel Booking", Booking.User.Email, EmailBody, true, "Successfully booking placed");
        } 
        #endregion


    }
}
