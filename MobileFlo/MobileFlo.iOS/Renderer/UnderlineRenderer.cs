using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MobileFlo;
using MobileFlo.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(UnderlineLabel), typeof(UnderlineRenderer))]
namespace MobileFlo.iOS.Renderer
{
    public class UnderlineRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                if (e.NewElement != null)
                {
                    var label = (UnderlineLabel)this.Element;
                    this.Control.AttributedText = new NSAttributedString(label.Text, underlineStyle: NSUnderlineStyle.Single);
                    Control.TextColor = UIColor.FromRGB(2, 38, 72);
                }
            }

        }
    }
}