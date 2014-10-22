using System;
using QookleApp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;


[assembly: Dependency (typeof(WebServiceHelper))]
namespace QookleApp.Android
{
	public class WebServiceHelper:IService
	{
		#region IService implementation

		public async Task<IEnumerable<Recipe>> GetRecipe (IEnumerable<string> parameters,int offsetValue)
		{
			try {
			    Debug.WriteLine ("Starting request.");

				var requestString = "https://qookle-com.appspot.com/_ah/api/qookle/v1/search?";
				requestString+="offset="+offsetValue;

				foreach(var par in parameters){
					requestString+="&search="+par;
				}

			    var request = WebRequest.Create (requestString) as HttpWebRequest;
			    request.Method = "POST";
			    request.ContentType = "application/json";

				String jsonRes = "";

			    WebResponse responce = await request.GetResponseAsync ().ConfigureAwait (false);
			    using (var reader = new StreamReader (responce.GetResponseStream ())) {
			     jsonRes = reader.ReadToEnd ();
			     Debug.WriteLine (reader.ReadToEnd ());
			    }
				var res = JsonConvert.DeserializeObject<IEnumerable<Recipe>> (jsonRes);

			    return res;
			   } catch (Exception ex) {
			    return null;
			}
		}

		#endregion

		public WebServiceHelper ()
		{
		}
	}
}