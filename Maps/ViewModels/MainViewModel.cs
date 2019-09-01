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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Maps.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel(Model model)
        {
            Model = model;

           Bmp = new Bitmap("C:\\Users\\home\\Desktop\\image.jpg");
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
                mapSource = bmp.ToBitmapImage();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
            }
        }

        public double Longitude
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
                RaisePropertyChanged();
            }
        }


        public double Latitude
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                RaisePropertyChanged();
            }
        }

        #endregion 

        

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
