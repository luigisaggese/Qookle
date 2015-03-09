using QookleApp.Views.Controls;

using Xamarin.Forms;
using Xamarin.Forms.Labs.Droid.Controls.CircleImage;

[assembly: ExportRenderer(typeof(RoundedImage), typeof(CircleImageRenderer))]

namespace Xamarin.Forms.Labs.Droid.Controls.CircleImage
{
    using System;
    using System.Drawing;

    using Xamarin.Forms.Platform.iOS;

    /// <summary>
    /// The circle image renderer.
    /// </summary>
    public class CircleImageRenderer : ImageRenderer
    {
        // must have implementation
        /// <summary>
        /// The draw.
        /// </summary>
        /// <param name="rect">
        /// The rect.
        /// </param>
        public override void Draw(RectangleF rect)
        {
            try
            {
                var im = (RoundedImage)this.Element;
                var imview = this.Control;
                imview.ContentMode = MonoTouch.UIKit.UIViewContentMode.ScaleAspectFill;
                imview.Layer.CornerRadius = imview.Layer.Frame.Height / 4;
            }
            catch (Exception)
            {
            }
        }
    }
}