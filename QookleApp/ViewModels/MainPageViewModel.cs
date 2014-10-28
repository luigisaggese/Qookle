using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
namespace QookleApp
{
	public class MainPageViewModel:BaseViewModel
	{
		private string _searchText="";
		public string TextToSearch 
		{
			get
			{
				return _searchText; 
			}
			set
			{
				_searchText = value;
				if (String.IsNullOrWhiteSpace (_searchText))
					SearchListOfIngredients = new ObservableCollection<string> ();
				else
					SearchListOfIngredients = new ObservableCollection<string>
						(IngredientsList.IngredientsFullList.Except(SelectedListOfIngredients).Where (x => x.ToLower().StartsWith(value.ToLower ())).Take(8));
				OnPropertyChnaged ("TextToSearch");
			}
		}

		ObservableCollection<string> _searchListOfIngredients = new ObservableCollection<string>();
		public ObservableCollection<string> SearchListOfIngredients 
		{
			get 
			{
				return _searchListOfIngredients;
			}
			set 
			{
				_searchListOfIngredients = value;
				OnPropertyChnaged ("SearchListOfIngredients");
			}
		}

		ObservableCollection<string> _selectedListOfIngredients = new ObservableCollection<string>();
		public ObservableCollection<string> SelectedListOfIngredients 
		{
			get 
			{
				return _selectedListOfIngredients;
			}
			set 
			{
				_selectedListOfIngredients = value;
				OnPropertyChnaged ("SelectedListOfIngredients");
			}
		}

		public void SelectNewIngredient(string ingredient)
		{
			SelectedListOfIngredients.Add (ingredient);
			SearchListOfIngredients.Remove (ingredient);

			TextToSearch = "";
			OnPropertyChnaged ("SelectedListOfIngredients");
		}

		public void RemoveIngredient(string ingredient)
		{
			SelectedListOfIngredients.Remove (ingredient);

			OnPropertyChnaged ("SelectedListOfIngredients");
		}


		public MainPageViewModel()
		{
			SaveCommand = new Command(OnSubmit);
		}

		public Action<IEnumerable<String>> SelectionCompletedAction{ get; set; }

		public void OnSubmit()
		{
			if (SelectionCompletedAction != null)
				SelectionCompletedAction (SelectedListOfIngredients);
		}

		public Command SaveCommand
		{
		    get;
		    internal set;
		}

		public Command TextChangedCommand
		{
			get;
			internal set;
		}


	}
}
