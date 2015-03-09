using System;
using QookleApp.Views;
using Xamarin.Forms;

namespace QookleApp
{
    public class App : Application
	{
        public App()
        {
            // The root page of your application
            _mainPageView = new MainPageView();
            NavigationPage.SetHasNavigationBar(_mainPageView, false);
            MainPage = new NavigationPage(_mainPageView);
            //MainPageView = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                XAlign = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};
        }


		public static OAuthSettings OAuthSettings { 
			get{ 
				return new OAuthSettings (
					clientId: "299030476966483",  		// your OAuth2 client id 
					scope: "",  		// The scopes for the particular API you're accessing. The format for this will vary by API.
					authorizeUrl: new Uri("https://www.facebook.com/dialog/oauth?client_id=299030476966483&redirect_uri=https://www.facebook.com/connect/login_success.html"),  	// the auth URL for the service
					redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));
			}
		}

		static MainPageView _mainPageView;
		public static Page GetMainPage ()
		{	
			NavigationPage.SetHasNavigationBar(_mainPageView, false);
			return new NavigationPage(_mainPageView);
		}

		public static Action<string, string> SuccessfulLoginAction
		{
			get {
				return new Action<string,string> ((s,p) => {
                    
                    _mainPageView.FacebookUserName = s;
                    _mainPageView.FacebookPictureUri = p;
					_mainPageView.Navigation.PopAsync ();
				});
			}
		}

        public static Action<string, string> SuccessfulLoginActionWP
        {
            get
            {
                return new Action<string, string>((s, p) =>
                {

                    _mainPageView.FacebookUserName = s;
                    _mainPageView.FacebookPictureUri = p;
                    _mainPageView.Navigation.PopAsync();
                });
            }
        }

		public static Action CancelLoginAction
		{
			get {
				return new Action (() => {
					_mainPageView.Navigation.PopAsync();
				});
			}
		}

	}
}

