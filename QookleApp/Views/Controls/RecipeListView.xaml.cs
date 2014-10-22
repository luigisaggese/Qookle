using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QookleApp
{
	public partial class RecipeListView : ContentView
	{
		public RecipeListView ()
		{
			InitializeComponent ();
		}
	}

	public class RecipeListViewCell:ViewCell{
		public RecipeListViewCell(){
			this.View=new RecipeListView();
		}
	}
}

