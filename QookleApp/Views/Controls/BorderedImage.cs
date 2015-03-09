using Xamarin.Forms;

namespace QookleApp.Views.Controls
{
	public class BorderedImage : Image
	{
		public static readonly BindableProperty RadiusProperty=BindableProperty.Create<RoundedImage,double>(img=>img.Radius,0);
		public double Radius{get{return (double)GetValue (RadiusProperty);}set{SetValue (RadiusProperty, value); }}

		public BorderedImage ()
		{
			Radius = Height / 2;
		}
	}
}

