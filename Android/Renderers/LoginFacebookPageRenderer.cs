using System; 
using Android.App;
//using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using QookleApp.Android;


namespace QookleApp.Android
{
	/*
	[assembly: ExportRenderer (typeof (LoginFacebookPage), typeof (LoginFacebookPageRenderer))]
	public class LoginFacebookPageRenderer : PageRenderer
	{
		protected override void OnDraw (VisualElement oldModel, VisualElement newModel)
		{
			base.OnDraw (oldModel, newModel);
			// this is a ViewGroup - so should be able to load an AXML file and FindView<>
			var activity = this.Context as Activity;
			var auth = new OAuth2Authenticator (
			clientId: "", // your OAuth2 client id
			scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
			authorizeUrl: new Uri (""), // the auth URL for the service
			redirectUrl: new Uri ("")); // the redirect URL for the service

			auth.Completed += (sender, eventArgs) => {
				if (eventArgs.IsAuthenticated) {
					App.SuccessfulLoginAction.Invoke();
					// Use eventArgs.Account to do wonderful things
					App.SaveToken(eventArgs.Account.Properties["access_token"]);
				} else {
					// The user cancelled
				}
			};

			activity.StartActivity (auth.GetUI(activity));
		}
	}
*/
}

