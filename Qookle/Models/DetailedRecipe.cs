using System;

namespace Qookle.Models
{
	public class DetailedRecipe
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public string[] Ingredients{ get; set; }
		public string Publisher { get; set; }
		public string Kind { get; set;}

		public string ImageUrl {
			get{
				return "http://www.qookle.com/recipe_image?id=" + Id + "&cw=640";
			}
		}

		public string ImageFavicon {
			get{
				return "http://g.etfv.co/" + Url + "?defaulticon=bluepng";
			}
		}
	}
}

