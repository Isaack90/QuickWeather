using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickWeather.Objects
{
    public class Weather
    {
        [JsonProperty(PropertyName = "list")]
        public IList<WeatherDetails> Details { get; set; }

        [JsonProperty(PropertyName = "city")]
        public City City { get; set; }
    }
}
