using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickWeather.Objects
{
    public class Coordinate
    {
        [JsonProperty(PropertyName = "lat")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "lon")]
        public string Longitude { get; set; }
    }
}
