using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QookleApp
{
	class IngredientsList
	{
		public static List<string> IngredientsFullList;

		static IngredientsList ()
		{
			IngredientsFullList = new List<string> ();
			IngredientsFullList.Add ("Pasta");
			IngredientsFullList.Add ("Salt");
			IngredientsFullList.Add ("Riso");
			IngredientsFullList.Add ("Lime");
			IngredientsFullList.Add ("Lonza");
			IngredientsFullList.Add ("Oca");
			IngredientsFullList.Add ("Okra");
			IngredientsFullList.Add ("Olio");
			IngredientsFullList.AddRange(
			
			new[] {	"Lumache"
					,"Gamberi"
					,"Funghi misti con porcini"
					,"Zucchine piccole"
					,"Zafferano"
					,"Aglio"
					,"DermO"
					,"Erba cipollina"
					,"Olio extravergine di oliva"
					,"Sale"});
		}
	}
}

