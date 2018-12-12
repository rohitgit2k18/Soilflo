using System;
using System.Collections.Generic;
using NotiFit.Helpers;
using Xamarin.Forms;

namespace MobileFlo.Views.Home
{
    public partial class FinishedScreen : ContentPage
    {
        public FinishedScreen()
        {
            InitializeComponent();
            loadimage();
        }
        bool isCancelled = false;

        public void GetStatusReady()
        {
            Device.StartTimer(TimeSpan.FromHours(2), () =>
            {
                if (Settings.Status == "FI")
                {
                    //Device.BeginInvokeOnMainThread(GetStatus);
                    App.NavigationPage.Navigation.PushAsync(new HomePage());
                    return true;
                }

                return false;
            });
        }

        private void loadimage()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                {
                    Device.BeginInvokeOnMainThread(async () => {

                        if (isCancelled == true)
                        {
                            await XFBTNHauling.ScaleTo(1, 1000);
                            isCancelled = false;
                        }
                        else
                        {
                            await XFBTNHauling.ScaleTo(1.1, 1000);
                            isCancelled = true;
                        }
                    });


                    return true;
                }
            });

        }
        private void XFHauling_Click(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new Home.HomePage());
        }


    }
}
