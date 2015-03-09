namespace QookleApp.Views.Controls
{
    using Xamarin.Forms;

    /// <summary>
    /// The bordered image.
    /// </summary>
    public class BorderedImage : Image
    {
        public static readonly BindableProperty RadiusProperty =
            BindableProperty.Create<RoundedImage, double>(img => img.Radius, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="BorderedImage"/> class.
        /// </summary>
        public BorderedImage()
        {
            Radius = Height / 2;
        }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        public double Radius
        {
            get
            {
                return (double)GetValue(RadiusProperty);
            }

            set
            {
                SetValue(RadiusProperty, value);
            }
        }
    }
}