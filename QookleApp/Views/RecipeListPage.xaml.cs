using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections;

namespace QookleApp
{	
	public partial class RecipeListPage : ContentPage, IViewModel<RecipeListPageViewModel>
	{	
		#region IViewModel implementation



		public RecipeListPageViewModel GetCurrentViewModel ()
		{
			return (RecipeListPageViewModel)this.BindingContext;
		}


		public void SetViewModel (RecipeListPageViewModel viewModel)
		{
			BindingContext = viewModel;
		}


		#endregion

		public RecipeListPage (IEnumerable<string> selectedIngredients)
		{
			InitializeComponent ();
			this.SetViewModel (new RecipeListPageViewModel (selectedIngredients));
		}
	}
}

