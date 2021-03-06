﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PontosColeta.UserApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private MainPageViewModel viewModel;
        public MapPage()
        {
            BindingContext = viewModel = MainPageViewModel.Current;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
            InitializeComponent();
        }

        private async void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(MainPageViewModel.Places):
                    UpdateMap();
                    break;
                case nameof(MainPageViewModel.Search):
                    if (string.IsNullOrEmpty(viewModel.Search))
                    {
                        await viewModel.LoadPlacesAsync();
                    }
                    break;
                default:
                    break;
            }
        }

        private void CheckSearch()
        {
            throw new NotImplementedException();
        }

        private void UpdateMap()
        {
            map.Pins.Clear();
            foreach (var item in viewModel.Places)
            {
                var pin = new Pin
                {
                    Label = item.Name,
                    Position = WKTToPosition(item.LocationWKT)
                };
                map.Pins.Add(pin);
            }
            map.MoveToRegion(MapSpan.FromCenterAndRadius(viewModel.Position.AsFormsPosition(), new Distance(500)));
        }

        private Position WKTToPosition(string wkt)
        {
            var split = wkt
                .Replace("POINT (", "").Replace(")", "")
                .Split(new[] { ' ' })
                .Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
            var position = new Position(split[1], split[0]);
            return position;

        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                await viewModel.LoadPlacesAsync();
            }
            catch (ApplicationException ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
                throw;
            }
        }
    }
}