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
	public partial class ListPage : ContentPage
	{
        private MainPageViewModel viewModel;

		public ListPage ()
		{
            BindingContext = viewModel = MainPageViewModel.Current;
			InitializeComponent ();
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