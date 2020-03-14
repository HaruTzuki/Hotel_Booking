using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Components.Serialization
{
    public class JsonSerialize
    {
        /// <summary>
        /// Deserialize Json Text to templated type of object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="JsonText">Json text to deserialize</param>
        /// <returns></returns>
        public static T JsonObjectDeserialize<T>(string JsonText)
        {
            return JsonConvert.DeserializeObject<T>(JsonText);
        }

        /// <summary>
        /// Serialize Object to JSON file
        /// </summary>
        /// <param name="Obj">Object to serialize</param>
        /// <returns></returns>
        public static string JsonObjectSerialize(object? Obj)
        {
            return JsonConvert.SerializeObject(Obj, Formatting.Indented);
        }
    }
}
