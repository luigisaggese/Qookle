using QookleApp.Views.Controls;

using Xamarin.Forms.Labs.Droid.Controls.CircleImage;

[assembly: ExportRenderer(typeof(RoundedImage), typeof(CircleImageRenderer))]

namespace Xamarin.Forms.Labs.Droid.Controls.CircleImage
{
    using System;
    using System.ComponentModel;
    using System.Windows.Media;

    /// <summary>
    /// The circle image renderer.
    /// </summary>
    public class CircleImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CircleImageRenderer"/> class.
        /// </summary>
        public CircleImageRenderer()
        {
        }

        /// <summary>
        /// The on element changed.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
        }

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
            try
            {
                var monkey = SK.FromImageNamed("frame-1");
                monkey.Position = new PointF(this.RenderSize.Width / 2, this.RenderSize.Height / 2);
                this.Children.Add(monkey);

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
            catch (Exception)
            {
            }
        }
    }
}