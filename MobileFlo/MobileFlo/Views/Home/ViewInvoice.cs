using System;

using Xamarin.Forms;

namespace MobileFlo.Views.Home
{
    public class ViewInvoice : ContentPage
    {
        public ViewInvoice()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

