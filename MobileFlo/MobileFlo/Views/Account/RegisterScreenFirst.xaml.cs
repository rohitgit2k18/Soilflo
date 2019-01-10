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
    public partial class RegisterScreenFirst : ContentPage
    {
        #region variable declaration
        private RegisterMobileResponseModel registerMobileResponse;
        private RegisterMobileRequestModel registerMobileRequest;
        private string _baseUrl;
        private string _baseUrlSubmitRecord;
        private RestApi _apiServices;
        private HeaderModel _objHeaderModel;
        #endregion
        public RegisterScreenFirst()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            registerMobileRequest = new RegisterMobileRequestModel();
            registerMobileResponse = new RegisterMobileResponseModel();
            _apiServices = new RestApi();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Domain.Url + Domain.CreateDriverApiConstant;
            BindingContext = registerMobileRequest;
        }
        private async void XFLBLLogin_Tapped(object sender, TappedEventArgs e)
        {
            await App.NavigationPage.Navigation.PushAsync(new LoginPage());
        }

        private async void XFBtnRegister_Clicked(object sender, EventArgs e)
        {
            //if(!CrossConnectivity.Current.IsConnected)
            //{
            //    await DisplayAlert("Network Error", "Server not responding", "OK");
            //}
            //else
            //{
            if (string.IsNullOrEmpty(registerMobileRequest.cellphone))
            {
                await DisplayAlert("Alert", "Please insert mobile number", "OK");
            }
            else
            {
                try
                {
                    _objHeaderModel.TokenCode = Settings.TokenCode;
                    
                    registerMobileResponse = await _apiServices.MobileNumberAsync(new Get_API_Url().CreateMobileNumberApi(_baseUrl), true, _objHeaderModel, registerMobileRequest);
                    var result = registerMobileResponse;
                    if (result.status == "Success")
                    {
                        StaticHelper.CellPhone = registerMobileRequest.cellphone;
                        Settings.PhoneNo = registerMobileRequest.cellphone;
                        //await DisplayAlert("Message", "The driver has been successfully created", "OK");
                        await App.NavigationPage.Navigation.PushAsync(new RegisterScreenSecond());
                    }
                    if (result.status == "Duplicate")
                    {
                        await DisplayAlert("Message", "User already exists, please login", "OK");
                        await App.NavigationPage.Navigation.PushAsync(new LoginPage());
                    }
                    //else
                    //{
                    //    await DisplayAlert("Message", "Oops! An error occurred while creating a driver", "OK");
                    //}
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Alert", "You are not authorized", "OK");
                }

            }
        }
    }
}
//}