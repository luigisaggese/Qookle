using System;
using Xamarin.Forms;

namespace QookleApp.Views.Controls
{
	public partial class SearchedIngredientCellView : ContentView
	{
		public delegate void ChangedEventHandler(object sender, EventArgs e);

		public event ChangedEventHandler Changed;

		public SearchedIngredientCellView (MainPageView owner)
		{
			InitializeComponent ();
			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (s, e) => {
				OnChanged(e);
			};
			TapLabel.GestureRecognizers.Add (tapGestureRecognizer);

		}

		// Invoke the Changed event; called whenever list changes
		protected virtual void OnChanged(EventArgs e) 
		{
			if (Changed != null)
				Changed(this, e);
		}
	}
}

