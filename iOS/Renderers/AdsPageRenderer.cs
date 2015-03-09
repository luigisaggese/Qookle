using QookleApp.Views.Controls;
using QookleApp.WP.Renderers;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(GoogleAdsView), typeof(AdsPageRenderer))]

namespace QookleApp.WP.Renderers
{
    using GoogleAdMobAds;

    using MonoTouch.UIKit;

    using QookleApp.Views.Controls;

    using Xamarin.Forms.Platform.iOS;

    internal class AdsPageRenderer : ViewRenderer<GoogleAdsView, UIView>
    {
        private readonly GADBannerView adView;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdsPageRenderer"/> class.
        /// </summary>
        public AdsPageRenderer()
        {
            adView = new GADBannerView(size: GADAdSizeCons.LargeBanner)
                         {
                             AdUnitID =
                                 "ca-app-pub-2065491276581929/8606629296"
                         };

            // , origin: new PointF(0, 0))

            // var s = this;
            // this.BackgroundColor = MonoTouch.UIKit.UIColor.Blue;
            // this.Control.Add (adView);
            // this//Control.Add (adView);// = MonoTouch.UIKit.UIColor.Blue;
            adView.LoadRequest(GADRequest.Request);
            adView.BackgroundColor = Color.Aqua.ToUIColor();
        }

        /// <summary>
        /// The on element changed.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnElementChanged(ElementChangedEventArgs<GoogleAdsView> e)
        {
            base.OnElementChanged(e);
            this.SetNativeControl(adView);
        }
    }
}