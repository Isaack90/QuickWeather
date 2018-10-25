using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickWeather.Objects
{
    public class WeatherCondition
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "main")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string IconCode { get; set; }
    }
}
