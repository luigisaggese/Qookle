using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using QookleApp.WP;


[assembly: Xamarin.Forms.Dependency(typeof(WebServiceHelper))]
namespace QookleApp.WP
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

            string jsonRes;

            WebRequest webRequest = WebRequest.Create(requestString);
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

        
		#endregion

    }

    public static class Extensions
    {
        public static System.Threading.Tasks.Task<System.IO.Stream> GetRequestStreamAsync(this System.Net.WebRequest wr)
        {
            if (wr.ContentLength < 0)
            {
                throw new InvalidOperationException("The ContentLength property of the WebRequest must first be set to the length of the content to be written to the stream.");
            }

            return Task<System.IO.Stream>.Factory.FromAsync(wr.BeginGetRequestStream, wr.EndGetRequestStream, null);
        }

        public static System.Threading.Tasks.Task<System.Net.WebResponse> GetResponseAsync(this System.Net.WebRequest wr)
        {
            return Task<System.Net.WebResponse>.Factory.FromAsync(wr.BeginGetResponse, wr.EndGetResponse, null);
        }
    }
}