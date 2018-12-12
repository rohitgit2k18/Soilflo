using MobileFlo.Models;
using MobileFlo.Services.ApiHandler;
using MobileFlo.Services.Models.RequestModels;
using MobileFlo.Services.Models.ResponseModels;
using Notifit.Services.Models;
using NotiFit.Helpers;
using Plugin.Connectivity;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MobileFlo.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        #region variable declaration
        private StartHaulingRequestModel startHaulingRequestModel;
        private StarHaulingResponseModel startHaulingResponse;
        private string _baseUrl;
        private RestApi _apiServices;
        private string _baseUrl2;
        private SetStatusRequest setStatusRequest;
        private SetStatusResponse setStatusResponse;

        #endregion
        bool isCancelled = false;
        public HomePage ()
        {
            InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            loadimage();
            _apiServices = new RestApi();
            _baseUrl = Domain.Url + Domain.StartHauling;
            _baseUrl2 = Domain.Url + Domain.SetStatusApiConstant;
            startHaulingRequestModel = new StartHaulingRequestModel();
            startHaulingResponse = new StarHaulingResponseModel();
            //VerificationCode.Text = startHaulingRequest.scancode;
            //Settings.QRCode = startHaulingRequest.scancode;
            //startHaulingRequestModel.scancode = startHaulingRequest.scancode;
            setStatusRequest = new SetStatusRequest();
            setStatusResponse = new SetStatusResponse();
            GetPermission();
        }


        private async void GetPermission()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        //await DisplayAlert("Need location", "Please turn on GPS from the setting", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {

                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Alert", "Something went wrong to give the permission", "OK");
            }
        }

        private  void loadimage()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {                
                {
                    Device.BeginInvokeOnMainThread(async () => {
                                                            
                        if (isCancelled==true)
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

        private async void XFHauling_Click(object sender, EventArgs e)
        {
            try { 
                 var scan = new ZXingScannerPage();
                 await Navigation.PushAsync(scan);
                 scan.OnScanResult += (result) =>
                 {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                    await Navigation.PopAsync();
                        Settings.QRCode = result.Text;
                        if (Settings.QRCode != null)
                        {
                            GetProject();
                            //SetStatus();
                            //await App.NavigationPage.Navigation.PushAsync(new Home.AlphanumericCode(startHaulingRequest));
                        }
                    });
                 };
                             
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                await DisplayAlert("Alert", "Please try again !", "OK");
            }
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
                            Settings.Status = "WA";
                            //await DisplayAlert("Message", "Work is successfull", "OK");
                            await App.NavigationPage.Navigation.PushAsync(new Home.QRCodeSucessPage(startHaulingResponse));
                            //await App.NavigationPage.Navigation.PushAsync(new Home.QRCodeSucessPage(
                            //SetStatus();
                            //await App.NavigationPage.Navigation.PushAsync(new Home.WaitingScreen(result));
                            //await DisplayAlert("Success", "Successfull", "OK");
                        }
                        else
                        {
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
                        //await DisplayAlert("Message", "Work is successfull", "OK");
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

        private void XFViewInvoices_Click(object sender,EventArgs e)
        {
            try
            {
                App.NavigationPage.Navigation.PushAsync(new ViewInvoice());
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }
        private async void XFLblClickHere_Tapped(object sender, EventArgs e)
        {
            await App.NavigationPage.Navigation.PushAsync(new Home.AlphanumericCode());
        }

        private async void XFFaqClickHere_Tapped(object sender, EventArgs e)
        {
            await App.NavigationPage.Navigation.PushAsync(new FAQ());
        }
    }
}