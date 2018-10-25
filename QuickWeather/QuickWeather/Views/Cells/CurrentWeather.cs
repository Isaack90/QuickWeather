using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuickWeather.Views.Cells
{
    public class CurrentWeather: StackLayout
    {
        public CurrentWeather()
            : base()
        {
            this.init();
        }
         
        private void init()
        {
            var lblDate = new Label();
            var lblTemperature = new Label();
            var lblHumid = new Label();

            var lblWindSpeed = new Label();
            var lblClouds = new Label();

            var imgWindDir = new Image();
            var imgConditionIcon = new Image();

            var windDirSOurce = ImageSource.FromResource("QuickWeather.arrow.png");
            imgWindDir.Source = windDirSOurce;
            imgWindDir.SetBinding(Image.RotationProperty, "WindDirection");

            var conditionSource = new UriImageSource();
            conditionSource.SetBinding(UriImageSource.UriProperty, "WeaherConditionIcon");

            lblClouds.SetBinding(Label.TextProperty, "Clouds");
            lblDate.SetBinding(Label.TextProperty, "Date");
            lblHumid.SetBinding(Label.TextProperty, "Humidity");
            lblTemperature.SetBinding(Label.TextProperty, "Temperature");
            lblWindSpeed.SetBinding(Label.TextProperty, "WindSpeed");

            var head = new StackLayout()
            { Orientation = StackOrientation.Horizontal };
            var mid = new StackLayout()
            { Orientation = StackOrientation.Horizontal };
            var bottom = new StackLayout()
            { Orientation = StackOrientation.Horizontal };

            head.Children.Add(lblDate);
            head.Children.Add(imgConditionIcon);

            mid.Children.Add(lblWindSpeed);
            mid.Children.Add(imgWindDir);

            bottom.Children.Add(lblTemperature);
            bottom.Children.Add(lblHumid);

            this.Children.Add(head);
            this.Children.Add(mid);
            this.Children.Add(bottom);
        }
    }
}
