namespace QookleApp.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using QookleApp.Views.Controls;

    using Xamarin.Forms;

    /// <summary>
    /// The recipe list page.
    /// </summary>
    public partial class RecipeListPage : ContentPage, IViewModel<RecipeListPageViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeListPage"/> class.
        /// </summary>
        /// <param name="selectedIngredients">
        /// The selected ingredients.
        /// </param>
        public RecipeListPage(IEnumerable<string> selectedIngredients)
        {
            InitializeComponent();
            this.SetViewModel(new RecipeListPageViewModel(selectedIngredients));

            this.Title = "Ricette";

            RecipeList1.OnScrolledToEnd = new Action(async () => { this.GetCurrentViewModel().UploadNewItems(); });
            RecipeList1.ItemTemplate = new DataTemplate(typeof(RecipeListViewCell));
            this.GetCurrentViewModel().PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == "RecipesList")
                    {
                        this.Title = "Ricette" + "(" + GetCurrentViewModel().RecipesList.Count + ")";

                        if (!GetCurrentViewModel().RecipesList.Any())
                        {
                            DisplayAlert("Ohhh(", "There is no recipes", "Ok");
                            Navigation.PopAsync();
                        }
                        else
                        {
                            // RAHIT!!
                        }
                    }
                };
        }

        #region IViewModel implementation

        /// <summary>
        /// The get current view model.
        /// </summary>
        /// <returns>
        /// The <see cref="RecipeListPageViewModel"/>.
        /// </returns>
        public RecipeListPageViewModel GetCurrentViewModel()
        {
            return (RecipeListPageViewModel)this.BindingContext;
        }

        /// <summary>
        /// The set view model.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        public void SetViewModel(RecipeListPageViewModel viewModel)
        {
            BindingContext = viewModel;
        }

        #endregion
    }
}