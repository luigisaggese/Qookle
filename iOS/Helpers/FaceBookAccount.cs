using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using MonoTouch.Foundation;
using MonoTouch.Accounts;
using MonoTouch.Foundation;
using Newtonsoft.Json;
using Xamarin.Forms;
using QookleApp.iOS;
[assembly: Dependency(typeof(FacebookLogIn))]
namespace QookleApp.iOS
{
	public class FaceBookAccount
	{
		public string name {
			get;
			set;
		}

		public FaceBookAccount ()
		{

		}
	}

	public class FacebookLogIn:IFb{
		#region IFb implementation
		ACAccountStore accountStore = new ACAccountStore ();
		public FacebookLogIn()
		{

		}
		String Name="";
		public async System.Threading.Tasks.Task<bool> Authorize ()
		{
			string oAuthFBKey = "";


			var accountType = accountStore.FindAccountType (ACAccountType.Facebook);

			var a = new AccountStoreOptions ();
			a.FacebookAppId = "299030476966483";
			if (await accountStore.RequestAccessAsync (accountType, a)) {
				if (accountStore.FindAccounts (accountType).Count () == 0) {

					return false;
				}
				ACAccount facebookAccount = accountStore.FindAccounts (accountType).First ();
				Name = facebookAccount.UserFullName;
				oAuthFBKey = facebookAccount.Credential.OAuthToken;

				Debug.WriteLine ("begin");
				Debug.WriteLine (oAuthFBKey);
				Debug.WriteLine ("end");
				return true;
			} else {
				return false;
			}
		}

		public string GetName ()
		{
			return Name;
		}

		#endregion


	}
}

