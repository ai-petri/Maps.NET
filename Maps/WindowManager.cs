using Maps.Models;
using Maps.ViewModels;
using Maps.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Maps
{
    public static class WindowManager
    {
        private static Model model;
        private static MainViewModel mainViewModel;

        static WindowManager()
        {
            model = new Model();
            mainViewModel = new MainViewModel(model);

        }

        public static void Start()
        {
            new MainWindow { DataContext = mainViewModel }.Show();
        }

        public static bool? OpenSettings()
        {
            SettingsViewModel settingsViewModel = new SettingsViewModel(model);
            SettingsWindow settingsWindow = new SettingsWindow { DataContext = settingsViewModel };

            return settingsWindow.ShowDialog();
        }


        public static string OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            else
            {
                return "";
            }
        }
    }
}
