using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maps
{
    public class Location:INotifyPropertyChanged
    {
        public Location(string name, double longitude, double latitude)
        {
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                RaisePropertyChanged();
            }
        }

        private double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
                RaisePropertyChanged();
            }
        }

        private double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
                RaisePropertyChanged();
            }
        }

        private Dictionary<string, double> values;
        public Dictionary<string, double> Values
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
