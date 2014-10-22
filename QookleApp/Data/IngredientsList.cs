using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QookleApp
{
	class IngredientsList
	{
		public ObservableCollection<string> IngredientsFullList;

		public IngredientsList ()
		{
			IngredientsFullList = new ObservableCollection<string> ();
			IngredientsFullList.Add ("Pasta");
			IngredientsFullList.Add ("Salt");
			IngredientsFullList.Add ("Riso");
			IngredientsFullList.Add ("Lime");
			IngredientsFullList.Add ("Lonza");
			IngredientsFullList.Add ("Oca");
			IngredientsFullList.Add ("Okra");
			IngredientsFullList.Add ("Olio");

		}
	}
}

