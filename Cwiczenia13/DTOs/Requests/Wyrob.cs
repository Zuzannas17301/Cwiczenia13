using System.Text.Json.Serialization;
using Cwiczenia13.DAL;

namespace Cwiczenia13.DTOs.Requests
{
    public class Wyrob
    {
        [JsonConverter(typeof(JsonIntToStringConverter))]
        public int ilosc { get; set; }
        public string wyrob { get; set; }
        public string uwagi { get; set; }
    }
}