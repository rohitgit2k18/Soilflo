using MobileFlo.Services.Models.ResponseModels;
using NotiFit.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileFlo.Views.Home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadInformation : ContentPage
	{
        private GetLoadInfoResponseModel getLoadInfoResponse;
        public LoadInformation (GetLoadInfoResponseModel getLoadInfoResponse)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = getLoadInfoResponse;
            //this.BindingContext = starHaulingResponseModel;
		}

        private async void XFBackbtn_Tapped(object sender, TappedEventArgs e)
        {
            await App.NavigationPage.Navigation.PopAsync();
        }

    }
}