using QuickWeather.Actions;
using QuickWeather.Objects;
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
	public partial class SelectCity : ContentPage
	{
        private CityList cityList;

		public SelectCity ()
		{
			InitializeComponent ();

            this.init();
		}

        private void init()
        {
            this.cityList = new CityList();

            this.tbCity.TextChanged += TbCity_TextChanged;

            this.lvSuggestions.ItemsSource = this.cityList.SuggestedCities;

            this.lvSuggestions.ItemTemplate = new DataTemplate(typeof(CitySuggestionCell));

            this.lvSuggestions.ItemTapped += LvSuggestions_ItemTapped;
        }

        private async void LvSuggestions_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var obj = e.Item as City;

            var dw = new DisplayWeaher(obj.Id);

            await this.Navigation.PushModalAsync(dw);
        }

        private void displayWeather(int cityId)
        {
            var dw = new DisplayWeaher(cityId);

            this.Navigation.PushAsync(dw);
        }

        private void TbCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.cityList.Suggestion(e.NewTextValue);
            //this.lvSuggestions.ItemsSource = this.cityList.SuggestedCities;
        }
    }
}