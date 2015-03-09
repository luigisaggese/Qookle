using QookleApp.Android;
using QookleApp.Views;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(LoginFacebookPage), typeof(LoginFacebookPageRenderer))]

namespace QookleApp.Android
{
    using System;

    using global::Android.App;

    using Xamarin.Auth;
    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// The login facebook page renderer.
    /// </summary>
    public class LoginFacebookPageRenderer : PageRenderer
    {
        private bool isShown;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginFacebookPageRenderer"/> class.
        /// </summary>
        public LoginFacebookPageRenderer()
        {
            RenderLoginPage();
        }

        private void RenderLoginPage()
        {
            if (!isShown)
            {
                isShown = true;

                var activity = this.Context as Activity;

                var auth = new OAuth2Authenticator(
                    clientId: App.OAuthSettings.ClientId, 

                    // your OAuth2 client id
                    scope: App.OAuthSettings.Scope, 

                    // the scopes for the particular API you're accessing, delimited by "+" symbols
                    authorizeUrl: App.OAuthSettings.AuthorizeUrl, 

                    // the auth URL for the service
                    redirectUrl: App.OAuthSettings.RedirectUrl); // the redirect URL for the service

                auth.Completed += (sender, eventArgs) =>
                    {
                        if (eventArgs.IsAuthenticated)
                        {
                            AccountStore.Create(this.Context).Save(eventArgs.Account, "Facebook");

                            var user = new FaceBookAccount();
                            var pictureUri = string.Empty;

                            var request = new OAuth2Request(
                                "GET", 
                                new Uri("https://graph.facebook.com/me"), 
                                null, 
                                eventArgs.Account);
                            request.GetResponseAsync().ContinueWith(
                                t =>
                                    {
                                        if (t.IsFaulted)
                                        {
                                            Console.WriteLine("Error: " + t.Exception.InnerException.Message);
                                        }
                                        else
                                        {
                                            var json = t.Result.GetResponseText();

                                            user = Newtonsoft.Json.JsonConvert.DeserializeObject<FaceBookAccount>(json);
                                        }
                                    }).Wait();
                            var requestPhoto = new OAuth2Request(
                                "GET", 
                                new Uri("https://graph.facebook.com/me/picture"), 
                                null, 
                                eventArgs.Account);
                            requestPhoto.GetResponseAsync().ContinueWith(
                                t =>
                                    {
                                        if (t.IsFaulted)
                                        {
                                            Console.WriteLine("Error: " + t.Exception.InnerException.Message);
                                        }
                                        else
                                        {
                                            var json = t.Result.GetResponseText();
                                            pictureUri = t.Result.ResponseUri.AbsoluteUri;
                                        }
                                    }).Wait();

                            App.SuccessfulLoginAction.Invoke(user.name, pictureUri);
                        }
                        else
                        {
                            App.CancelLoginAction.Invoke();
                        }
                    };

                var facebookUI = auth.GetUI(activity);

                activity.StartActivity(facebookUI);
            }
        }
    }
}