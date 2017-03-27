using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Map : Page
    {
       
    
        public Map()
        {
            this.InitializeComponent();
        }

        public async  void myMap_Loaded(object sender, RoutedEventArgs e)
        {
            myMap.MapServiceToken = "TOfdeDRJwGImuiaL7W88~SlMn6bqFU6GCmOupV2lB-g~AsoKvGZZisSkTudn4cs2nwQzmGl7eS58HojnUjiskKBwBEYkH-7yUV7sRAXsADIr";
            var location = new Geolocator();
            location.DesiredAccuracyInMeters = 50;

            var position = await location.GetGeopositionAsync();
              await myMap.TrySetViewAsync(position.Coordinate.Point,10D);

           
            
            
        }

        private void myMap_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {

        }

        private void MenuFlyoutItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
