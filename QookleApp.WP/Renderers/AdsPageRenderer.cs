using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QookleApp;
using QookleApp.WP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

//[assembly: ExportRenderer(typeof(GoogleAdsView), typeof(AdsPageRenderer))]
namespace QookleApp.WP.Renderers
{/*
    class AdsPageRenderer : ViewRenderer
    {
        public AdsPageRenderer()
        {
           
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            var bannerAd = new GoogleAds.AdView() { AdUnitID = "ca-app-pub-2065491276581929/3060806498", Format = GoogleAds.AdFormats.SmartBanner };
            AdRequest adRequest = new AdRequest();

            SetNativeControl(bannerAd);
            bannerAd.LoadAd(adRequest);
        }
    
    }*/
}
