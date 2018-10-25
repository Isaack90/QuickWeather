using Newtonsoft.Json;
using QuickWeather.Objects;
using QuickWeather.Objects.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace QuickWeather.Actions
{
    public class WeatherForecast
    {
        static string URL = @"http://api.openweathermap.org/data/2.5/";
        static string ICON_URL = @"openweathermap.org/img/w/";
        static string API_KEY = "APPID=8f8ea157fe9814c83c03316a85d4382f";

        public Weather Weather
        {
            get
            {
                return this.weather;
            }
        }

        private Weather weather;

        public WeatherForecast()
        {
            this.weather = new Weather();
        }

        public void GetByCityId(string cityId)
        {
            var reqString = URL + "forecast" + "?" + "id=" + cityId + "&" + API_KEY;

            var jsonString = this.executeGet(reqString);

            this.weather = JsonConvert.DeserializeObject<Weather>(jsonString);
        }

        public CurrentWeatherModel GetCurrentWeatherModel()
        {
            var cWeather = this.weather.Details.OrderBy(o => o.TimeStamp).First();

            var cWeatherModel = CurrentWeatherModel.FromObject(cWeather);

            return cWeatherModel;
        }

        public List<WeatherModel> GetForecaseList()
        {
            var forecastList = new List<WeatherModel>();

            for (int i =1; i == 4; i++)
            {
                var cLst = this.getWeatherDetailsByDay(i);

                var wModel = new WeatherModel();

                wModel.Date = cLst.First().TimeStamp.Date;
                wModel.Humidity = cLst.Average(o=>o.Humidity);
                wModel.Temperature = cLst.Average(o=>o.Temperature);
                wModel.WeaherConditionIcon = ICON_URL + cLst.First().Condition.First().IconCode + ".png";

                forecastList.Add(wModel);
            }

            return forecastList;
        }

        private List<WeatherDetails> getWeatherDetailsByDay(int day)
        {
            var weather = this.weather.Details.Where(o =>
                            o.TimeStamp.Date == DateTime.Today.AddDays(day)
                            ).ToList();

            return weather;
        }

        private string executeGet(string url)
        {
            var req = WebRequest.Create(url);

            var resp = req.GetResponse();

            var reader = new StreamReader(resp.GetResponseStream());

            var respString = reader.ReadToEnd();

            reader.Close();
            resp.Close();

            return respString;
        }
    }
}
