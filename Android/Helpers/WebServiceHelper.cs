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

		public async System.Threading.Tasks.Task<IEnumerable<Recipe>> GetRecipe ()
		{
			try {
			    Debug.WriteLine ("NA4alo");
			    var request =
			     WebRequest.Create ("https://qookle-com.appspot.com/_ah/api/qookle/v1/search?offset=0&search=pasta") as
			                        HttpWebRequest;//ja she dodam parametru v metod v interfejsi sho+b prujmalo list stringiv, jaki mu peredaemo v rikvest.+ ale n
			    request.Method = "POST";
			    request.ContentType = "application/json";
				// chekaj. ale ja tak i ne poniav sho ce za offset ))))
				//tipa paging 
				//offset 0 1-10 items
				//ofste 1 11-20 items poniav. ok // tu vze dodomy hochesh?
				//ta da
				//ale tam pizda // ja ba4y))))

				//nakudaj she shos na views. a ja ce dorobly i bydemo valutu dodomy, ja tebe zaberu tam bilja togo sport, jaksho ho4esh
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