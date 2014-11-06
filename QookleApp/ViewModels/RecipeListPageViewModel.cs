using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
namespace QookleApp
{
	public class RecipeListPageViewModel:BaseViewModel
	{

		private bool IsLoading;
		private int currentPage=0;

		ObservableCollection<Recipe> recipesList = new ObservableCollection<Recipe>();
		public ObservableCollection<Recipe> RecipesList {
			get {
				return recipesList;
			}
			set {
				recipesList = value;
				OnPropertyChnaged ("RecipesList");
			}
		}
		public async void UploadNewItems(){
			if (!IsLoading) {

				getresult (itmz, currentPage);
				currentPage += 1;


			}
		}

					List<string> itmz = new List<string> ();
		public RecipeListPageViewModel (IEnumerable<string> selectedIngredients)
		{	
			itmz = selectedIngredients.ToList();
			getresult (selectedIngredients,currentPage);
		}

		public async void getresult(IEnumerable<string> selectedIngredients, int page){
			IsLoading = true;
			var recipesListfull = await ServiceHelper.GetRecipe (selectedIngredients, page);
			foreach (var item in recipesListfull.items) {
				RecipesList.Add (item);
			}
			IsLoading = false;
		}

	}
}

