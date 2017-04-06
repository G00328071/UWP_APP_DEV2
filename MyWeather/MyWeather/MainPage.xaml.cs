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
using Windows.ApplicationModel.Background;
using Windows.Storage;

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
        private void MenuFlyoutItem_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(myNote));
        }

       

        public void Weather_Loaded(object sender, RoutedEventArgs e)
        {
            showCurrentWeather();
        }

        private async void showCurrentWeather()
        {
           
            try
            {
                var position = await LocationManager.GetLocation();
                tlbError.Text = LocationManager.statusMessage;
                RootObject myWeather = await OpenWeatherMapProxy.GetWeather(position.Coordinate.Point.Position.Latitude, position.Coordinate.Point.Position.Longitude);

                //icon name given by API then referenced to the Assets /images folder
                tlbError.Text = "";
                string icon = String.Format("ms-appx:///Assets/images/{0}.png", myWeather.weather[0].icon);
                ImageResult.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                //present weather data to screen
                tlbResult_location.Text = "Your present location is : "+ myWeather.name;
                tlbResult_temp.Text =  " Temp - " + (myWeather.main.temp).ToString() + "C° " + myWeather.weather[0].description;
                tlbResult_pressure.Text =  " Pressure - " + (myWeather.main.pressure).ToString() + " : pascals";
                tlbResult_wind.Text =  " Wind - " + (myWeather.wind.speed).ToString() + " : mph :: " + " direction " + (myWeather.wind.deg) + "°";
                tlbResult_sunrise.Text = " Sunrise :" + String.Format("{0:d/M/yyyy HH:mm:ss}", new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(myWeather.sys.sunrise));
                tlbResult_sunset.Text =  " Sunset :" + String.Format("{0:d/M/yyyy HH:mm:ss}", new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(myWeather.sys.sunset));
            }
            catch (Exception)
            {
                //something goes wrong all tables set to null
                tlbError.Text = LocationManager.statusMessage; 
                ImageResult.Source = null;
                tlbResult_location.Text = "";
                tlbResult_temp.Text = "";
                tlbResult_pressure.Text = "";
                tlbResult_wind.Text = "";
                tlbResult_sunrise.Text = "";
                tlbResult_sunset.Text = "";
            }
        }

        
    }
}
