using System;
using System.Collections.Generic;
using System.Collections;

namespace QookleApp
{
	public class RecipeListPageViewModel:BaseViewModel
	{



		IEnumerable<Recipe> recipesList = new List<Recipe>();
		public IEnumerable<Recipe> RecipesList {
			get {
				return recipesList;
			}
			set {
				recipesList = value;
				OnPropertyChnaged ("RecipesList");
			}
		}



		public RecipeListPageViewModel (IEnumerable<string> selectedIngredients)
		{
			getresult (selectedIngredients);
		}

		public async void getresult(IEnumerable<string> selectedIngredients){
			var recipesListfull = await ServiceHelper.GetRecipe (selectedIngredients);
			RecipesList = recipesListfull.items;
		}

	}
}

