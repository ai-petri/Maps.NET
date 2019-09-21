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
        public event Action SourceUpdated;
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
                if (source != value)
                {
                    source = value;
                    SourceUpdated();
                }                
            }
        }
        private double bottomLatitude = 0;
        public double BottomLatitude
        {
            get
            {
                return bottomLatitude;
            }
            set
            {
                if(bottomLatitude != value)
                {
                    bottomLatitude = value;
                    Updated();
                }               
            }
        }

        private double topLatitude = 100;
        public double TopLatitude
        {
            get
            {
                return topLatitude;
            }
            set
            {
                if(topLatitude != value)
                {
                    topLatitude = value;
                    Updated();
                }
            }
        }

        private double leftLongitude = 0;
        public double LeftLongitude
        {
            get
            {
                return leftLongitude;
            }
            set
            {
                leftLongitude = value;
                Updated();
            }
        }

        private double rightLongitude = 100;
        public double RightLongitude
        {
            get
            {
                return rightLongitude;
            }
            set
            {
                if (rightLongitude != value)
                {
                    rightLongitude = value;
                    Updated();
                }
            }
        }


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
