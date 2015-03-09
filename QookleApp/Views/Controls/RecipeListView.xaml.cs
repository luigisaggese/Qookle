using System;
using Xamarin.Forms;

namespace QookleApp.Views.Controls
{
	public partial class RecipeListView : ContentView
	{
		public RecipeListView ()
		{
			InitializeComponent ();
            this.BindingContextChanged+=OnBindingContextChanged;
		}

	    private void OnBindingContextChanged(object sender, EventArgs eventArgs)
	    {
            if (this.BindingContext != null && this.BindingContext.GetType() != typeof(Recipe))
            {
                MainRecipeListElementGrid.IsVisible = false;
                MainAdvertisementGrid.IsVisible = true;
				MainAdvertisementGrid.Children.Add(new GoogleAdsView());
				//var sss = DependencyService.Get<IGoogleAdsAdder>().GetGoogleAds();
				//MainAdvertisementGrid.Children.Add(sss);
            }
	    }
	}

	public class RecipeListViewCell:ViewCell{


		public RecipeListViewCell(){
            
            this.View=new RecipeListView();

		}
	}
}

