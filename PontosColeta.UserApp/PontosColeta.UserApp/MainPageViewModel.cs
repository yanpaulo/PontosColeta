using Plugin.Geolocator.Abstractions;
using PontosColeta.UserApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PontosColeta.UserApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private MainPageViewModel() { }
        public static MainPageViewModel Current { get; private set; } = new MainPageViewModel();

        private WebService ws = new WebService();
        private List<Place> places;
        private string search;
        private bool isLoading;

        
        public Position Position { get; set; }

        public string Search
        {
            get { return search; }
            set { search = value; OnPropertyChanged(); }
        }

        public List<Place> Places
        {
            get { return places; }
            set { places = value; OnPropertyChanged(); }
        }

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(); }
        }

        public async Task LoadPlacesAsync()
        {
            try
            {
                IsLoading = true;
                Places = await ws.GetPlaces(Position?.AsWKT(), Search);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
