using System;

namespace QookleApp
{
	public class RecipeViewPageViewModel:BaseViewModel
	{
		public RecipeViewPageViewModel (String idd)
		{
			ID=idd;
		}

		private string id="";
		private string webSiteAddress="http://www.qookle.com/out?id={0}";
		public string ID{ get{return id; } set{id=value;OnPropertyChnaged("ID"); }}
		public string WebAddress{ get{ return string.Format(webSiteAddress,id); }}

	}
}

