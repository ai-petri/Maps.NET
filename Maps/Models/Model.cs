using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Models
{
    public class Model
    {
        public Model()
        {
            Locations.Add(new Location("test", 50, 50));
        }
        public event Action Updated;

        private string source;
        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
                Updated();
            }
        }
        public double BottomLatitude { get; set; }
        public double TopLatitude { get; set; }
        public double LeftLongitude { get; set; }
        public double RightLongitude { get; set; }

        private List<Location> locations = new List<Location>();
        public List<Location> Locations
        {
            get
            {
                return locations;
            }
            set
            {
                locations = value;
                Updated();
            }
        }
    }
}
