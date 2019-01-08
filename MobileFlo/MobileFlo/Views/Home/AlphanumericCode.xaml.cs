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

namespace MobileFlo.Views.Home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlphanumericCode : ContentPage
	{
        #region variable declaration
        private StartHaulingRequestModel startHaulingRequestModel;
        private StarHaulingResponseModel startHaulingResponse;
        private string _baseUrl;
        private RestApi _apiServices;
        private string _baseUrl2;
        private SetStatusRequest setStatusRequest;
        private SetStatusResponse setStatusResponse;
        //private string qrCode;

        #endregion
        public AlphanumericCode()
        {
            InitializeComponent();
            _apiServices = new RestApi();
            _baseUrl = Domain.Url + Domain.StartHauling;
            _baseUrl2 = Domain.Url + Domain.SetStatusApiConstant;
            startHaulingRequestModel = new StartHaulingRequestModel();
            startHaulingResponse = new StarHaulingResponseModel();
            //ewqrCode = QRCode;
            //VerificationCode.Text = startHaulingRequest.scancode;
            //Settings.QRCode = startHaulingRequest.scancode;
            //startHaulingRequestModel.scancode = startHaulingRequest.scancode;
            setStatusRequest = new SetStatusRequest();
            setStatusResponse = new SetStatusResponse();

        }

        private async void GetProject()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Network Error", "Server not responding", "OK");
            }
            else
            {
                startHaulingRequestModel.scancode = Settings.QRCode;
                if (string.IsNullOrEmpty(startHaulingRequestModel.scancode))
                {
                    await DisplayAlert("Alert", "Please resend the code", "OK");
                }
                else
                {
                    try
                    {
                        string abc = Settings.PhoneNo;
                        startHaulingRequestModel.cellphone = abc;
                        startHaulingResponse = await _apiServices.getProjectAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), startHaulingRequestModel);
                        var result = startHaulingResponse;
                        if (result.status == "Success")
                        {
                            //SetStatus();
                            Settings.Status = "WA";
                            //await DisplayAlert("Message", "Status is waiting", "OK");
                            await App.NavigationPage.Navigation.PushAsync(new Home.QRCodeSucessPage(startHaulingResponse));
                            //await App.NavigationPage.Navigation.PushAsync(new Home.WaitingScreen(result));
                            //await DisplayAlert("Success", "Successfull", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Alert", "Daily Truck List is not found", "OK");
                            await App.NavigationPage.Navigation.PushAsync(new FailureScreen());
                            //await DisplayAlert("Error", "Oops! An error occurred while assigning a driver to a Daily Truck List", "OK");
                        }
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Message", "You are not Authorized", "OK");
                    }
                }
            }
        }

        private async void SetStatus()
        {
            setStatusRequest.scancode = Settings.QRCode;
            setStatusRequest.status = "WA";
            try
            {
                if (string.IsNullOrEmpty(setStatusRequest.scancode))
                {
                    await DisplayAlert("Alert", "Something wrong!", "OK");
                }
                else
                {
                    setStatusResponse = await _apiServices.SetStatusAsync(new Get_API_Url().CommonBaseApi(_baseUrl2), false, new HeaderModel(), setStatusRequest);
                    if (setStatusResponse.status == "Success")
                    {
                        Settings.Status = setStatusRequest.status;
                        //await DisplayAlert("Message", "Status is waiting", "OK");
                        await App.NavigationPage.Navigation.PushAsync(new Home.QRCodeSucessPage(startHaulingResponse));
                    }
                    if (setStatusResponse.status == "Error")
                    {
                        await DisplayAlert("Message", "No current ticket is found", "OK");
                        await App.NavigationPage.Navigation.PushAsync(new FailureScreen());
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Message", "You are not Authorized", "OK");
            }
        }


        private async void XFBtnContinue_Clicked(object sender, EventArgs e)
        {
            string UserQRcode = VerificationCode.Text;
            if(!string.IsNullOrEmpty(UserQRcode))
            {
                Settings.QRCode = UserQRcode;
                GetProject();
            }
            //await App.NavigationPage.Navigation.PushAsync(new Home.WaitingScreen(startHaulingResponse));
        }
    }
}