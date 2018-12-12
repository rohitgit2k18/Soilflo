using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileFlo.Views.Home
{
    public partial class FAQ : ContentPage
    {
        public FAQ()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var page = new FAQPage();
            MainView.Content = page.Content;
        }
        private async void XFBackbtn_Tapped(object sender, TappedEventArgs e)
        {
            await App.NavigationPage.Navigation.PopAsync();
        }
        private void XFFAQBtn_Click(object sender, EventArgs e)
        {
            XFBtnFAQ.BackgroundColor = Color.FromHex("#D0550D");
            XFBtnAboutUs.BackgroundColor = Color.FromHex("#2E2E2E");
            XFBtnTnC.BackgroundColor = Color.FromHex("#2E2E2E");
            //XFBtnPP.BackgroundColor = Color.FromHex("#2E2E2E");
            var page = new FAQPage();
            MainView.Content = page.Content;

        }

        private void XFAboutUs_Click(object sender,EventArgs e)
        {
            XFBtnFAQ.BackgroundColor = Color.FromHex("#2E2E2E");
            XFBtnAboutUs.BackgroundColor = Color.FromHex("#D0550D");
            XFBtnTnC.BackgroundColor = Color.FromHex("#2E2E2E");
            //XFBtnPP.BackgroundColor = Color.FromHex("#2E2E2E");
            var page = new AboutUsPage();
            MainView.Content = page.Content;
        }

        private void XFTnC_Click(object sender,EventArgs e)
        {
            XFBtnFAQ.BackgroundColor = Color.FromHex("#2E2E2E");
            XFBtnAboutUs.BackgroundColor = Color.FromHex("#2E2E2E");
            XFBtnTnC.BackgroundColor = Color.FromHex("#D0550D");
            //XFBtnPP.BackgroundColor = Color.FromHex("#2E2E2E");
            var page = new PrivacyPolicyAgreement();
            MainView.Content = page.Content;
        }

        //private void XFpp_Click(object sender, EventArgs e)
        //{
        //    XFBtnFAQ.BackgroundColor = Color.FromHex("#2E2E2E");
        //    XFBtnAboutUs.BackgroundColor = Color.FromHex("#2E2E2E");
        //    XFBtnTnC.BackgroundColor = Color.FromHex("#2E2E2E");
        //    XFBtnPP.BackgroundColor = Color.FromHex("#D0550D");
        //    var page = new PrivacyPolicy();
        //    MainView.Content = page.Content;
        //}

    }
}
