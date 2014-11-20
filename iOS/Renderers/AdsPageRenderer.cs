using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QookleApp.WP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using GoogleAdMobAds;
using QookleApp;
using MonoTouch.UIKit;

[assembly: ExportRenderer(typeof(GoogleAdsView), typeof(AdsPageRenderer))]
namespace QookleApp.WP.Renderers
{
	class AdsPageRenderer : ViewRenderer<GoogleAdsView,UIView>
    {
        GADBannerView adView;

        public AdsPageRenderer()
        {
			adView = new GADBannerView(size: GADAdSizeCons.LargeBanner)//, origin: new PointF(0, 0))
			{
				AdUnitID = "ca-app-pub-2065491276581929/8606629296"
			};


			//var s = this;
			//this.BackgroundColor = MonoTouch.UIKit.UIColor.Blue;
			//this.Control.Add (adView);
			//this//Control.Add (adView);// = MonoTouch.UIKit.UIColor.Blue;

			adView.LoadRequest(GADRequest.Request);
			adView.BackgroundColor = Color.Aqua.ToUIColor();


        }
		protected override void OnElementChanged (ElementChangedEventArgs<GoogleAdsView> e)
		{
			base.OnElementChanged (e);
			base.SetNativeControl (adView);
		}

    }
}
