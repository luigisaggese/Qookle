using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace QookleApp
{
	public class MainPageViewModel:BaseViewModel
	{
		public string TextToSearch {
			get;
			set;
		}

		ObservableCollection<string> searchListOfIngredients;
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
