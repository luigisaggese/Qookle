namespace QookleApp.Views.Controls
{
    using Xamarin.Forms;

    /// <summary>
    /// The rounded image.
    /// </summary>
    public class RoundedImage : Image
    {
        private static BindableProperty _bindableProperty;

        private double _radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoundedImage"/> class.
        /// </summary>
        public RoundedImage()
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
                return _radius;
            }

            set
            {
                _radius = value;
                SetValue(RadiusProperty, value);
            }
        }

        /// <summary>
        /// Gets the radius property.
        /// </summary>
        public static BindableProperty RadiusProperty
        {
            get
            {
                return _bindableProperty
                       ?? (_bindableProperty = BindableProperty.Create<RoundedImage, double>(img => img.Radius, 0));
            }
        }
    }
}