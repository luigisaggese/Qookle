using System;
using System.Windows.Media;
using Xamarin.Forms;
using QookleApp;
using Xamarin.Forms.BorderedImage;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(BorderedImage), typeof(BorderedImageRenderer))]
namespace Xamarin.Forms.BorderedImage
{
    public class BorderedImageRenderer : ImageRenderer
    {
        
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        
            if (Control != null && Control.Clip == null)
            {
                var min = Math.Min(Element.Width, Element.Height) / 2.0f;
        
                if (min <= 0)
                    return;
        
                Control.Clip = new EllipseGeometry
                {
                    Center = new System.Windows.Point(min, min),
                    RadiusX = min,
                    RadiusY = min
                };
            }
        }
     
    }
}

