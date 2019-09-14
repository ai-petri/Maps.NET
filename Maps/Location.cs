using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps
{
    public class Location
    {
        public Location(string name, double longitude, double latitude)
        {
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }


        public Dictionary<string, double> Values { get; set; }
    }
}
