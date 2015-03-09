using QookleApp.WP;

[assembly: Xamarin.Forms.Dependency(typeof(WebServiceHelper))]

namespace QookleApp.WP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows;

    using Newtonsoft.Json;

    /// <summary>
    /// The web service helper.
    /// </summary>
    public class WebServiceHelper : IService
    {
        #region IService implementation

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceHelper"/> class.
        /// </summary>
        public WebServiceHelper()
        {
        }

        /// <summary>
        /// The get recipe.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<RecipeList> GetRecipe(IEnumerable<string> parameters, int page)
        {
            var requestString = "https://qookle-com.appspot.com/_ah/api/qookle/v1/search?";
            requestString += "offset=" + page;

            foreach (var par in parameters)
            {
                requestString += "&search=" + par;
            }

            string jsonRes;

            var webRequest = WebRequest.Create(requestString);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = 0;

            var webResponse = await webRequest.GetResponseAsync();

            using (var reader = new StreamReader(webResponse.GetResponseStream()))
            {
                jsonRes = reader.ReadToEnd();
            }

            var res = JsonConvert.DeserializeObject<RecipeList>(jsonRes);

            return res;
        }

        /// <summary>
        /// The get screen width.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetScreenWidth()
        {
            return Application.Current.Host.Content.ActualWidth;

            // throw new NotImplementedException();
        }

        /// <summary>
        /// The get screen height.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetScreenHeight()
        {
            return Application.Current.Host.Content.ActualHeight;

            // throw new NotImplementedException();
        }

        /// <summary>
        /// The get screen dpi height.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetScreenDPIHeight()
        {
            return 1000;

            // throw new NotImplementedException();
        }

        /// <summary>
        /// The get screen dpi width.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetScreenDPIWidth()
        {
            return 600;

            // throw new NotImplementedException();
        }

        /// <summary>
        /// The convert pixels to dp.
        /// </summary>
        /// <param name="pixelValue">
        /// The pixel value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int ConvertPixelsToDp(float pixelValue)
        {
            return (int)pixelValue;

            // throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// The extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// The get request stream async.
        /// </summary>
        /// <param name="wr">
        /// The wr.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public static Task<Stream> GetRequestStreamAsync(this WebRequest wr)
        {
            if (wr.ContentLength < 0)
            {
                throw new InvalidOperationException(
                    "The ContentLength property of the WebRequest must first be set to the length of the content to be written to the stream.");
            }

            return Task<Stream>.Factory.FromAsync(wr.BeginGetRequestStream, wr.EndGetRequestStream, null);
        }

        /// <summary>
        /// The get response async.
        /// </summary>
        /// <param name="wr">
        /// The wr.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static Task<WebResponse> GetResponseAsync(
            this WebRequest wr)
        {
            return Task<WebResponse>.Factory.FromAsync(wr.BeginGetResponse, wr.EndGetResponse, null);
        }
    }
}