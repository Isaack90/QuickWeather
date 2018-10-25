using System;
using System.Collections.Generic;
using System.Text;

namespace QuickWeather.Objects.ViewModel
{
    public class CurrentWeatherModel: WeatherModel
    {
        public double WindSpeed { get; set; }
        public double WindDirection { get; set; }
        public double Clouds { get; set; }

        public static CurrentWeatherModel FromObject(WeatherDetails obj)
        {
            var ret = new CurrentWeatherModel();

            ret.Date = obj.TimeStamp;
            ret.Humidity = obj.Humidity;
            ret.Temperature = obj.Temperature;
            ret.WeaherConditionIcon = obj.Condition[0].IconCode;
            ret.Clouds = obj.Clouds;
            ret.WindDirection = obj.WindDirection;
            ret.WindSpeed = obj.WindSpeed;

            return ret;
        }

        public static List<CurrentWeatherModel> FromList(List<WeatherDetails> lst)
        {
            var ret = new List<CurrentWeatherModel>();

            foreach (var item in lst)
            {
                ret.Add(FromObject(item));
            }

            return ret;
        }
    }
}
