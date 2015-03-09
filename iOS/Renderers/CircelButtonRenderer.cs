using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Labs.Droid.Controls.CircleImage;
using QookleApp;
using QookleApp.Views.Controls;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(RoundedImage), typeof(CircleImageRenderer))]
namespace Xamarin.Forms.Labs.Droid.Controls.CircleImage
{
	public class CircleImageRenderer : ImageRenderer
	{
		//must have implementation
		public override void Draw (System.Drawing.RectangleF rect)
		{
		    try
		    {
		        var im = (RoundedImage) this.Element;
		        var imview = this.Control;
		        imview.ContentMode = MonoTouch.UIKit.UIViewContentMode.ScaleToFill;
		        imview.Layer.CornerRadius = imview.Layer.Frame.Height/2;
		    }
            catch(Exception )
		    {}
		}
	
	}
}


