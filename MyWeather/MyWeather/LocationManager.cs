using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

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
                     statusMessage = "Location Unspecified Error";
                    break;
                case GeolocationAccessStatus.Allowed:
                    statusMessage = "Location Access Allowed";
                    break;
                case GeolocationAccessStatus.Denied:
                    statusMessage = "Location Access denied";
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
