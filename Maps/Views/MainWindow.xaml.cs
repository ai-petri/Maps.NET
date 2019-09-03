using System;
using System.Collections.Generic;
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
