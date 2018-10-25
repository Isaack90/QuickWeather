using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuickWeather.Views.Cells
{
    public class FutureWeather: ViewCell
    {
        public FutureWeather()
        {
            this.init();
        }

        private void init()
        {
            var lblDate = new Label();
            var lblTemperature = new Label();
            var lblHumid = new Label();

            var imgIcon = new Image();
            var iconSource = new UriImageSource();

            iconSource.SetBinding(UriImageSource.UriProperty, "WeaherConditionIcon");
            imgIcon.Source = iconSource;

            lblDate.SetBinding(Label.TextProperty, "Date");
            lblHumid.SetBinding(Label.TextProperty, "Humidity");
            lblTemperature.SetBinding(Label.TextProperty, "Temperature");

            var head = new StackLayout()
            { Orientation = StackOrientation.Horizontal };

            var bottom = new StackLayout()
            { Orientation = StackOrientation.Horizontal };

            lblDate.HorizontalOptions = LayoutOptions.Start;
            imgIcon.HorizontalOptions = LayoutOptions.End;

            lblTemperature.HorizontalOptions = LayoutOptions.Center;
            lblHumid.HorizontalOptions = LayoutOptions.Center;

            head.Children.Add(lblDate);
            head.Children.Add(imgIcon);

            bottom.Children.Add(lblTemperature);
            bottom.Children.Add(lblHumid);

            var content = new StackLayout();
            content.Children.Add(head);
            content.Children.Add(bottom);

            this.View = content;

        }
    }
}
