using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QookleApp.Views;
using QookleApp.WP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using GoogleAdMobAds;

[assembly: ExportRenderer(typeof(AdsPage), typeof(AdsPageRenderer))]
namespace QookleApp.WP.Renderers
{
    class AdsPageRenderer : PageRenderer
    {
        GADBannerView adView;

        public AdsPageRenderer()
        {
            adView = new GADBannerView(size: GADAdSizeCons.Banner, origin: new PointF(0, 0))
            {
                AdUnitID = "ca-app-pub-2065491276581929/8606629296",
                RootViewController = this
            };

            adView.DidReceiveAd += (sender, args) => View.AddSubview(adView);

            adView.LoadRequest(GADRequest.Request);
        }
    }
}
