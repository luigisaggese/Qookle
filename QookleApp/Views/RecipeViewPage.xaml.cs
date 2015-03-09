namespace QookleApp.Views
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    /// The recipe view page.
    /// </summary>
    public partial class RecipeViewPage : ContentPage, IViewModel<RecipeViewPageViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeViewPage"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public RecipeViewPage(string id)
        {
            InitializeComponent();
            this.SetViewModel(new RecipeViewPageViewModel(id));

            if (string.IsNullOrWhiteSpace(id))
            {
                // message
            }
            else
            {
                ContentWebView.Source = GetCurrentViewModel().WebAddress;
            }
        }

        #region IViewModel implementation

        /// <summary>
        /// The get current view model.
        /// </summary>
        /// <returns>
        /// The <see cref="RecipeViewPageViewModel"/>.
        /// </returns>
        public RecipeViewPageViewModel GetCurrentViewModel()
        {
            return (RecipeViewPageViewModel)this.BindingContext;
        }

        /// <summary>
        /// The set view model.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        public void SetViewModel(RecipeViewPageViewModel viewModel)
        {
            BindingContext = viewModel;
        }

        #endregion
    }
}