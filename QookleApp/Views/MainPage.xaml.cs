using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace QookleApp
{	
	public partial class MainPage : ContentPage, IViewModel<MainPageViewModel>
	{
		#region IViewModel implementation


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
			this.SetViewModel (new MainPageViewModel ());
			GetCurrentViewModel ().SelectionCompletedAction = new Action<IEnumerable<string>> ((obj) => {
				Navigation.PushAsync (new RecipeListPage (obj));
			});
		}


		public void TextChanged(object sender,TextChangedEventArgs t){


			var lis = new IngredientsList();
			var resultList = new ObservableCollection<string>();
			foreach(var l in lis.IngredientsFullList)
			{
				if (t.NewTextValue != "") {
					if (l.ToLower().Contains (t.NewTextValue.ToLower())) {
						if (GetCurrentViewModel ().SelectedListOfIngredients != null) {
							if (!GetCurrentViewModel ().SelectedListOfIngredients.Contains (l))
								resultList.Add (l);
						} else {
							resultList.Add (l);
						}
					}
				}
			}
			GetCurrentViewModel().SearchListOfIngredients = resultList;
		}

		public void AddItemToResultList(object sender, ItemTappedEventArgs t)
		{
			var list = new ObservableCollection<string> ();
			var oldList = GetCurrentViewModel ().SelectedListOfIngredients;
			if(oldList!=null)
			if (oldList.Count > 0) {
				foreach (var item in oldList) {

					list.Add (item);
				}
			}

			var s = (string)t.Item;
			list.Add (s);

			GetCurrentViewModel ().SelectedListOfIngredients = list;
			this.TextEntry.Text = "";
		}

		public void DeleteItemFromResultList(object sender, ItemTappedEventArgs t)
		{
			var list = new ObservableCollection<string> ();
			var oldList = GetCurrentViewModel ().SelectedListOfIngredients;
			if(oldList!=null)
			if (oldList.Count > 0) {
				foreach (var item in oldList) {
					if(item!=(string)t.Item)
					list.Add (item);
				}
			}
			GetCurrentViewModel ().SelectedListOfIngredients = list;
		}
	}
}