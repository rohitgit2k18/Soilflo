using System;
using System.Collections.Generic;
using MobileFlo.Models;
using MobileFlo.Services.ApiHandler;
using MobileFlo.Services.Models.ResponseModels;
using NotiFit.Helpers;
using Xamarin.Forms;

namespace MobileFlo.Views.Home
{
    public partial class InvoiceInnerPage : ContentPage
    {
        public string selectedDate { get; set; }
        InnerVoiceResponseModel innerVoiceResponseModel;
        private string _baseUrl;
        private RestApi _apiServices;
        public InvoiceInnerPage(string SelectedDate)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            innerVoiceResponseModel = new InnerVoiceResponseModel();
            _apiServices = new RestApi();
            _baseUrl = Domain.Url + Domain.GetInnerVoiceApiConstant;
            selectedDate = SelectedDate;
            GetInnerVoice();
        }

         
        private async void XFBackbtn_Tapped(object sender, TappedEventArgs e)
        {
            await App.NavigationPage.Navigation.PopAsync();
        }

        private async void GetInnerVoice()
        {
            try
            {
                innerVoiceResponseModel = await _apiServices.GetAsyncData_GetApi(new Get_API_Url().GetInnerInvoice(_baseUrl,Settings.PhoneNo, selectedDate), true, new Notifit.Services.Models.HeaderModel(), innerVoiceResponseModel);
                if (innerVoiceResponseModel.status == "Success")
                {
                    if (innerVoiceResponseModel.GetDailyDeliveriesResult.Count > 0)
                    {
                        InnerVoiceList.ItemsSource = innerVoiceResponseModel.GetDailyDeliveriesResult;
                    }
                    else
                    {
                        await DisplayAlert("Alert", "No record found", "OK");
                    }

                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", "An error occurred while getting the deliveries for this driver", "OK");
                var msg = ex.Message;
            }
        }
    }
}
