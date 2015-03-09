namespace QookleApp
{
    using System;

    /// <summary>
    /// The recipe view page view model.
    /// </summary>
    public class RecipeViewPageViewModel : BaseViewModel
    {
        private readonly string webSiteAddress = "http://www.qookle.com/out?id={0}";

        private string id = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeViewPageViewModel"/> class.
        /// </summary>
        /// <param name="idd">
        /// The idd.
        /// </param>
        public RecipeViewPageViewModel(string idd)
        {
            ID = idd;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChnaged("ID");
            }
        }

        /// <summary>
        /// Gets the web address.
        /// </summary>
        public string WebAddress
        {
            get
            {
                return string.Format(webSiteAddress, id);
            }
        }
    }
}