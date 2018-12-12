using MobileFlo.Models;
using MobileFlo.Services.ApiHandler;
using MobileFlo.Services.Models.RequestModels;
using MobileFlo.Services.Models.ResponseModels;
using MobileFlo.Views.Home;
using Notifit.Services.Models;
using NotiFit.Helpers;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileFlo.Views.Account
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        #region variable declaration
        private RegisterMobileResponseModel registerMobileResponse;
        private RegisterMobileRequestModel registerMobileRequest;
        private string _baseUrl;
        private string _baseUrlSubmitRecord;
        private RestApi _apiServices;
        #endregion
        public LoginPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            registerMobileRequest = new RegisterMobileRequestModel();
            registerMobileResponse = new RegisterMobileResponseModel();
            _apiServices = new RestApi();
            _baseUrl = Domain.Url + Domain.CreateDriverApiConstant;
            BindingContext = registerMobileRequest;
        }

        private void XFLBLRegister_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterScreenFirst());
        }

        private async void XFBtnLogin_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Network Error", "Server not responding", "OK");
            }
            else
            {
                if (string.IsNullOrEmpty(registerMobileRequest.cellphone))
                {
                    await DisplayAlert("Alert", "Please insert mobile number", "OK");
                }
                else
                {
                    try
                    {
                           //var otherPage = new HomePage();
                           //var homePage = App.NavigationPage.Navigation.NavigationStack.First();
                           //App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
                           //await App.NavigationPage.PopToRootAsync(false);
                        Settings.PhoneNo = XFMobileNumber.Text;
                        registerMobileResponse = await _apiServices.MobileNumberAsync(new Get_API_Url().CreateMobileNumberApi(_baseUrl), false, new HeaderModel(), registerMobileRequest);
                        var result = registerMobileResponse;
                        if (result.status == "Success")
                        {
                        await App.NavigationPage.Navigation.PushAsync(new LoginVerificationScreen());
                        }
                        else
                        {
                            await DisplayAlert("Message", "Oops! An error occurred while logging a driver", "OK");
                        }
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;
                        await DisplayAlert("Alert", "You are not authorized", "OK");
                    }
                }
            }           

        }
    }
}