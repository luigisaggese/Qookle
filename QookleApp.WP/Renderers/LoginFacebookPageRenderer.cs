using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using GoogleAds;
using Microsoft.Phone.Controls;
using Newtonsoft.Json;
using QookleApp;
using QookleApp.Android;
using QookleApp.WP.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using Page = Xamarin.Forms.Page;
using System.Windows.Threading;


[assembly: ExportRenderer(typeof(LoginFacebookPage), typeof(LoginFacebookPageRenderer))]

namespace QookleApp.WP.Renderers
{
    public class LoginFacebookPageRenderer : PageRenderer
    {

        private bool IsShown;

        private WebBrowser browser;
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
            Uri url =
                new Uri("https://www.facebook.com/dialog/oauth?client_id=" + QookleApp.App.OAuthSettings.ClientId +
                        "&redirect_uri=https://www.facebook.com/connect/login_success.html&scope=email,user_location,friends_location,user_hometown,friends_hometown,publish_stream,offline_access,read_stream,user_status,user_photos,friends_photos,friends_status,user_checkins,friends_checkins,user_events,publish_checkins&display=wap");
            UIElement s = this.Children.FirstOrDefault(x => x.Visibility == Visibility.Visible);
            var ss = ((WebBrowser) s);
            ss.Navigate(url);
            var bannerAd = new GoogleAds.AdView() { AdUnitID = "ca-app-pub-2065491276581929/9025431693", Format = GoogleAds.AdFormats.Banner };
            AdRequest adRequest = new AdRequest();

            Children.Add(bannerAd);
            bannerAd.LoadAd(adRequest);
        }



        private void BrowserNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.IsAbsoluteUri)
            {
                string code = e.Uri.Query.ToString();
                string[] split = code.Split(new Char[] {'='});
                string codeString = split.GetValue(0).ToString();
                string codeValue = split.GetValue(1).ToString();
                if (codeValue.Length > 0)
                {
                    var url = "https://graph.facebook.com/oauth/access_token?client_id=" +
                              QookleApp.App.OAuthSettings.ClientId +
                              "&redirect_uri=https://www.facebook.com/connect/login_success.html&client_secret=2415f741628d20151a9a5c0caf2119ef&code=" +
                              codeValue;

                    //call access token
                    WebRequest request = WebRequest.Create(url); //FB access token Link
                    request.BeginGetResponse(new AsyncCallback(this.ResponseCallback_AccessToken), request);
                }
            }
            else
                return;
        }


        private void ResponseCallback_AccessToken(IAsyncResult asynchronousResult)
        {
            try
            {
                var request = (HttpWebRequest) asynchronousResult.AsyncState;
                using (var resp = (HttpWebResponse) request.EndGetResponse(asynchronousResult))
                {
                    using (var streamResponse = resp.GetResponseStream())
                    {
                        using (var streamRead = new StreamReader(streamResponse))
                        {
                            string responseString = streamRead.ReadToEnd();
                            string[] splitAccessToken = responseString.Split(new Char[] {'='});
                            string accessTokenString = splitAccessToken.GetValue(0).ToString();
                            string accessTokenValue = splitAccessToken.GetValue(1).ToString();
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

        public string AccessToken { get; set; }


        private void GetAccessToken()
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (string.IsNullOrEmpty(AccessToken))
                {
                    //MessageBox.Show("AccessToken not valid");
                }
                else
                {
                    //MessageBox.Show("AccessToken= " + AccessToken);
                    LoadUserProfile();
                }
            });
        }

        private void LoadUserProfile()
        {
            var urlProfile = "https://graph.facebook.com/me?fields=name,picture&access_token=" + AccessToken;
            //call access token
            WebRequest request = WebRequest.Create(urlProfile); //FB access token Link
            request.BeginGetResponse(new AsyncCallback(this.ResponseCallbackProfile), request);
        }

        private void ResponseCallbackProfile(IAsyncResult asynchronousResult)
        {
            try
            {
                var request = (HttpWebRequest) asynchronousResult.AsyncState;
                using (var resp = (HttpWebResponse) request.EndGetResponse(asynchronousResult))
                {
                    using (var streamResponse = resp.GetResponseStream())
                    {
                        streamResponse.Position = 0;
                        StreamReader sr = new StreamReader(streamResponse);
                        string myStr = sr.ReadToEnd();
                        var user = JsonConvert.DeserializeObject<FaceBookAccount>(myStr);
                        Newtonsoft.Json.Linq.JObject s = user.picture;
                        var pictureUri =
                            ((Newtonsoft.Json.Linq.JObject) s.Properties().Last().Value).Properties()
                                .Last()
                                .Value.ToString();
                        
                        Dispatcher.BeginInvoke(() =>
                        {
                            QookleApp.App.SuccessfulLoginActionWP(user.name, pictureUri);
                        });


                    }
                }
            }
            catch (WebException ex)
            {

            }
            
        }


    }
}

