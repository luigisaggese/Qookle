using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections;
using System.Linq;

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
			RecipeList1.ItemTapped += (object sender, ItemTappedEventArgs e) => 
			{
				this.Navigation.PushAsync(new RecipeDetailedPage (((Recipe)e.Item)));
			};

			this.GetCurrentViewModel ().PropertyChanged += (sender, e) => 
			{
				if(e.PropertyName=="RecipesList")
				{
					if(!GetCurrentViewModel ().RecipesList.Any())
					{
						DisplayAlert ("Ohhh(", "There is no recipes", "Ok");
						Navigation.PopAsync();
					}
					else
					{
						RecipeList1.ItemTemplate = new DataTemplate (typeof(RecipeListViewCell));
					}
				}

			};


		}
	}
}

