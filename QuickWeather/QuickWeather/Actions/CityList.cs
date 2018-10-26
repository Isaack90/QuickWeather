using Newtonsoft.Json;
using QuickWeather.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QuickWeather.Actions
{
    public class CityList
    {
        public List<City> Cities { get; set; }
        public ObservableCollection<City> SuggestedCities { get; set; }

        public CityList()
        {
            this.Cities = new List<City>();
            this.SuggestedCities = new ObservableCollection<City>();

            this.loadCityList();
        }

        public void Suggestion(string name)
        {
            var lstCities = new List<City>();

            lstCities
                .AddRange(
                this.Cities.Where(o => o.Name.StartsWith(name))
                .ToList());

            this.SuggestedCities.Clear();

            for (int i = 0; i < 10; i++)
            {
                if (!this.SuggestedCities.Contains(lstCities[i]))
                {
                    this.SuggestedCities.Add(lstCities[i]);
                }
            }
        }

        private void loadCityList()
        {
            var assm = IntrospectionExtensions.GetTypeInfo(typeof(CityList)).Assembly;

            Stream stream = assm.GetManifestResourceStream("QuickWeather.Resources.cityList.json");

            string jsonList = string.Empty;

            using (var reader = new System.IO.StreamReader(stream))
            {
                jsonList = reader.ReadToEnd();
            }

            var lst = JsonConvert.DeserializeObject<List<City>>(jsonList);

            this.Cities = lst.OrderBy(o => o.Name).ToList();

            
        }
    }
}
