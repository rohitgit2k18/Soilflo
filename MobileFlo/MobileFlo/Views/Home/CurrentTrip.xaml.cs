using System;
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
using Xamarin.Forms;
using System.Device;
using System.Device.Location;

namespace MobileFlo.Views.Home
{
    public partial class CurrentTrip : ContentPage
    {
        #region variable declaration
        private SetStatusRequest setStatusRequest;
        private SetStatusResponse setStatusResponse;
        private GetLoadInfoResponseModel getLoadInfoResponse;
        private SetPositionRequestModel setPositionRequest;
        private SetPositionResponseModel setPositionResponse;
        private StarHaulingResponseModel startHaulingResponse;
        private GetStatusResponseModel getStatusResponse;
        private GetStatusRequestModel getStatusRequest;
        private string _baseUrl;
        private string _baseUrl2;
        private RestApi _apiServices;
        private string dest;
        private double DestinationLat;
        private string destlon ;
        private double DestinationLon;
        private string currentLat;
        private double CurrentLat;
        private string currentLon;
        private double CurrentLon;
        private double SourceLat;
        private string sourcelat;
        private double SourceLon;
        private string sourcelon;


        #endregion
        public CurrentTrip()
        {
            InitializeComponent();
            _apiServices = new RestApi();
            _baseUrl = Domain.Url + Domain.SetCurrentPositionApiConstant;
            _baseUrl2 = Domain.Url + Domain.SetStatusApiConstant;
            setStatusRequest = new SetStatusRequest();
            setStatusResponse = new SetStatusResponse();
            getLoadInfoResponse = new GetLoadInfoResponseModel();
            setPositionRequest = new SetPositionRequestModel();
            setPositionResponse = new SetPositionResponseModel();
            startHaulingResponse = new StarHaulingResponseModel();
            getStatusResponse = new GetStatusResponseModel();
            getStatusRequest = new GetStatusRequestModel();
            XFLabelCurrentTrip.Text = "STATUS - HAULING";
            XFDestinationLbl.Text = Settings.AddressName;
            //GetLoadInfo();
            SetPositionReady();
            GetStatusReady();

        }
        public void GetStatusReady()
        {
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                if (Settings.Status == "HA")
                {
                    Device.BeginInvokeOnMainThread(GetStatus);
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
                        Settings.Status = getStatusResponse.statusCode;
                        //await DisplayAlert("Message", "Status-Finished", "OK");
                        await App.NavigationPage.Navigation.PushAsync(new FinishedScreen());
                    }
                  
                    if (getStatusResponse.statusCode == "WA")
                    {
                        Settings.Status = "WA";
                        XFActIndicatorLoader.IsVisible = false;
                        Settings.Status = getStatusResponse.statusCode;
                        StarHaulingResponseModel starHaulingResponse = new StarHaulingResponseModel();
                        starHaulingResponse.ProjectName = Settings.ProjectName;
                        starHaulingResponse.LicensePlate = Settings.LicensePlate;
                        await App.NavigationPage.Navigation.PushAsync(new WaitingScreen(starHaulingResponse));
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
                await DisplayAlert("Error", "Server not responding,Please try again", "Ok");
            }
        }

