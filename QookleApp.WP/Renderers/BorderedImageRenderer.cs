using QookleApp.Views.Controls;

using Xamarin.Forms;
using Xamarin.Forms.BorderedImage;

[assembly: ExportRenderer(typeof(BorderedImage), typeof(BorderedImageRenderer))]

namespace Xamarin.Forms.BorderedImage
{
    using System;
    using System.ComponentModel;
    using System.Windows.Media;

    using Xamarin.Forms.Platform.WinPhone;

    /// <summary>
    /// The bordered image renderer.
    /// </summary>
    public class BorderedImageRenderer : ImageRenderer
    {
        /// <summary>
        /// The on element property changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnElementPropertyChanged(
            object sender, 
            PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null && Control.Clip == null)
            {
                var min = Math.Min(Element.Width, Element.Height) / 2.0f;

                if (min <= 0)
                {
                    return;
                }

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