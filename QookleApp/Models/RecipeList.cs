using System;
using System.Collections.Generic;

namespace QookleApp
{
	public class RecipeList
	{
		public IEnumerable<Recipe> items {
			get;
			set;
		}

		public string kind {
			get;
			set;
		}

		public string etag {
			get;
			set;
		}
	}
}

