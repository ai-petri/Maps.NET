using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            
        }

        private List<Rectangle> rectangles = new List<Rectangle>(); // кводратики, обозначающие станции

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewModels.MainViewModel).LocationsUpdated += LocationsUpdated;
            (DataContext as INotifyPropertyChanged).PropertyChanged += PropertyChanged;
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            foreach (Rectangle rectangle in rectangles)
            {
                Location location = rectangle.DataContext as Location;
                Canvas.SetLeft(rectangle, (DataContext as ViewModels.MainViewModel).GetX(location.Longitude));
                Canvas.SetTop(rectangle, (DataContext as ViewModels.MainViewModel).GetY(location.Latitude));
            }
        }

        private void LocationsUpdated()
        {
            // станции обозначаются квадратиками
            foreach (Location location in (DataContext as ViewModels.MainViewModel).Locations)
            {
                Rectangle rectangle = new Rectangle
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Red                    
                };

                Canvas.SetLeft(rectangle, (DataContext as ViewModels.MainViewModel).GetX(location.Longitude));
                Canvas.SetTop(rectangle, (DataContext as ViewModels.MainViewModel).GetY(location.Latitude));

                rectangle.DataContext = location;

                rectangles.Add(rectangle);
                MapCanvas.Children.Add(rectangle);
            }
        }

        private void ScrollViewer_MouseMove(object sender, MouseEventArgs e)
        {
            (DataContext as ViewModels.MainViewModel).X = Mouse.GetPosition(Map).X;
            (DataContext as ViewModels.MainViewModel).Y = Mouse.GetPosition(Map).Y;
        }


        private void ScrollViewer_LayoutUpdated(object sender, EventArgs e)
        {
            (DataContext as ViewModels.MainViewModel).ViewportWidth = ScrollViewer.ViewportWidth;
        }

        
    }
    
}
