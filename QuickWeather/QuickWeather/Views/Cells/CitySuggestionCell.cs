using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuickWeather.Views.Cells
{
    public class CitySuggestionCell: ViewCell
    {
        public CitySuggestionCell()
        {
            this.createCell();
        }

        private void createCell()
        {
            var lblCityName = new Label();
            var lblCountryCode = new Label();

            lblCityName.SetBinding(Label.TextProperty, "Name");
            lblCountryCode.SetBinding(Label.TextProperty, "CountryCode");

            var cPanel = new StackLayout();
            cPanel.Orientation = StackOrientation.Horizontal;

            var lblDiv = new Label();
            lblDiv.Text = ", ";

            cPanel.Children.Add(lblCityName);
            cPanel.Children.Add(lblDiv);
            cPanel.Children.Add(lblCountryCode);

            this.View = cPanel;
        }
    }
}
