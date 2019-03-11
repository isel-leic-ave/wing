using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima
{
    public class LocationInfo
    {
        public String Country { get;  }
        public String Region { get; }
        public double Latitude { get; }
        public double Longitude { get; }

        public LocationInfo(string country, string region, double latitude, double longitude)
        {
            Country = country;
            Region = region;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
