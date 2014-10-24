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

		private string searchText="";
		public string TextToSearch {
			get{return searchText; }
			set{searchText = value;
				if (String.IsNullOrWhiteSpace (searchText))
					SearchListOfIngredients = new ObservableCollection<string> ();
				else
					SearchListOfIngredients = new ObservableCollection<string> (IngredientsList.IngredientsFullList.Where (x => x.ToLower ().Contains (value.ToLower ())));
				OnPropertyChnaged ("TextToSearch");}
		}

		ObservableCollection<string> searchListOfIngredients = new ObservableCollection<string>();
		public ObservableCollection<string> SearchListOfIngredients {
			get {
				return searchListOfIngredients;
			}
			set {
				searchListOfIngredients = value;
				OnPropertyChnaged ("SearchListOfIngredients");
			}
		}

		ObservableCollection<string> selectedListOfIngredients;
		public ObservableCollection<string> SelectedListOfIngredients {
			get {
				return selectedListOfIngredients;
			}
			set {
				selectedListOfIngredients = value;
				OnPropertyChnaged ("SelectedListOfIngredients");
			}
		}

		public MainPageViewModel ()
		{
			SaveCommand = new Command (new Action(()=>{OnSubmit();}));

		}

		public Action<IEnumerable<String>> SelectionCompletedAction{ get; set; }



		void OnSubmit()
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
