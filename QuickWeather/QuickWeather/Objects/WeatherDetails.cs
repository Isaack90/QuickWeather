using Newtonsoft.Json;
using QuickWeather.Actions.JSON;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickWeather.Objects
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class WeatherDetails
    {
        [JsonProperty(PropertyName = "dt")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "main.temp")]
        public double Temperature { get; set; }

        [JsonProperty(PropertyName = "main.temp_min")]
        public string TempMin { get; set; }

        [JsonProperty(PropertyName = "main.temp_max")]
        public string TempMax { get; set; }

        [JsonProperty(PropertyName = "main.pressure")]
        public string Pressure { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public double Humidity { get; set; }

        [JsonProperty(PropertyName = "weather")]
        public IList<WeatherCondition> Condition { get; set; }

        [JsonProperty(PropertyName = "clouds.all")]
        public double Clouds { get; set; }

        [JsonProperty(PropertyName = "wind.speed")]
        public double WindSpeed { get; set; }

        [JsonProperty(PropertyName = "wind.deg")]
        public double WindDirection { get; set; }

        [JsonProperty(PropertyName = "dt_txt")]
        public DateTime TimeStamp { get; set; }
    }
}
