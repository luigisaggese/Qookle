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
		private static int currentPage=0;

        ObservableCollection<object> recipesList = new ObservableCollection<object>();
		public ObservableCollection<object> RecipesList {
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
			    getresult (itmz, currentPage++);
				


			}
		}

		List<string> itmz = new List<string> ();
		public RecipeListPageViewModel (IEnumerable<string> selectedIngredients)
		{	
			itmz = selectedIngredients.ToList();
			getresult (selectedIngredients,currentPage++);
		}

		public async void getresult(IEnumerable<string> selectedIngredients, int page){
			IsLoading = true;
			var recipesListfull = await ServiceHelper.GetRecipe (selectedIngredients, page);

            if (RecipesList != null && RecipesList.Any())
            {
                RecipesList.Add("advertisement");
            }
			foreach (var item in recipesListfull.items) {
				RecipesList.Add (item);
			}
			IsLoading = false;
		}

	}
}

