using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickWeather.Objects
{
    public class City
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "coord")]
        public Coordinate Coordinates { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string CountryCode { get; set; }
    }
}
