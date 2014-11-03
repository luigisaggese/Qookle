using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using QookleApp.Android;


[assembly: Xamarin.Forms.Dependency(typeof(WebServiceHelper))]
namespace QookleApp.Android
{
    public class WebServiceHelper :  IService
    {
        #region IService implementation

        public WebServiceHelper()
        {
        }

        async Task<RecipeList> IService.GetRecipe(IEnumerable<string> parameters)
        {
            String requestString = "https://qookle-com.appspot.com/_ah/api/qookle/v1/search?";
            requestString += "offset=0";

            foreach (var par in parameters)
            {
                requestString += "&search=" + par;
            }

            Debug.WriteLine("url=" + requestString);
            var request = WebRequest.Create(requestString) as HttpWebRequest;
            request.Method = "POST";
            //url=https://qookle-com.appspot.com/_ah/api/qookle/v1/search?offset=0&search=pasta
            request.ContentType = "application/json";
            //request.
            request.ContentLength = 0;
            String jsonRes = "";

            WebResponse responce = await request.GetResponseAsync().ConfigureAwait(false);
            using (var reader = new StreamReader(responce.GetResponseStream()))
            {
                jsonRes = reader.ReadToEnd();
            }
            Debug.WriteLine("SoeData=" + jsonRes);
            var res = JsonConvert.DeserializeObject<RecipeList>(jsonRes);

            return res;
        }

		#endregion

    }
}