using QookleApp.Views;
using QookleApp.WP.Renderers;

using Xamarin.Forms;

using Page = Xamarin.Forms.Page;

[assembly: ExportRenderer(typeof(LoginFacebookPage), typeof(LoginFacebookPageRenderer))]

namespace QookleApp.WP.Renderers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Navigation;
    using System.Windows.Threading;

    using GoogleAds;

    using Microsoft.Phone.Controls;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using QookleApp.Android;

    using Xamarin.Forms.Platform.WinPhone;

    /// <summary>
    /// The login facebook page renderer.
    /// </summary>
    public class LoginFacebookPageRenderer : PageRenderer
    {
        private readonly WebBrowser browser;

        private bool IsShown;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginFacebookPageRenderer"/> class.
        /// </summary>
        public LoginFacebookPageRenderer()
        {
            browser = new WebBrowser()
                          {
                              Name = "webBrowser1", 
                              HorizontalAlignment = HorizontalAlignment.Stretch, 
                              VerticalAlignment = VerticalAlignment.Stretch, 
                              Height = Application.Current.Host.Content.ActualHeight, 
                              Width = Application.Current.Host.Content.ActualWidth
                          };
            browser.ClearCookiesAsync();

            this.Children.Add(browser);
            browser.Navigated += BrowserNavigated;
            var url =
                new Uri(
                    "https://www.facebook.com/dialog/oauth?client_id=" + QookleApp.App.OAuthSettings.ClientId
                    + "&redirect_uri=https://www.facebook.com/connect/login_success.html&scope=email,user_location,friends_location,user_hometown,friends_hometown,publish_stream,offline_access,read_stream,user_status,user_photos,friends_photos,friends_status,user_checkins,friends_checkins,user_events,publish_checkins&display=wap");
            UIElement s = this.Children.FirstOrDefault(x => x.Visibility == Visibility.Visible);
            var ss = (WebBrowser)s;
            ss.Navigate(url);
            var bannerAd = new GoogleAds.AdView()
                               {
                                   AdUnitID = "ca-app-pub-2065491276581929/9025431693", 
                                   Format = GoogleAds.AdFormats.Banner
                               };
            var adRequest = new AdRequest();

            Children.Add(bannerAd);
            bannerAd.LoadAd(adRequest);
        }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        private void BrowserNavigated(object sender, NavigationEventArgs e)
        {
            if (e.Uri.IsAbsoluteUri)
            {
                var code = e.Uri.Query.ToString();
                var split = code.Split(new[] { '=' });
                var codeString = split.GetValue(0).ToString();
                var codeValue = split.GetValue(1).ToString();
                if (codeValue.Length > 0)
                {
                    var url = "https://graph.facebook.com/oauth/access_token?client_id="
                              + QookleApp.App.OAuthSettings.ClientId
                              + "&redirect_uri=https://www.facebook.com/connect/login_success.html&client_secret=2415f741628d20151a9a5c0caf2119ef&code="
                              + codeValue;

                    // call access token
                    var request = WebRequest.Create(url); // FB access token Link
                    request.BeginGetResponse(new AsyncCallback(this.ResponseCallback_AccessToken), request);
                }
            }
            else
            {
                return;
            }
        }

        private void ResponseCallback_AccessToken(IAsyncResult asynchronousResult)
        {
            try
            {
                var request = (HttpWebRequest)asynchronousResult.AsyncState;
                using (var resp = (HttpWebResponse)request.EndGetResponse(asynchronousResult))
                {
                    using (var streamResponse = resp.GetResponseStream())
                    {
                        using (var streamRead = new StreamReader(streamResponse))
                        {
                            var responseString = streamRead.ReadToEnd();
                            var splitAccessToken = responseString.Split(new[] { '=' });
                            var accessTokenString = splitAccessToken.GetValue(0).ToString();
                            var accessTokenValue = splitAccessToken.GetValue(1).ToString();
                            if (accessTokenString == "access_token")
                            {
                                AccessToken = accessTokenValue;
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
            }

            GetAccessToken();
        }

        private void GetAccessToken()
        {
            Deployment.Current.Dispatcher.BeginInvoke(
                () =>
                    {
                        if (string.IsNullOrEmpty(AccessToken))
                        {
                            // MessageBox.Show("AccessToken not valid");
                        }
                        else
                        {
                            // MessageBox.Show("AccessToken= " + AccessToken);
                            LoadUserProfile();
                        }
                    });
        }

        private void LoadUserProfile()
        {
            var urlProfile = "https://graph.facebook.com/me?fields=name,picture&access_token=" + AccessToken;

            // call access token
            var request = WebRequest.Create(urlProfile); // FB access token Link
            request.BeginGetResponse(new AsyncCallback(this.ResponseCallbackProfile), request);
        }

        private void ResponseCallbackProfile(IAsyncResult asynchronousResult)
        {
            try
            {
                var request = (HttpWebRequest)asynchronousResult.AsyncState;
                using (var resp = (HttpWebResponse)request.EndGetResponse(asynchronousResult))
                {
                    using (var streamResponse = resp.GetResponseStream())
                    {
                        streamResponse.Position = 0;
                        var sr = new StreamReader(streamResponse);
                        var myStr = sr.ReadToEnd();
                        var user = JsonConvert.DeserializeObject<FaceBookAccount>(myStr);
                        JObject s = user.picture;
                        var pictureUri =
                            ((Newtonsoft.Json.Linq.JObject)s.Properties().Last().Value).Properties()
                                .Last()
                                .Value.ToString();

                        Dispatcher.BeginInvoke(() => { QookleApp.App.SuccessfulLoginActionWP(user.name, pictureUri); });
                    }
                }
            }
            catch (WebException ex)
            {
            }
        }
    }
}