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
	public partial class RegisterScreenThird : ContentPage
	{
        #region Variable Declare
        private CreateDriverNameRequest createDriverNameRequest;
        private CreateDriverNameResponse createDriverNameResponse;
        private string _baseUrl;
        private string _baseUrlSubmitRecord;
        private RestApi _apiServices;
        #endregion
        public RegisterScreenThird ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            createDriverNameRequest = new CreateDriverNameRequest();
            createDriverNameResponse = new CreateDriverNameResponse();
            _apiServices = new RestApi();
            _baseUrl = Domain.Url + Domain.UpdateDriverNameApiConstant;
            BindingContext = createDriverNameRequest;
        }

        private async void XFBtnContinue_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Network Error", "Server not responding", "OK");
            }
            else
            {
                if (string.IsNullOrEmpty(createDriverNameRequest.firstname))
                {
                    await DisplayAlert("Alert", "Please enter first name", "OK");
                }
                else
                {
                    if(string.IsNullOrEmpty(createDriverNameRequest.lastname))
                    {
                        await DisplayAlert("Alert", "Please enter last name", "OK");
                    }
                    else
                    {
                        try
                        {
                            createDriverNameRequest.cellphone = Settings.PhoneNo;
                            createDriverNameResponse = await _apiServices.CreateDriverNameAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), createDriverNameRequest);
                            var result = createDriverNameResponse;
                            if (result != null)
                            {
                                await DisplayAlert("Message", "The driver's name has been successfully updated", "OK");
                                await App.NavigationPage.Navigation.PushAsync(new LoginPage());
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
    }
}