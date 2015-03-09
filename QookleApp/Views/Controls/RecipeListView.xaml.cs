namespace QookleApp.Views.Controls
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    /// The recipe list view.
    /// </summary>
    public partial class RecipeListView : ContentView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeListView"/> class.
        /// </summary>
        public RecipeListView()
        {
            InitializeComponent();
            this.BindingContextChanged += OnBindingContextChanged;
        }

        private void OnBindingContextChanged(object sender, EventArgs eventArgs)
        {
            if (this.BindingContext != null && this.BindingContext.GetType() != typeof(Recipe))
            {
                MainRecipeListElementGrid.IsVisible = false;
                MainAdvertisementGrid.IsVisible = true;
                MainAdvertisementGrid.Children.Add(new GoogleAdsView());

                // var sss = DependencyService.Get<IGoogleAdsAdder>().GetGoogleAds();
                // MainAdvertisementGrid.Children.Add(sss);
            }
        }
    }

    /// <summary>
    /// The recipe list view cell.
    /// </summary>
    public class RecipeListViewCell : ViewCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeListViewCell"/> class.
        /// </summary>
        public RecipeListViewCell()
        {
            this.View = new RecipeListView();
        }
    }
}