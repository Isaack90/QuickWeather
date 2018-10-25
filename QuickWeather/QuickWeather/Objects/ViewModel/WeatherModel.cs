using System;
using System.Collections.Generic;
using System.Text;

namespace QuickWeather.Objects.ViewModel
{
    public class WeatherModel
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string WeaherConditionIcon { get; set; }

        public static WeatherModel FromObject(WeatherDetails obj)
        {
            var ret = new WeatherModel();

            ret.Date = obj.TimeStamp;
            ret.Humidity = obj.Humidity;
            ret.Temperature = obj.Temperature;
            ret.WeaherConditionIcon = obj.Condition[0].IconCode;

            return ret;
        }

        public static List<WeatherModel> FromList(List<WeatherDetails> lst)
        {
            var ret = new List<WeatherModel>();

            foreach (var item in lst)
            {
                ret.Add(FromObject(item));
            }

            return ret;
        }
    }
}
