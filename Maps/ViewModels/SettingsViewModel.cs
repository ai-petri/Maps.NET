using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Maps.ViewModels
{
    public class SettingsViewModel:INotifyPropertyChanged
    {
        

        public SettingsViewModel(Models.Model model)
        {
            Model = model;

            OpenFileCommand = new RelayCommand(_ =>  Source = WindowManager.OpenFile());
            AddLocationCommand = new RelayCommand(_ => Locations.Add(new Location("", 0, 0)));

            Source = model.Source;
            BottomLatitude = model.BottomLatitude;
            TopLatitude = model.TopLatitude;
            LeftLongitude = model.LeftLongitude;
            RightLongitude = model.RightLongitude;

            Locations = new ObservableCollection<Location>(Model.Locations);
        }

        public Models.Model Model { get; private set; }


        public ObservableCollection<Location> Locations { get; private set; }
        


        #region

        //Latitude
        private double bottomLatitude;
        public double BottomLatitude
        {
            get
            {
                return bottomLatitude;
            }
            set
            {
                bottomLatitude = value;
                RaisePropertyChanged();
            }
        }
        private double topLatitude;
        public double TopLatitude
        {
            get
            {
                return topLatitude;
            }
            set
            {
                topLatitude = value;
                RaisePropertyChanged();
            }
        }

        //Longitude
        private double leftLongitude;
        public double LeftLongitude
        {
            get
            {
                return leftLongitude;
            }
            set
            {
                leftLongitude = value;
                RaisePropertyChanged();
            }
        }
        private double rightLongitude;
        public double RightLongitude
        {
            get
            {
                return rightLongitude;
            }
            set
            {
                rightLongitude = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        private string source = "";
        public string Source
        {
            get
            {
                return source;
            }
            set
            {
               
                source = value;
                RaisePropertyChanged();
            }
        }


        public void SaveChanges()
        {
            Model.Source = Source;
            Model.BottomLatitude = BottomLatitude;
            Model.TopLatitude = TopLatitude;
            Model.LeftLongitude = LeftLongitude;
            Model.RightLongitude = RightLongitude;
            Model.Locations = new List<Location>(Locations);
            

        }

        public RelayCommand OpenFileCommand { get; private set; }
        public RelayCommand AddLocationCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
