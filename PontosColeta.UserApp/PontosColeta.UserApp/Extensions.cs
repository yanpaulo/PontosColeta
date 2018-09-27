using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PontosColeta.UserApp
{
    public static class Extensions
    {
        public static string AsWKT(this Position position) => 
            $"POINT({position.Longitude.ToString("G", CultureInfo.InvariantCulture)} {position.Latitude.ToString("G", CultureInfo.InvariantCulture)})";

        public static Xamarin.Forms.Maps.Position AsFormsPosition(this Position position) =>
            new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
    }
}
