using System;
using GoogleAdMobAds;
using Xamarin.Forms;
using QookleApp.iOS;


[assembly: Dependency(typeof(GoogleAdsAdder))]
namespace QookleApp.iOS
{
	public class GoogleAdsAdder:IGoogleAdsAdder
	{
		#region IGoogleAdsAdder implementation

		public object GetGoogleAds ()
		{
			var adView = new GADBannerView(size: GADAdSizeCons.Banner)
			{
				AdUnitID = "ca-app-pub-2065491276581929/8606629296"
			};

			adView.LoadRequest(GADRequest.Request);
			return adView;
		}

		#endregion

	}
}

