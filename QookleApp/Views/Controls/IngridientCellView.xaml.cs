using System;
using Xamarin.Forms;

namespace QookleApp.Views.Controls
{
	public partial class SelectedIngredientCellView : ContentView
	{
		public delegate void ChangedEventHandler(object sender, EventArgs e);

		public event ChangedEventHandler Changed;

		public SelectedIngredientCellView (MainPageView owner)
		{
			InitializeComponent ();
			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (s, e) => {
				OnChanged(e);
			};
			ClosingLabel.GestureRecognizers.Add (tapGestureRecognizer);
		}

		// Invoke the Changed event; called whenever list changes
		protected virtual void OnChanged(EventArgs e) 
		{
			if (Changed != null)
				Changed(this, e);
		}
			
	}
}

