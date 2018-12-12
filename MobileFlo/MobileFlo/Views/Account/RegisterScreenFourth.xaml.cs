using MobileFlo.Helpers;
using MobileFlo.Models;
using MobileFlo.Services.ApiHandler;
using MobileFlo.Services.Models.RequestModels;
using MobileFlo.Services.Models.ResponseModels;
using Notifit.Services.Models;
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
	public partial class RegisterScreenFourth : ContentPage
	{
        #region variable declare
        private CreateDriverEmailRequest createDriverEmailRequest;
        private CreateDriverEmailResponse createDriverEmailResponse;
        private string _baseUrl;
        private string _baseUrlSubmitRecord;
        private RestApi _apiServices;
        #endregion
        public RegisterScreenFourth ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            createDriverEmailRequest = new CreateDriverEmailRequest();
            createDriverEmailResponse = new CreateDriverEmailResponse();
            _apiServices = new RestApi();
            _baseUrl = Domain.Url + Domain.CreateDriverEmailApiConstant;
            BindingContext = createDriverEmailRequest;
        }

        private async void XFBtnSubmit_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Network Error", "Server not responding", "OK");
            }
            else
            {
                if (string.IsNullOrEmpty(createDriverEmailRequest.email))
                {
                    await DisplayAlert("Alert", "Please enter email address", "OK");
                }
                else
                {
                    try
                    {
                        createDriverEmailRequest.cellphone = StaticHelper.CellPhone;
                        createDriverEmailResponse = await _apiServices.CreateDriverEmailAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), createDriverEmailRequest);
                        var result = createDriverEmailResponse;
                        if (result != null)
                        {
                            await DisplayAlert("Success", "The driver's email address has been successfully created", "OK");
                            await App.NavigationPage.Navigation.PushAsync(new RegisterScreenThird());
                        }
                        else
                        {
                            await DisplayAlert("Message", "Server Error", "OK");
                        }
                    }
                    catch(Exception ex)
                    {
                        await DisplayAlert("Message", "You are not authorized", "OK");
                    }
                }
            }
        }
    }
}