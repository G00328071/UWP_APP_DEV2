using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;

namespace MyWeather
{

    public class LocationManager
    {
        public static string statusMessage { get; private set; }

        public async static Task<Geoposition> GetLocation()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();


            switch (accessStatus)
            {
                case GeolocationAccessStatus.Unspecified:
                    statusMessage = "Location Error Unspecified";
                    break;
                case GeolocationAccessStatus.Allowed:
                    statusMessage = "Location Services Turned On";
                    break;
                case GeolocationAccessStatus.Denied:
                    statusMessage = "Location Services Turned Off.\nPlease Turn Location Services On. \nReset App To Show Weather.";
                   
                    break;
                default:
                    break;
            }

            var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };

            var myPosition = await geolocator.GetGeopositionAsync();

            return myPosition;


        }

       



    }

   

}
