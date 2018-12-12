using System;
using System.Collections.Generic;
using MobileFlo.Models;
using MobileFlo.Services.ApiHandler;
using MobileFlo.Services.Models.ResponseModels;
using NotiFit.Helpers;
using Xamarin.Forms;

namespace MobileFlo.Views.Home
{
    public partial class ViewInvoice : ContentPage
    {
        #region variable declaration

        private InvoiceListResponseModel invoiceListResponseModel;
        private string _baseUrl;
        private RestApi _apiServices;

        #endregion
        public List<string> invoicelist = new List<string>();
        public ViewInvoice()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            invoiceListResponseModel = new InvoiceListResponseModel();
            _apiServices = new RestApi();
            _baseUrl = Domain.Url + Domain.GetInvoiceApiConstant;
            //invoicelist.Add("Rohit");
            //invoicelist.Add("Shrawan");
            //invoicelist.Add("AVinash");
            //invoicelist.Add("neha");
            //DataGridView.ItemsSource = invoicelist;
            GetInvoiceData();
        }

        private async void XFBackbtn_Tapped(object sender, TappedEventArgs e)
        {
            await App.NavigationPage.Navigation.PopAsync();
        }


        private async void GetInvoiceData()
        {
            try
            {
                invoiceListResponseModel = await _apiServices.GetAsyncData_GetApi(new Get_API_Url().GetInvoice(_baseUrl, Settings.PhoneNo),true,new Notifit.Services.Models.HeaderModel(), invoiceListResponseModel);
                if(invoiceListResponseModel.status == "Success")
                {
                    if(invoiceListResponseModel.GetInvoicesResult.Count > 0)
                    {
                        DataGridView.ItemsSource = invoiceListResponseModel.GetInvoicesResult;
                    }
                    else
                    {
                        await DisplayAlert("Alert", "No record found", "OK");
                    }

                }

            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", "An error occurred while getting the number of loads per days for this driver", "OK");
                var msg = ex.Message;
            }
        }

        public void GetInnerVoice_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedData = e.SelectedItem as GetInvoices;
            string SelectedDate = selectedData.Date;
            if(string.IsNullOrEmpty(SelectedDate))
            {
                DisplayAlert("Alert", "Please select the date", "OK");
            }
            else
            {
                App.NavigationPage.Navigation.PushAsync(new InvoiceInnerPage(SelectedDate));
            }
        }
    }
}
