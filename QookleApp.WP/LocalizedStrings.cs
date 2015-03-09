namespace QookleApp.WP
{
    using QookleApp.WP.Resources;

    /// <summary>
    ///     Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static readonly AppResources _localizedResources = new AppResources();

        /// <summary>
        /// Gets the localized resources.
        /// </summary>
        public AppResources LocalizedResources
        {
            get
            {
                return _localizedResources;
            }
        }
    }
}