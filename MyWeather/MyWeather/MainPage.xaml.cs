using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += Weather_Loaded;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            showCurrentWeather();

        }
        private void MenuFlyoutItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(Map));



        }

        public void Weather_Loaded(object sender, RoutedEventArgs e)
        {
            string sValue = "Weather";
            // check settings to see what the user looked at last.
            // example of settings in the backgroundtasks example in class
            // applicationdata.current.localsettings value
            // swith on the value
            switch (sValue)
            {
                case "Weather":
                    showCurrentWeather();
                    break;

                case "Compass":
                    break;

                default:
                    break;
            }

        }

        private async void showCurrentWeather()
        {
            var position = await LocationManager.GetLocation();
            try
            {
                RootObject myWeather = await OpenWeatherMapProxy.GetWeather(position.Coordinate.Point.Position.Latitude, position.Coordinate.Point.Position.Longitude);

                //icon url given by API
                string icon = String.Format("ms-appx:///Assets/images/{0}.png", myWeather.weather[0].icon);
                ImageResult.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                tlbResult_temp.Text = myWeather.name + " Temp - " + (myWeather.main.temp).ToString() + "C° " + myWeather.weather[0].description;
                tlbResult_pressure.Text = myWeather.name + " Pressure - " + (myWeather.main.pressure).ToString() + " : pascals";
                tlbResult_wind.Text = myWeather.name + " Wind - " + (myWeather.wind.speed).ToString() + " : mph :: " + " direction " + (myWeather.wind.deg) + "°";
                tlbResult_sunrise.Text = myWeather.name + " Sunrise :" + String.Format("{0:d/M/yyyy HH:mm:ss}", new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(myWeather.sys.sunrise));
                tlbResult_sunset.Text = myWeather.name + " Sunset :" + String.Format("{0:d/M/yyyy HH:mm:ss}", new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(myWeather.sys.sunset));
            }
            catch (Exception)
            {
                tlbError.Text = "Sorry Gps location service not available";
                ImageResult.Source = null;
                tlbResult_temp.Text = "";
                tlbResult_pressure.Text = "";
                tlbResult_wind.Text = "";
                tlbResult_sunrise.Text = "";
                tlbResult_sunset.Text = "";
            }
        }

       
    }
}
