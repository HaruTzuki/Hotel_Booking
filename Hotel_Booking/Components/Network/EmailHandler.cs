using System.Net;
using System.Net.Mail;
using System.Text;

namespace Hotel_Booking.Components.Network
{
    /// <summary>
    /// Email Handler Class is resposable to send e-mail
    /// </summary>
    public class EmailHandler
    {
        /// <summary>
        /// Smtp Client Object.
        /// </summary>
        private readonly SmtpClient Client;

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="Host"></param>
        /// <param name="Port"></param>
        /// <param name="Ssl"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        public EmailHandler(string Host, int Port, bool Ssl, string Username, string Password)
        {
            Client = new SmtpClient(Host, Port);
            Client.EnableSsl = Ssl;
            Client.Credentials = new NetworkCredential(Username, Password);
        }

        /// <summary>
        /// Send Email Method
        /// </summary>
        /// <param name="From">Email From where you send</param>
        /// <param name="DisplayName">How do you want receiver see email name</param>
        /// <param name="To">Receiver E-Mail</param>
        /// <param name="Body">Email Body as HTML</param>
        /// <param name="Subject">Subject of email</param>
        public void SendEMail(string From, string DisplayName, string To, string Body, bool IsHtml, string Subject)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(From, DisplayName, Encoding.UTF8);
            mailMessage.To.Add(To);
            mailMessage.Body = Body;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = IsHtml;
            mailMessage.Subject = Subject;
            Client.Send(mailMessage);
        }
    }
}
