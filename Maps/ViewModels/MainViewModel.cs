using Maps.Models;
using System;
using System.Collections.Generic;
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
            OpenSettingsCommand = new RelayCommand(_ => WindowManager.OpenSettings());
            SaveAsCommand = new RelayCommand(_ => Bmp.SaveAsJpeg(WindowManager.SaveAs()), _=> Bmp!=null);

        }


        public RelayCommand OpenSettingsCommand { get; private set; }
        public RelayCommand SaveAsCommand { get; private set; }


        private void Update()
        {
            Bmp = new Bitmap(Model.Source);
            RaisePropertyChanged();
        }

        


        public Model Model { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;


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
                        return ((Model.RightLongitude - Model.LeftLongitude) / MapSource.Width) * X + Model.LeftLongitude;
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
                        return ((Model.BottomLatitude - Model.TopLatitude) / MapSource.Height) * Y + Model.TopLatitude;
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
