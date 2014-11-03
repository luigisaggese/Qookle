using System;
using Xamarin.Forms;
namespace QookleApp
{
	public class RoundedImage:Image
	{
		public static readonly BindableProperty RadiusProperty=BindableProperty.Create<RoundedImage,double>(img=>img.Radius,0);
		public double Radius{get{return (double)GetValue (RadiusProperty);}set{SetValue (RadiusProperty, value); }}

		public RoundedImage ()
		{
			Radius = Height / 2;
		}
	}
}

