namespace QookleApp
{
    using System;

    using QookleApp.Views;

    using Xamarin.Forms;

    /// <summary>
    /// The app.
    /// </summary>
    public class App : Application
    {
        private static MainPageView _mainPageView;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            // The root page of your application
            _mainPageView = new MainPageView();
            NavigationPage.SetHasNavigationBar(_mainPageView, false);
            MainPage = new NavigationPage(_mainPageView);

            // MainPageView = new ContentPage
            // {
            // Content = new StackLayout
            // {
            // VerticalOptions = LayoutOptions.Center,
            // Children = {
            // new Label {
            // XAlign = TextAlignment.Center,
            // Text = "Welcome to Xamarin Forms!"
            // }
            // }
            // }
            // };
        }

        /// <summary>
        /// Gets the o auth settings.
        /// </summary>
        public static OAuthSettings OAuthSettings
        {
            get
            {
                return new OAuthSettings(
                    clientId: "299030476966483", 

                    // your OAuth2 client id 
                    scope: string.Empty, 

                    // The scopes for the particular API you're accessing. The format for this will vary by API.
                    authorizeUrl:
                        new Uri(
                            "https://www.facebook.com/dialog/oauth?client_id=299030476966483&redirect_uri=https://www.facebook.com/connect/login_success.html"), 

                    // the auth URL for the service
                    redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));
            }
        }

        /// <summary>
        /// Gets the successful login action.
        /// </summary>
        public static Action<string, string> SuccessfulLoginAction
        {
            get
            {
                return new Action<string, string>(
                    (s, p) =>
                        {
                            _mainPageView.FacebookUserName = s;
                            _mainPageView.FacebookPictureUri = p;
                            _mainPageView.Navigation.PopAsync();
                        });
            }
        }

        /// <summary>
        /// Gets the successful login action wp.
        /// </summary>
        public static Action<string, string> SuccessfulLoginActionWP
        {
            get
            {
                return new Action<string, string>(
                    (s, p) =>
                        {
                            _mainPageView.FacebookUserName = s;
                            _mainPageView.FacebookPictureUri = p;
                            _mainPageView.Navigation.PopAsync();
                        });
            }
        }

        /// <summary>
        /// Gets the cancel login action.
        /// </summary>
        public static Action CancelLoginAction
        {
            get
            {
                return new Action(() => { _mainPageView.Navigation.PopAsync(); });
            }
        }

        /// <summary>
        /// The get main page.
        /// </summary>
        /// <returns>
        /// The <see cref="Page"/>.
        /// </returns>
        public static Page GetMainPage()
        {
            NavigationPage.SetHasNavigationBar(_mainPageView, false);
            return new NavigationPage(_mainPageView);
        }
    }
}