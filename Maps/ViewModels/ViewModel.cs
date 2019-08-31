using Maps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {

        public ViewModel(Model model)
        {
            Model = model;
        }

        public Model Model { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
