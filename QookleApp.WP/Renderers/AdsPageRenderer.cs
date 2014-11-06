using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleAds;
using QookleApp.Views;
using QookleApp.WP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(AdsPage), typeof(AdsPageRenderer))]
namespace QookleApp.WP.Renderers
{
    class AdsPageRenderer : PageRenderer
    {
        public AdsPageRenderer()
        {
            var bannerAd = new GoogleAds.AdView() { AdUnitID = "ca-app-pub-2065491276581929/9025431693", Format = GoogleAds.AdFormats.Banner };
            AdRequest adRequest = new AdRequest();
           
            Children.Add(bannerAd);
            bannerAd.LoadAd(adRequest);
        }
    }
}
