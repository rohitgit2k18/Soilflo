using MobileFlo.Helpers;
using MobileFlo.Models;
using MobileFlo.Services.ApiHandler;
using MobileFlo.Services.Models.RequestModels;
using MobileFlo.Services.Models.ResponseModels;
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
	public partial class RegisterScreenSecond : ContentPage
	{
        #region Variable Declare
        private CodeVerificationRequestModel codeVerificationRequest;
        private CodeVerificationResponseModel codeVerificationResponse;
        private string _baseUrl;
        //private string _baseUrlSubmitRecord;
        private RestApi _apiServices;
        #endregion
        public RegisterScreenSecond ()
		{
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            codeVerificationRequest = new CodeVerificationRequestModel();
            codeVerificationResponse = new CodeVerificationResponseModel();
            _apiServices = new RestApi();
            _baseUrl = Domain.Url + Domain.CodeValidateApiConstant;
            BindingContext = codeVerificationRequest;
            XFLabelTxt1.Text = "Enter the 4 digit code sent to you at "+ Settings.PhoneNo;
        }

        private async void XFBtnContinue_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Network Error", "Server not responding", "OK");
            }
            else
            {
                if (string.IsNullOrEmpty(codeVerificationRequest.code))
                {
                    await DisplayAlert("Alert", "Please enter Verification Code.", "OK");
                }
                else
                {
                    try
                    {
                        codeVerificationRequest.cellphone = StaticHelper.CellPhone;
                        codeVerificationResponse = await _apiServices.ValidateCodeAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), codeVerificationRequest);
                        var result = codeVerificationResponse;
                        if (result.status == "Success")
                        {
                            await DisplayAlert("Message", "The driver has been successfully created", "OK");
                            await App.NavigationPage.Navigation.PushAsync(new RegisterScreenThird());
                        }
                        else if(result.status=="Invalid")
                        {
                            await DisplayAlert("Message", "Code is not valid.", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Message", "Server Error", "OK");
                        }
                    }
                    catch(Exception ex)
                    {
                        await DisplayAlert("Message", "You are not Authorized", "OK");
                    }
                }
            }
        }

        private async void XFBtnResend_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Network Error", "Server not responding", "OK");
            }
            else
            {
                try
                {
                    codeVerificationRequest.cellphone = StaticHelper.CellPhone;
                    codeVerificationResponse = await _apiServices.ResendCodeAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), codeVerificationRequest);
                    var result = codeVerificationResponse;
                    if (result != null)
                    {
                        await DisplayAlert("Success", "The validation code request has been resent", "OK");
                        //await Navigation.PushAsync(new RegisterScreenThird());
                    }
                    else
                    {
                        await DisplayAlert("Message", "Server Error", "OK");
                    }
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Message", "You are not Authorized", "OK");
                }
            }
        }
    }
}