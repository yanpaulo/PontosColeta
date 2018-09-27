using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PontosColeta.UserApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            var last = await locator.GetLastKnownLocationAsync();
            var next = await locator.GetPositionAsync();
        }
    }
}
