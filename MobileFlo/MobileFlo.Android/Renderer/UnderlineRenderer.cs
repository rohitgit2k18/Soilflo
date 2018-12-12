using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileFlo;
using MobileFlo.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(UnderlineLabel), typeof(UnderlineRenderer))]
namespace MobileFlo.Droid.Renderer
{
    public class UnderlineRenderer : LabelRenderer
    {
        public UnderlineRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                Control.PaintFlags = PaintFlags.UnderlineText;
                Control.SetTextColor(Android.Graphics.Color.Rgb(2, 38, 72));
            }

        }
    }
}