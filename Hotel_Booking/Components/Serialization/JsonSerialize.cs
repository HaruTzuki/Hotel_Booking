using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Components.Serialization
{
    public class JsonSerialize
    {
        public static T JsonObjectDeserialize<T>(string JsonText)
        {
            return JsonConvert.DeserializeObject<T>(JsonText);
        }

        public static string JsonObjectSerialize(object? Obj)
        {
            return JsonConvert.SerializeObject(Obj, Formatting.Indented);
        }
    }
}
