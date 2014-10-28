using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QookleApp
{	
	public partial class RecipeDetailedPage : ContentPage
	{	
		string _id;

		public RecipeDetailedPage (string id)
		{
			_id = id;
			InitializeComponent ();
		}
	}
}

