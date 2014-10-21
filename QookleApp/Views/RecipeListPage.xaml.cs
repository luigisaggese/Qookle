using System;
using System.Collections.Generic;
using Xamarin.Forms;

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

		public RecipeListPage ()
		{
			InitializeComponent ();
		}
	}
}

