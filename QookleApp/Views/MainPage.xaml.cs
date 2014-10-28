using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace QookleApp
{	
	public partial class MainPage : ContentPage, IViewModel<MainPageViewModel>
	{
		#region IViewModel implementation

		MainPageViewModel ViewModel; 

		// This will be called whenever the list changes.
		private void SearchTapped(object sender, EventArgs e) 
		{
			ViewModel.SelectNewIngredient((sender as SearchedIngredientCellView).BindingContext as string);
			
			//Console.WriteLine("This is called when the event fires.");
		}

		private void SelectedTapped(object sender, EventArgs e) 
		{
			ViewModel.RemoveIngredient ((sender as SelectedIngredientCellView).BindingContext as string);
			//Console.WriteLine("This is called when the event fires.");
		}

		void ResetSelectedList()
		{
			SelectedIngredientsList.Children.Clear();
			foreach(var val in ViewModel.SelectedListOfIngredients)
			{
				var item = new SelectedIngredientCellView(this){ BindingContext = val };
				item.Changed+=SelectedTapped;
				SelectedIngredientsList.Children.Add (item);
			}
		}

		void ResetSearchedList()
		{
			SearchedIngredientsList.Children.Clear();
			foreach(var val in ViewModel.SearchListOfIngredients)
			{
				var item = new SearchedIngredientCellView(this){ BindingContext = val };
				item.Changed+=SearchTapped;
				SearchedIngredientsList.Children.Add (item);
			}
		}

		public MainPageViewModel GetCurrentViewModel ()
		{
			return (MainPageViewModel)this.BindingContext;
		}


		public void SetViewModel (MainPageViewModel viewModel)
		{
			BindingContext = viewModel;
		}

		#endregion

	
		public MainPage ()
		{
			InitializeComponent ();
			/*
			TextEntry.Focused += (sender, e) => {
				FacebookImage.HeightRequest = 0;
				HeaderImage.HeightRequest = 0;
			};
			TextEntry.Unfocused += (sender, e) => {
				FacebookImage.HeightRequest = 60;
				HeaderImage.HeightRequest = 120;
			};*/

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (s, e) => {
				if (ViewModel.SelectedListOfIngredients.Any ())
					ViewModel.OnSubmit();
				else
					DisplayAlert ("Ohhh", "Select something", "Ok");
			};

			QookButton.GestureRecognizers.Add (tapGestureRecognizer);

			ViewModel = new MainPageViewModel ();
			this.SetViewModel (ViewModel);

			GetCurrentViewModel ().SelectionCompletedAction = new Action<IEnumerable<string>> ((obj) => 
			{
				Navigation.PushAsync (new RecipeListPage (obj));
			});

			this.GetCurrentViewModel ().PropertyChanged += (sender, e) => 
			{
				if(e.PropertyName=="SearchListOfIngredients")
				{
					ResetSearchedList();
				}
				if(e.PropertyName=="SelectedListOfIngredients")
				{
					ResetSelectedList();
				}
			};
		}

	}
}