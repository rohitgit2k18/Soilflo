using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileFlo.Views.Home
{
    public partial class PrivacyPolicyAgreement : ContentPage
    {
        public PrivacyPolicyAgreement()
        {
            InitializeComponent();
        }

        public async void PrivacyPolicyTapLink_Tapped(object sender, EventArgs e)
        {
            await App.NavigationPage.Navigation.PushAsync(new PrivacyPolicy());
        }
        public async void TermsConditionTapLink_Tapped(object sender, EventArgs e)
        {
            await App.NavigationPage.Navigation.PushAsync(new TermsnConditionPage());
        }
    }
}
