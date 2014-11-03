using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QookleApp
{	
	public partial class RecipeDetailedPage : ContentPage
	{	
		Recipe _recipe;
		public RecipeDetailedPage (Recipe recipe)
		{
			_recipe = recipe;
			this.BindingContext = new DetailedRecipeViewModel(recipe);

			InitializeComponent ();

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (s, e) => {
				Navigation.PushAsync(new RecipeViewPage(_recipe.id));
			};

			PrepareButton.GestureRecognizers.Add (tapGestureRecognizer);
		}
	}
}

