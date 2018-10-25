using QuickWeather.Actions;
using QuickWeather.Views.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuickWeather.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DisplayWeaher : ContentPage
	{
        private WeatherForecast weatherForecast;

		public DisplayWeaher (int cityId)
		{
			InitializeComponent ();

            this.init(cityId);
		}

        private void init(int cityId)
        {
            this.weatherForecast = new WeatherForecast();

            var lvFWeather = new ListView();
            lvFWeather.ItemTemplate = new DataTemplate(typeof(FutureWeather));

            var cWeather = new CurrentWeather();

            this.pnl.Children.Add(cWeather);
            this.pnl.Children.Add(lvFWeather);

            this.weatherForecast.GetByCityId(cityId.ToString());

            cWeather.BindingContext = this.weatherForecast.GetCurrentWeatherModel();
            lvFWeather.ItemsSource = this.weatherForecast.GetForecaseList();
        }
    }
}