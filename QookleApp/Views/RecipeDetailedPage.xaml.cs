namespace QookleApp.Views
{
    using Xamarin.Forms;

    /// <summary>
    /// The recipe detailed page.
    /// </summary>
    public partial class RecipeDetailedPage : ContentPage
    {
        private readonly Recipe _recipe;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeDetailedPage"/> class.
        /// </summary>
        /// <param name="recipe">
        /// The recipe.
        /// </param>
        public RecipeDetailedPage(Recipe recipe)
        {
            this.Title = recipe.title;

            _recipe = recipe;
            this.BindingContext = new DetailedRecipeViewModel(recipe);

            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => { Navigation.PushAsync(new RecipeViewPage(_recipe.id)); };

            PrepareButton.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}