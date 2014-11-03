using System;
using System.Linq;
using System.Collections.Generic;

namespace QookleApp
{
	public class DetailedRecipeViewModel
	{

		public string Id {
			get;
			set;
		}

		public string Image {
			get;
			set;
		}

		public IEnumerable<string> Ingredients {
			get;
			set;
		}

		public string IngredientsString{
			get{ 
				if (!Ingredients.Any ())
					return "";
				else {
					string ingredients = "";
					foreach(string ing in Ingredients)
						ingredients += "•" + ing + "\n";
					return ingredients;
				}
			}
		}

		public long Published {
			get;
			set;
		}


		public string Publisher {
			get;
			set;
		}


		public string Title {
			get;
			set;
		}

		public string Url {
			get;
			set;
		}

		public string Kind {
			get;
			set;
		}

		public string PublisherImage {
			get{return "http://g.etfv.co/"+Url+"?defaulticon=bluepng"; }
		}

		public DetailedRecipeViewModel (Recipe recipe)
		{
			Id = recipe.id;
			Image = recipe.img;
			Ingredients = new List<string> (recipe.ingredients);
			Published = recipe.published;
			Publisher = recipe.publisher;
			Title = recipe.title;
			Url = recipe.url;
			Kind = recipe.kind;

		}
	}
}

