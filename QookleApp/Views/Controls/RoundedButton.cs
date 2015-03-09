using Xamarin.Forms;

namespace QookleApp.Views.Controls
{
    public class RoundedImage : Image
    {
        private double _radius;
        private static BindableProperty _bindableProperty;

        public double Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                SetValue(RadiusProperty, value);
            }
        }   

        public static BindableProperty RadiusProperty
        {
            get
            {
                return _bindableProperty ?? (_bindableProperty = BindableProperty.Create<RoundedImage, double>(img => img.Radius, 0));
            }
        }

        public RoundedImage()
        {
            Radius = Height/2;
        }
    }
}