        public void SetPositionReady()
        {

            Device.StartTimer(TimeSpan.FromMinutes(1), () =>
            {
                if (Settings.Status == "HA")
                {

                    Device.BeginInvokeOnMainThread(SetPosition);
                    return true;
                }
                else
                {
                    //Device.BeginInvokeOnMainThread(SetPosition);
                    return false;
                }
            });
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
                if (setPositionResponse.status == "Success")
                {
                    XFActIndicatorLoader.IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                XFActIndicatorLoader.IsVisible = false;
                //await DisplayAlert("Alert", "Unable to get location,may need to increase timeout:" + ex, "OK");
                //await DisplayAlert("Permission", "Please turn your GPS on", "OK");
                await App.NavigationPage.Navigation.PopAsync();

            }
            //try
            //{
            //    var locator = CrossGeolocator.Current;
            //    locator.DesiredAccuracy = 50;
            //    var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
            //    setPositionRequest.lat = position.Latitude;
            //    Settings.CurrentLat = position.Latitude.ToString();
            //    setPositionRequest.lon = position.Longitude;
            //    Settings.CurrentLon = position.Longitude.ToString();
            //    setPositionRequest.scancode = Settings.QRCode;
            //    setPositionResponse = await _apiServices.SetPositionAsync(new Get_API_Url().SetCurrentPosition(_baseUrl), false, new HeaderModel(), setPositionRequest);

            //    dest = Settings.CurrentLat;
            //    DestinationLat = Convert.ToDouble(dest);
            //    destlon = Settings.CurrentLon;
            //    DestinationLon = Convert.ToDouble(destlon);
            //    currentLat = Settings.CurrentLat;
            //    CurrentLat = Convert.ToDouble(currentLat);
            //    currentLon = Settings.CurrentLon;
            //    CurrentLon = Convert.ToDouble(currentLon);
            //    sourcelat = Settings.SourceLat;
            //    SourceLat = Convert.ToDouble(sourcelat);
            //    sourcelon = Settings.SourceLon;
            //    SourceLon = Convert.ToDouble(sourcelon);

            //    GeoCoordinate pin1 = new GeoCoordinate(CurrentLat, CurrentLon);
            //    GeoCoordinate pin2 = new GeoCoordinate(DestinationLat, DestinationLon);
            //    double GeofenceRegionDestination = pin1.GetDistanceTo(pin2);


            //    GeoCoordinate pin3 = new GeoCoordinate(CurrentLat, CurrentLon);
            //    GeoCoordinate pin4 = new GeoCoordinate(SourceLat, SourceLon);
            //    double GeofenceRegionSource = pin3.GetDistanceTo(pin4);



            //    if (GeofenceRegionDestination < 250)
            //    {
            //        setStatusRequest.scancode = Settings.QRCode;
            //        setStatusRequest.status = "AR";
            //        Settings.Status = "AR";
            //        XFActIndicatorLoader.IsVisible = true;
            //        setStatusResponse = await _apiServices.SetStatusAsync(new Get_API_Url().CommonBaseApi(_baseUrl2), false, new HeaderModel(), setStatusRequest);
            //        if (setStatusResponse.status == "Success")
            //        {
            //            XFActIndicatorLoader.IsVisible = false;
            //            await DisplayAlert("Message", "Truck has enter Geofence Destination", "OK");
            //            //Settings.Status = setStatusResponse.status;
            //            XFLabelCurrentTrip.Text = "STATUS - ARRIVED";

            //        }
            //        if (setStatusResponse.status == "Error")
            //        {
            //            XFActIndicatorLoader.IsVisible = false;
            //            await DisplayAlert("Message", "No current ticket is found", "OK");

            //        }
            //    }
            //    if(Settings.Status == "AR")
            //    {
            //        if(GeofenceRegionDestination > 250)
            //        {
            //            setStatusRequest.scancode = Settings.QRCode;
            //            setStatusRequest.status = "RE";
            //            Settings.Status = "RE";
            //            XFActIndicatorLoader.IsVisible = true;
            //            setStatusResponse = await _apiServices.SetStatusAsync(new Get_API_Url().CommonBaseApi(_baseUrl2), false, new HeaderModel(), setStatusRequest);
            //            if (setStatusResponse.status == "Success")
            //            {
            //                XFActIndicatorLoader.IsVisible = false;
            //                await DisplayAlert("Message", "Truck has left Destination site geofence", "OK");
            //                //Settings.Status = setStatusResponse.status;
            //                XFLabelCurrentTrip.Text = "STATUS - RETURNING";

            //            }
            //            if(setStatusResponse.status == "Error")
            //            {
            //                XFActIndicatorLoader.IsVisible = false;
            //                await DisplayAlert("Message", "No current ticket is found", "OK");
            //                await App.NavigationPage.Navigation.PushAsync(new Home.HomePage());
            //            }
            //       }
            //    }
            //    if(Settings.Status == "RE")
            //    {
            //        if(GeofenceRegionSource < 250)
            //        {
            //            setStatusRequest.scancode = Settings.QRCode;
            //            setStatusRequest.status = "WA";
            //            Settings.Status ="WA";
            //            XFActIndicatorLoader.IsVisible = true;
            //            setStatusResponse = await _apiServices.SetStatusAsync(new Get_API_Url().CommonBaseApi(_baseUrl2), false, new HeaderModel(), setStatusRequest);
            //            if (setStatusResponse.status == "Success")
            //            {
            //                XFActIndicatorLoader.IsVisible = false;
            //                await DisplayAlert("Message", "Truck has enter source site geofence", "OK");
            //                //Settings.Status = setStatusResponse.status;
            //                startHaulingResponse.ProjectName = Settings.ProjectName;
            //                startHaulingResponse.LicensePlate = Settings.LicensePlate;
            //                await App.NavigationPage.Navigation.PushAsync(new WaitingScreen(startHaulingResponse));

            //            }
            //            if (setStatusResponse.status == "Error")
            //            {
            //                XFActIndicatorLoader.IsVisible = false;
            //                await DisplayAlert("Message", "No current ticket is found", "OK");
            //                await App.NavigationPage.Navigation.PushAsync(new Home.HomePage());
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XFActIndicatorLoader.IsVisible = false;
            //    await DisplayAlert("Alert", "Server not responding", "OK");
            //    //await App.NavigationPage.Navigation.PopAsync();
            //    //await DisplayAlert("Alert", "Unable to get location,may need to increase timeout:" + ex, "OK");

            //}

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
                        XFDestinationLbl.Text = getLoadInfoResponse.DisposalSiteName + getLoadInfoResponse.City + getLoadInfoResponse.Street + getLoadInfoResponse.Province;
                        Settings.AddressName = getLoadInfoResponse.DisposalSiteName + getLoadInfoResponse.City + getLoadInfoResponse.Street + getLoadInfoResponse.Province;
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

        private async void XFLoadInformation_Click(object sender, EventArgs e)
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
                        await App.NavigationPage.Navigation.PushAsync(new LoadInformation(getLoadInfoResponse));
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

        private void OpenMap_Clicked(object sender,EventArgs e)
        {
            string address = Settings.AddressName;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Device.OpenUri(new Uri("http://maps.apple.com/maps?saddr="+Settings.CurrentLat+","+Settings.CurrentLon+"&daddr="+Settings.DestLat+","+Settings.DestLon+"&dirflg=d"));
                    break;
                case Device.Android:
                    Device.OpenUri(new Uri("http://maps.google.com/?saddr="+Settings.CurrentLat+","+Settings.CurrentLon+"&daddr="+Settings.DestLat+","+Settings.DestLon+ "&directionsmode=driving"));
                    break;                
                default:
                    break;
            }
        }

    }
}
