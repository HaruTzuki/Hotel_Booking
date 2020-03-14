using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Booking.Components.Security
{
    public class Crypt
    {
        /// <summary>
        /// Generate SHA-256 Hash from Plain Text
        /// </summary>
        /// <param name="PlainText"></param>
        /// <returns></returns>
        public static string GenerateSHA256(string PlainText)
        {
            using (SHA256 Sha256Hash = SHA256.Create())
            {
                // Compute Hash and return byte array.
                byte[] HashingBytes = Sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(PlainText));

                // Converting byte array to string.
                StringBuilder _Builder = new StringBuilder();
                for (int i = 0; i < HashingBytes.Length; i++)
                {
                    _Builder.Append(HashingBytes[i].ToString("x2"));
                }

                return _Builder.ToString();
            }
        }
    }
}
