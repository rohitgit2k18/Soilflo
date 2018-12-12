using System;
using System.Collections.Generic;
using MobileFlo.Services.Models.ResponseModels;
using Xamarin.Forms;

namespace MobileFlo.Views.Home
{
    public partial class QRCodeSucessPage : ContentPage
    {
        StarHaulingResponseModel _startHaulingResponse = new StarHaulingResponseModel();
        public QRCodeSucessPage(StarHaulingResponseModel startHaulingResponse)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _startHaulingResponse = startHaulingResponse;
        }

        public void Continue_Clicked(object sender, System.EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new WaitingScreen(_startHaulingResponse));
        }
    }
}
