using System;

namespace Qookle.Models
{
	public class SearchListItemRaw
	{
		public DetailedRecipe[] Items { get; set; }
		public string Kind { get; set; }
		public string Etag { get; set; }
	}
}

