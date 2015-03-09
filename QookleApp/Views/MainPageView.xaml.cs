﻿using System;
using System.Collections.Generic;
using System.Linq;
using QookleApp.Views.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QookleApp.Views
{

    public partial class MainPageView : ContentPage, IViewModel<MainPageViewModel>
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
			var screenHeight = ServiceHelper.GetScreenHeight();
			var screenWidth = ServiceHelper.GetScreenWidth();
			SelectedIngredientsList.Children.Clear();
			foreach(var val in ViewModel.SelectedListOfIngredients)
			{
				var item = new SelectedIngredientCellView(this){ BindingContext = val };
				item.Changed+=SelectedTapped;
				SelectedIngredientsList.Children.Add (item);
				//MainGrid.LayoutTo(MainGrid.Bounds);// = 0;

			}
		}

		void ResetSearchedList()
		{
			var screenHeight = ServiceHelper.GetScreenHeight();
			var screenWidth = ServiceHelper.GetScreenWidth();
			SearchedIngredientsList.Children.Clear();
			foreach(var val in ViewModel.SearchListOfIngredients)
			{
				var item = new SearchedIngredientCellView(this){ BindingContext = val };
				item.Changed+=SearchTapped;
				//MainGrid.LayoutTo(MainGrid.Bounds);// = 0;
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
	
		double _qookButtonHeight = ServiceHelper.GetScreenHeight() / 8;

		void TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!string.IsNullOrWhiteSpace (e.NewTextValue)) {
				if (QookButton.HeightRequest > 0) {
					//QookButton.HeightRequest = 0;
					//HeaderContainer.HeightRequest = 0;
				}
			}
		}

		async void Authorize()
		{
			var rs=await FbAuth.Authorize ();
		}

		public MainPageView ()
		{
			InitializeComponent ();
			this.Title = "Ricerca";
			//HeaderGrid.HeightRequest = 200;
			//Authorize ();
			var a = HeaderImage;
			//HeaderContainer.HeightRequest = ServiceHelper.ConvertPixelsToDp( (int)((ServiceHelper.GetScreenHeight()  / 2) - ServiceHelper.GetScreenHeight() / 10));
			//BottomContent.HeightRequest = ServiceHelper.ConvertPixelsToDp( (int)((ServiceHelper.GetScreenHeight()  / 2) - ServiceHelper.GetScreenHeight() / 10));

			TextEntry.Focused += async (sender, e) => {
				var screenHeight = ServiceHelper.GetScreenHeight();
				var screenWidth = ServiceHelper.GetScreenWidth();

				//QookButtonGrid.HeightRequest = 0;
				//MainGrid.LayoutTo(new Rectangle(new Point(0, - screenHeight / 5), new Size(MainGrid.Width,MainGrid.Height)), 250, Easing.Linear);// = 0;
				//MainGrid.TranslateTo(0, - screenHeight / 5, 250, Easing.Linear);// = 0;

				//QookButton.HeightRequest = 0;
				//HeaderContainer.HeightRequest = 0;

			};

			TextEntry.Unfocused += async (sender, e) => {
				//FaceBookAccountLayout.HeightRequest = 80;
				//QookButtonGrid.HeightRequest = 80;
				//QookButton.HeightRequest = _qookButtonHeight;
				//HeaderContainer.HeightRequest = ServiceHelper.ConvertPixelsToDp( (int)((ServiceHelper.GetScreenHeight()  / 2) - ServiceHelper.GetScreenHeight() / 10));


				//MainGrid.LayoutTo(new Rectangle(new Point(0, 0), new Size(MainGrid.Width,MainGrid.Height)), 250, Easing.Linear);// = 0;
				//MainGrid.TranslateTo(0, 0, 250, Easing.Linear);// = 0;

				var screenHeight = ServiceHelper.GetScreenHeight();
				var screenWidth = ServiceHelper.GetScreenWidth();
			};

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (s, e) => {
				if (ViewModel.SelectedListOfIngredients.Any ())
					ViewModel.OnSubmit();
				else
					DisplayAlert ("Ohhh", "Select something", "Ok");
			};

			QookButton.GestureRecognizers.Add (tapGestureRecognizer);

			QookButton.HeightRequest = _qookButtonHeight;
			QookButton.WidthRequest = _qookButtonHeight;

			//EntryLayout. = screenHeiht / 2;

			var facebookTapGestureRecognizer = new TapGestureRecognizer ();
			facebookTapGestureRecognizer.Tapped += async (s, e) => {
				if(FacebookUserName != "")
				{
					/*var action = await DisplayActionSheet ("Logged in as " + FacebookUserName, "Log out", "Cancel");
					
					if(action == "Log out")
					{
						FacebookUserName = "";
					}*/

				}
				else
				{await FbAuth.Authorize();
					//await Navigation.PushAsync(new LoginFacebookPage());
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
		//	this.Content = new GoogleAdsView ();
		}

	}

}