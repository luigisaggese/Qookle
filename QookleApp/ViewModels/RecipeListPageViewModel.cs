namespace QookleApp
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// The recipe list page view model.
    /// </summary>
    public class RecipeListPageViewModel : BaseViewModel
    {
        private static int currentPage = 0;

        private static bool IsEndOfList = false;

        private readonly List<string> itmz = new List<string>();

        private bool IsLoading;

        private ObservableCollection<object> recipesList = new ObservableCollection<object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeListPageViewModel"/> class.
        /// </summary>
        /// <param name="selectedIngredients">
        /// The selected ingredients.
        /// </param>
        public RecipeListPageViewModel(IEnumerable<string> selectedIngredients)
        {
            currentPage = 0;
            itmz = selectedIngredients.ToList();
            getresult(selectedIngredients, currentPage++);
        }

        /// <summary>
        /// Gets or sets the recipes list.
        /// </summary>
        public ObservableCollection<object> RecipesList
        {
            get
            {
                return recipesList;
            }

            set
            {
                recipesList = value;
                OnPropertyChnaged("RecipesList");
            }
        }

        /// <summary>
        /// The upload new items.
        /// </summary>
        public async void UploadNewItems()
        {
            if (!IsLoading && !IsEndOfList)
            {
                getresult(itmz, currentPage++);
            }
        }

        /// <summary>
        /// The getresult.
        /// </summary>
        /// <param name="selectedIngredients">
        /// The selected ingredients.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        public async void getresult(IEnumerable<string> selectedIngredients, int page)
        {
            IsLoading = true;
            var recipesListfull = await ServiceHelper.GetRecipe(selectedIngredients, page);

            if (recipesListfull != null && recipesListfull.items != null && recipesListfull.items.Any())
            {
                foreach (var item in recipesListfull.items)
                {
                    RecipesList.Add(item);
                }

                RecipesList.Add("advertisement");
            }
            else
            {
                IsEndOfList = true;
            }

            OnPropertyChnaged("RecipesList");

            IsLoading = false;
        }
    }
}