using System;

namespace QookleApp
{
	public class OAuthSettings
	{
		public OAuthSettings(
			string clientId,
			string scope,
			Uri authorizeUrl,
			Uri redirectUrl)
		{
			ClientId = clientId;
			Scope = scope;
			AuthorizeUrl = authorizeUrl;
			RedirectUrl = redirectUrl;
		}

		public string ClientId {get; private set;}
		public string Scope {get; private set;}
		public Uri AuthorizeUrl {get; private set;}
		public Uri RedirectUrl {get; private set;}
	}
}

