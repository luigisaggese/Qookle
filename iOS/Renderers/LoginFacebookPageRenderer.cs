using QookleApp.iOS;
using QookleApp.Views;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(LoginFacebookPage), typeof(LoginFacebookPageRenderer))]

namespace QookleApp.iOS
{
    using System;

    using Xamarin.Auth;
    using Xamarin.Forms.Platform.iOS;

    /// <summary>
    /// The login facebook page renderer.
    /// </summary>
    public class LoginFacebookPageRenderer : PageRenderer
    {
        /// <summary>
        /// The view did appear.
        /// </summary>
        /// <param name="animated">
        /// The animated.
        /// </param>
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // I've used the values from your original post
            var auth = new OAuth2Authenticator(
                clientId: App.OAuthSettings.ClientId, 
                scope: App.OAuthSettings.Scope, 
                authorizeUrl: App.OAuthSettings.AuthorizeUrl, 
                redirectUrl: App.OAuthSettings.RedirectUrl);

            auth.Completed += (sender, eventArgs) =>
                {
                    if (eventArgs.IsAuthenticated)
                    {
                        AccountStore.Create().Save(eventArgs.Account, "Facebook");

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
                                        pictureUri = t.Result.ResponseUri.AbsolutePath;
                                    }
                                }).Wait();

                        App.SuccessfulLoginAction.Invoke(user.name, pictureUri);
                    }
                    else
                    {
                        App.CancelLoginAction.Invoke();
                    }
                };

            PresentViewController(auth.GetUI(), true, null);
        }
    }
}