using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using MobileFlo.Models;
using MobileFlo.Services.ApiHandler;
using MobileFlo.Services.Models.RequestModels;
using MobileFlo.Services.Models.ResponseModels;
using Newtonsoft.Json;
using Notifit.Services.Models;
using NotiFit.Helpers;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace MobileFlo.Views.Home
{
    public partial class WaitingScreen : ContentPage
    {
        #region variable declaration
        private string _baseUrl;
        //private string _baseUrl2;
        private RestApi _apiServices;
        private GetStatusResponseModel getStatusResponse;
        private GetStatusRequestModel getStatusRequest;
        private SetPositionRequestModel setPositionRequest;
        private SetPositionResponseModel setPositionResponse;
        private GetLoadInfoResponseModel getLoadInfoResponse;
        #endregion
        public WaitingScreen(StarHaulingResponseModel startHaulingResponse)
        {
            InitializeComponent();
            _apiServices = new RestApi();
            _baseUrl = Domain.Url + Domain.SetCurrentPositionApiConstant;
            getStatusResponse = new GetStatusResponseModel();
            getStatusRequest = new GetStatusRequestModel();
            setPositionRequest = new SetPositionRequestModel();
            setPositionResponse = new SetPositionResponseModel();
            getLoadInfoResponse = new GetLoadInfoResponseModel();
            Settings.LicensePlate = startHaulingResponse.LicensePlate;
            Settings.ProjectName = startHaulingResponse.ProjectName;
            this.BindingContext = startHaulingResponse;
            GetPermission();
            GetLoadInfo();
            GetStatusReady();
            SetPositionReady();
            //GetPermission();
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
                        ImageTick.Source = "cross.png";
                        //await DisplayAlert("Need location", "Please turn on GPS", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    ImageTick.Source = "tick.png";
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

        public void GetStatusReady()
        {
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                if (Settings.Status == "WA")
                {
                    Device.BeginInvokeOnMainThread(GetStatus);
                    return true;
                }

                return false;
            });
        }

        public void SetPositionReady()
        {
            Device.StartTimer(TimeSpan.FromSeconds(20), () =>
            {
                if (Settings.Status == "WA")
                {
                    Device.BeginInvokeOnMainThread(GetPermissions);
                    return true;
                }
                
                return false;
            });
        }
        private async void GetStatus()
        {
            try
            {
                XFActIndicatorLoader.IsVisible = true;
                getStatusRequest.scancode = Settings.QRCode;
                HttpResponseMessage response = null;
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                                                      "Basic",
                                                      Convert.ToBase64String(
                                                      System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                      string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync("http://api.staging.soilflo.com/hauler/GetStatus/" + getStatusRequest.scancode).Result;

                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    getStatusResponse = JsonConvert.DeserializeObject<GetStatusResponseModel>(SucessResponse);
                    if (getStatusResponse.statusCode == "FI")
                    {
                        Settings.Status = "FI";
                        XFActIndicatorLoader.IsVisible = false;
                        //Settings.Status = getStatusResponse.statusCode;
                        //await DisplayAlert("Message", "Status-Finished", "OK");
                        await App.NavigationPage.Navigation.PushAsync(new FinishedScreen());
                    }
                    if (getStatusResponse.statusCode == "HA")
                    {
                        Settings.Status = "HA";
                        XFActIndicatorLoader.IsVisible = false;
                        //Settings.Status = getStatusResponse.statusCode;
                        //await DisplayAlert("Message", "Status-Hauling", "OK");
                        await App.NavigationPage.Navigation.PushAsync(new CurrentTrip());
                    }
                    if (getStatusResponse.statusCode == "WA")
                    {
                        XFActIndicatorLoader.IsVisible = false;
                        Settings.Status = getStatusResponse.statusCode;
                        //await App.NavigationPage.Navigation.PushAsync(new CurrentTrip());
                        //await DisplayAlert("Message", "Status-Waiting", "OK");
                    }

                }
                else
                {
                    XFActIndicatorLoader.IsVisible = false;
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Status Failed", "The Daily Truck List is not found", "Ok");

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                await DisplayAlert("Error", "Server Error", "Ok");
            }
        }

        public void ViewInvoice_Clicked(object sender, System.EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new ViewInvoice());
        }

        private async void GetPermissions(){
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        //await DisplayAlert("Need location", "Please turn on GPS", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    //var locator = CrossGeolocator.Current;
                    //locator.DesiredAccuracy = 50;
                    ////var position = await locator.GetPositionAsync(TimeSpan.FromTicks(10000), null, false);
                    //var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                    // var results = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                    //LabelGeolocation.Text = "Lat: " + results.Latitude + " Long: " + results.Longitude;
                    SetPosition();
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {

                //LabelGeolocation.Text = "Error: " + ex;
            }
        }
        private async void SetPosition()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                //var position = await locator.GetPositionAsync(TimeSpan.FromTicks(10000), null, false);
                var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                setPositionRequest.lat = position.Latitude;
                setPositionRequest.lon = position.Longitude;
                Settings.SourceLat = position.Latitude.ToString();
                Settings.SourceLon = position.Longitude.ToString();
                Settings.CurrentLat = position.Latitude.ToString();
                Settings.CurrentLon = position.Longitude.ToString();
                setPositionRequest.scancode = Settings.QRCode;
                XFActIndicatorLoader.IsVisible = true;
                setPositionResponse = await _apiServices.SetPositionAsync(new Get_API_Url().SetCurrentPosition(_baseUrl), false, new HeaderModel(), setPositionRequest);
                if(setPositionResponse.status == "Success")
                {
                    XFActIndicatorLoader.IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                XFActIndicatorLoader.IsVisible = false;
                //await DisplayAlert("Alert", "Unable to get location,may need to increase timeout:" + ex, "OK");
                //await DisplayAlert("Alert", "Please turn on the GPS", "OK");
                await App.NavigationPage.Navigation.PopAsync();

            }

        }

        private async void GetLoadInfo()
        {
            try
            {
                XFActIndicatorLoader.IsVisible = true;
                HttpResponseMessage response = null;
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                                                      "Basic",
                                                      Convert.ToBase64String(
                                                      System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                      string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync("http://api.staging.soilflo.com/hauler/GetDelivery/" + Settings.QRCode).Result;

                if (response.IsSuccessStatusCode)
                {

                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    getLoadInfoResponse = JsonConvert.DeserializeObject<GetLoadInfoResponseModel>(SucessResponse);
                    if (getLoadInfoResponse.status == "Success")
                    {
                        XFActIndicatorLoader.IsVisible = false;
                        Settings.DestLon = getLoadInfoResponse.Lon;
                        Settings.DestLat = getLoadInfoResponse.Lat;
                        Settings.AddressName = getLoadInfoResponse.DisposalSiteName+","+getLoadInfoResponse.City+","+getLoadInfoResponse.Street+","+getLoadInfoResponse.Province;
                    }
                }
                else
                {
                    XFActIndicatorLoader.IsVisible = false;
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Status Failed", "The Ticket Delivery details are not found", "Ok");
                }
            }
            catch (Exception ex)
            {
                XFActIndicatorLoader.IsVisible = false;
                var msg = ex.Message;
                await DisplayAlert("Error", "Server Error", "Ok");
            }
        }

        private async void XFFaqClickHere_Tapped(object sender, EventArgs e)
        {
            await App.NavigationPage.Navigation.PushAsync(new FAQ());
        }

    }
}
