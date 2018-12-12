using MobileFlo.Services.Models.ResponseModels;
using MobileFlo.Views.Account;
using MobileFlo.Views.Home;
using MobileFlo.Views.Introduction;
using NotiFit.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileFlo
{
    public partial class App : Application
    {
        #region Variable Declaration
        public static INavigation Navigation;
        public static Page DetailPage;
        public static NavigationPage NavigationPage { get; set; }
        #endregion
        public App()
        {
            InitializeComponent();
            Xamarin.Forms.DataGrid.DataGridComponent.Init();

            //NavigationPage = new NavigationPage(new OnBoardingPage());
            //MainPage = NavigationPage;

            //Settings.TokenCode = "amlnYWRtaW46R3I4QXBsIw==";
            SetMainPage();
        }

        private void SetMainPage()
        {
            //throw new NotImplementedException();
            try
            {
                if(Settings.IsLoggedIn)
                {
                    if(string.IsNullOrEmpty(Settings.Status))
                    {
                        NavigationPage = new NavigationPage(new HomePage());
                        MainPage = NavigationPage;
                    }
                    if(Settings.Status=="FI")
                    {
                        NavigationPage = new NavigationPage(new FinishedScreen());
                        MainPage = NavigationPage;
                    }
                    if(Settings.Status=="WA"){
                        StarHaulingResponseModel startHaulingResponse = new StarHaulingResponseModel();
                        startHaulingResponse.LicensePlate = Settings.LicensePlate;
                        startHaulingResponse.ProjectName = Settings.ProjectName;
                        NavigationPage = new NavigationPage(new WaitingScreen(startHaulingResponse));
                        MainPage = NavigationPage;

                    }
                    if(Settings.Status=="HA" || Settings.Status =="AR" || Settings.Status == "RE"){
                        NavigationPage = new NavigationPage(new CurrentTrip());
                        MainPage = NavigationPage;
                    }


                }
                else
                {
                    NavigationPage = new NavigationPage(new LoginPage());
                    MainPage = NavigationPage;
                }
            }
            catch(Exception ex){
                var msg = ex.Message;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
