using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QookleApp;
using QookleApp.WP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;

[assembly: ExportRenderer(typeof(GoogleAdsView), typeof(AdsPageRenderer))]
namespace QookleApp.WP.Renderers
{
    class AdsPageRenderer : PageRenderer
    {
        public AdsPageRenderer()
		{ 

			var banner = new AdView (this.Context){AdUnitId = "ca-app-pub-2065491276581929/1251486090"};
			AdRequest adRequest = new AdRequest.Builder().Build();
			AddView(banner);
			banner.LoadAd (adRequest);

            /*var bannerAd = new GoogleAds.AdView() { AdUnitID = "ca-app-pub-2065491276581929/2699696497", Format = GoogleAds.AdFormats.Banner };
            AdRequest adRequest = new AdRequest();
           
            Children.Add(bannerAd);
            bannerAd.LoadAd(adRequest);*/
        }
    }
}
