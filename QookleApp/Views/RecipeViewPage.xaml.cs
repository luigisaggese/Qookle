using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QookleApp
{	
	public partial class RecipeViewPage : ContentPage, IViewModel<RecipeViewPageViewModel>
	{	
		#region IViewModel implementation


		public RecipeViewPageViewModel GetCurrentViewModel ()
		{
			return (RecipeViewPageViewModel)this.BindingContext;
		}


		public void SetViewModel (RecipeViewPageViewModel viewModel)
		{
			BindingContext = viewModel;
		}


		#endregion

		public RecipeViewPage ()
		{
			InitializeComponent ();
		}
	}
}

