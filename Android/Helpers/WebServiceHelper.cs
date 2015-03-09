using QookleApp.Android;

[assembly: Xamarin.Forms.Dependency(typeof(WebServiceHelper))]

namespace QookleApp.Android
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    using global::Android.App;

    using Newtonsoft.Json;

    /// <summary>
    /// The web service helper.
    /// </summary>
    public class WebServiceHelper : IService
    {
        /// <summary>
        /// The get screen dpi height.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetScreenDPIHeight()
        {
            return Application.Context.Resources.DisplayMetrics.Ydpi;
        }

        /// <summary>
        /// The get screen dpi width.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetScreenDPIWidth()
        {
            return Application.Context.Resources.DisplayMetrics.Xdpi;
        }

        /// <summary>
        /// The get screen width.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetScreenWidth()
        {
            return Application.Context.Resources.DisplayMetrics.WidthPixels;
        }

        /// <summary>
        /// The get screen height.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetScreenHeight()
        {
            return Application.Context.Resources.DisplayMetrics.HeightPixels;
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
            var dp = (int)(pixelValue / Application.Context.Resources.DisplayMetrics.Density);
            return dp;
        }

        #region IService implementation

        async Task<RecipeList> IService.GetRecipe(IEnumerable<string> parameters, int page)
        {
            try
            {
                var requestString = "https://qookle-com.appspot.com/_ah/api/qookle/v1/search?";
                requestString += "offset=" + page.ToString();

                foreach (var par in parameters)
                {
                    requestString += "&search=" + par;
                }

                Debug.WriteLine("url=" + requestString);
                var request = WebRequest.Create(requestString) as HttpWebRequest;
                request.Method = "POST";

                // url=https://qookle-com.appspot.com/_ah/api/qookle/v1/search?offset=0&search=pasta
                request.ContentType = "application/json";

                // request.
                request.ContentLength = 0;
                var jsonRes = string.Empty;

                var responce = await request.GetResponseAsync().ConfigureAwait(false);
                using (var reader = new StreamReader(responce.GetResponseStream()))
                {
                    jsonRes = reader.ReadToEnd();
                }

                Debug.WriteLine("SoeData=" + jsonRes);
                var res = JsonConvert.DeserializeObject<RecipeList>(jsonRes);

                return res;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SOOOOOOOOOSNNOOOLEY!!!!: " + ex.Message);
                return new RecipeList();
            }
        }

        #endregion
    }
}