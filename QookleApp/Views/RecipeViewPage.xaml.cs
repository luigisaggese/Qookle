using System;
using Xamarin.Forms;

namespace QookleApp.Views
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

		public RecipeViewPage (String id )
		{
			InitializeComponent ();
			this.SetViewModel(new RecipeViewPageViewModel (id));

			if (string.IsNullOrWhiteSpace (id)) {
				//message
			} else {
				ContentWebView.Source = GetCurrentViewModel().WebAddress;
			}

		}
	}
}

