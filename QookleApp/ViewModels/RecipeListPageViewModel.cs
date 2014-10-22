using System;
using System.Collections.Generic;
using System.Collections;

namespace QookleApp
{
	public class RecipeListPageViewModel:BaseViewModel
	{



		IEnumerable<Recipe> recipesLis;
		public IEnumerable<Recipe> RecipesLis {
			get {
				return recipesLis;
			}
			set {
				recipesLis = value;
				OnPropertyChnaged ("RecipesLis");
			}
		}



		public RecipeListPageViewModel (IEnumerable<string> selectedIngredients)
		{
			getresult (selectedIngredients);
		}

		public async void getresult(IEnumerable<string> selectedIngredients){
			var recipesListfull = await ServiceHelper.GetRecipe (selectedIngredients);
			RecipesLis = recipesListfull.items;
		}

	}
}

