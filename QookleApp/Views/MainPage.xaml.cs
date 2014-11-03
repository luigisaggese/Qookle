﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace QookleApp
{	
	public partial class MainPage : ContentPage, IViewModel<MainPageViewModel>
	{
		MainPageViewModel ViewModel; 

		string _facebookUserName = "";
		public string FacebookUserName {
			get{ 
				return _facebookUserName;
			}
			set{ 
				this.FacebookUser.Text = value;
				if (string.IsNullOrWhiteSpace (value)) {
					FacebookPictureImage.IsVisible = false;
				} else {
					FacebookPictureImage.IsVisible = true;
				}
				_facebookUserName = value;
			}
		}

		string _facebookPictureUri;
		public string FacebookPictureUri {
			get{ 
				return _facebookPictureUri;
			}
			set{ 
				_facebookPictureUri = value;
				FacebookPictureImage.Source = value;
			}
		}

		private void SearchTapped(object sender, EventArgs e) 
		{
			ViewModel.SelectNewIngredient((sender as SearchedIngredientCellView).BindingContext as string);
		}

		private void SelectedTapped(object sender, EventArgs e) 
		{
			ViewModel.RemoveIngredient ((sender as SelectedIngredientCellView).BindingContext as string);
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
	
		public MainPage ()
		{
			InitializeComponent ();

			TextEntry.Focused += (sender, e) => {
				QookButton.HeightRequest = 0;
				QookButtonGrid.HeightRequest = 0;
				FaceBookAccountLayout.HeightRequest = 0;

			};
			TextEntry.Unfocused += (sender, e) => {
				FaceBookAccountLayout.HeightRequest = 80;
				QookButtonGrid.HeightRequest = 80;
				QookButton.HeightRequest = 100;
			};

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (s, e) => {
				if (ViewModel.SelectedListOfIngredients.Any ())
					ViewModel.OnSubmit();
				else
					DisplayAlert ("Ohhh", "Select something", "Ok");
			};

			QookButton.GestureRecognizers.Add (tapGestureRecognizer);

			var facebookTapGestureRecognizer = new TapGestureRecognizer ();
			facebookTapGestureRecognizer.Tapped += async (s, e) => {
				if(FacebookUserName != "")
				{
					var action = await DisplayActionSheet ("Logged in as " + FacebookUserName, "Log out", "Cancel");
					
					if(action == "Log out")
					{
						FacebookUserName = "";
					}
				}
				else
				{
					await Navigation.PushAsync(new LoginFacebookPage());
				}

			};

			FacebookImageButton.GestureRecognizers.Add (facebookTapGestureRecognizer);

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