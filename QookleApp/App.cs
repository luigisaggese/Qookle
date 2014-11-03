using System;
using Xamarin.Forms;

namespace QookleApp
{
	public class App
	{
		public static OAuthSettings OAuthSettings { 
			get{ 
				return new OAuthSettings (
					clientId: "299030476966483",  		// your OAuth2 client id 
					scope: "",  		// The scopes for the particular API you're accessing. The format for this will vary by API.
					authorizeUrl: new Uri("https://www.facebook.com/dialog/oauth?client_id=299030476966483&redirect_uri=https://www.facebook.com/connect/login_success.html"),  	// the auth URL for the service
					redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));
			}
		}

		static MainPage _mainPage;
		public static Page GetMainPage ()
		{	
			_mainPage = new MainPage ();
			return new NavigationPage (_mainPage);
		}

		public static Action<string, string> SuccessfulLoginAction
		{
			get {
				return new Action<string,string> ((s,p) => {
                    
					_mainPage.FacebookUserName = s;
					_mainPage.FacebookPictureUri = p;
					_mainPage.Navigation.PopAsync ();
				});
			}
		}

        public static Action<string, string> SuccessfulLoginActionWP
        {
            get
            {
                return new Action<string, string>((s, p) =>
                {

                    _mainPage.FacebookUserName = s;
                    //_mainPage.FacebookPictureUri = p;
                    _mainPage.Navigation.PopAsync();
                });
            }
        }

		public static Action CancelLoginAction
		{
			get {
				return new Action (() => {
					_mainPage.Navigation.PopAsync();
				});
			}
		}

	}
}

