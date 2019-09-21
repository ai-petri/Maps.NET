using Maps.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Maps.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel(Model model)
        {
            Model = model;
            model.Updated += Update;
            model.SourceUpdated += UpdateSource;
            OpenSettingsCommand = new RelayCommand(_ => WindowManager.OpenSettings());
            SaveAsCommand = new RelayCommand(_ => Bmp.SaveAsJpeg(WindowManager.SaveAs()), _=> Bmp!=null);

            Locations  = new ObservableCollection<Location>(Model.Locations);
        }


        public RelayCommand OpenSettingsCommand { get; private set; }
        public RelayCommand SaveAsCommand { get; private set; }

        private ObservableCollection<Location> locations = new ObservableCollection<Location>();
        public ObservableCollection<Location> Locations
        {
            get
            {
                return locations;
            }
            set
            {
                locations = value;
                LocationsUpdated?.Invoke();
            }
        }


        private void UpdateSource()
        {
            if(Model.Source != "" && File.Exists(Model.Source))
            {
                Bmp = new Bitmap(Model.Source);
            }
        }

        private void Update()
        {
            Locations = new ObservableCollection<Location>(Model.Locations);
        }


        public Model Model { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action LocationsUpdated;


        private Bitmap bmp;
        public Bitmap Bmp
        {
            get
            {
                return bmp;
            }
            set
            {
                bmp = value;
                MapSource = bmp.ToBitmapImage();
            }
        }
            


        private ImageSource mapSource;
        public ImageSource MapSource
        {
            get
            {
                return mapSource;
            }
            set
            {
                mapSource = value;
               Scale = 100.0 * ViewportWidth / value.Width;
                RaisePropertyChanged("");
            }
        }



        // Координаты
        #region

        private double x = 0.0;

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
                RaisePropertyChanged("");
            }
        }


        private double y = 0.0;

        public double  Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                RaisePropertyChanged("");
            }
        }


        public double GetX(double longitude)
        {
            if (MapSource is null)
            {
                return 0.0;
            }
            else
            {
                if (MapSource.Width>0 && (Model.RightLongitude - Model.LeftLongitude)!=0)
                {
                    return 0.01* Scale * (longitude - Model.LeftLongitude) * MapSource.Width / (Model.RightLongitude - Model.LeftLongitude); 
                }
                else return 0.0;
            }
            
        }

        public double GetY(double latitude)
        {
            if (MapSource is null)
            {
                return 0.0;
            }
            else
            {
                if (MapSource.Height > 0 && (Model.TopLatitude - Model.BottomLatitude)!=0)
                {
                    return  0.01 * Scale * ((Model.TopLatitude - latitude - Model.BottomLatitude) * MapSource.Height / (Model.TopLatitude - Model.BottomLatitude));

                }
                else return 0.0;
            }
        }
       
        public double Longitude
        {
            get
            {
                if (MapSource is null)
                {
                    return 0.0;
                }
                else
                {
                    if (MapSource.Width > 0)
                    {
                        return (((Model.RightLongitude - Model.LeftLongitude) / MapSource.Width) * X + Model.LeftLongitude) / (0.01*Scale);
                    }
                    else return 0.0;
                }
            }
        }


        public double Latitude
        {
            get
            {
                if (MapSource is null)
                {
                    return 0.0;
                }
                else
                {
                    if (MapSource.Height > 0)
                    {
                        return Model.TopLatitude - ((( Model.TopLatitude - Model.BottomLatitude) / MapSource.Height) * Y + Model.BottomLatitude) / ( 0.01 * Scale);
                    }
                    else return 0.0;
                }
            }            
        }

        #endregion 


        public double Width
        {
            get
            {
                return 0.01 * Scale * (MapSource?.Width ?? 0.0);
            }
        }

        public double ViewportWidth { get; set; }
        


        private double scale = 100.0;
        public double Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
                RaisePropertyChanged("");
            }
        }






        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
