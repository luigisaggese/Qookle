namespace QookleApp
{
    using System;

    /// <summary>
    /// The o auth settings.
    /// </summary>
    public class OAuthSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthSettings"/> class.
        /// </summary>
        /// <param name="clientId">
        /// The client id.
        /// </param>
        /// <param name="scope">
        /// The scope.
        /// </param>
        /// <param name="authorizeUrl">
        /// The authorize url.
        /// </param>
        /// <param name="redirectUrl">
        /// The redirect url.
        /// </param>
        public OAuthSettings(string clientId, string scope, Uri authorizeUrl, Uri redirectUrl)
        {
            ClientId = clientId;
            Scope = scope;
            AuthorizeUrl = authorizeUrl;
            RedirectUrl = redirectUrl;
        }

        /// <summary>
        /// Gets the client id.
        /// </summary>
        public string ClientId { get; private set; }

        /// <summary>
        /// Gets the scope.
        /// </summary>
        public string Scope { get; private set; }

        /// <summary>
        /// Gets the authorize url.
        /// </summary>
        public Uri AuthorizeUrl { get; private set; }

        /// <summary>
        /// Gets the redirect url.
        /// </summary>
        public Uri RedirectUrl { get; private set; }
    }
}