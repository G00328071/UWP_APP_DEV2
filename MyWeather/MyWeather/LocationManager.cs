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

        public async static Task<Geoposition> GetLocation()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            if (accessStatus != GeolocationAccessStatus.Allowed) throw new Exception();

            var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };

            var myPosition = await geolocator.GetGeopositionAsync();

            return myPosition;


        }


    }



}
