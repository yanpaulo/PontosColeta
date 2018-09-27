using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PontosColeta.UserApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private MainPageViewModel() { }
        public static MainPageViewModel Current { get; private set; } = new MainPageViewModel();

        private List<Place> places;

        public Position Position { get; set; }

        public List<Place> Places
        {
            get { return places; }
            set { places = value; OnPropertyChanged(); }
        }


        private void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
