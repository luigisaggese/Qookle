using System;
using System.Collections.Generic;
using Xamarin.Forms;

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
		}
	}
}

