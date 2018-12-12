using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileFlo.Views.Introduction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OnBoardingPage : CarouselPage
    {
		public OnBoardingPage ()
		{
            InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            //var images = new List<string>
            //{
            //    "onboarding_1.png",
            //    "onboarding_2.png",
            //    "onboarding_3.png"
            //};
            //MainCarouselView.ItemSource = images;
		}
	}


    //private void MainCarouselView_ItemSelected(object sender,SelectedItemChangedEventArgs e)
    //{
    //    MainLabel.Text = e.SelectedItem as string;
    //}
}