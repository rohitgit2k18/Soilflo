using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileFlo.Views.Home
{
    public partial class FailureScreen : ContentPage
    {
        public FailureScreen()
        {
            InitializeComponent();
        }

        public void XFReturn_Clicked(object sender, System.EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new HomePage());
        }
    }


}
