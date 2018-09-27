using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using PontosColeta.UserApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PontosColeta.UserApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        private MainPageViewModel viewModel;

        public MainPage ()
        {
            BindingContext = viewModel = MainPageViewModel.Current;
            InitializeComponent();
        }

        private async void TabbedPage_Appearing(object sender, EventArgs e)
        {
            var geolocator = CrossGeolocator.Current;
            viewModel.Position = await geolocator.GetPositionAsync();
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