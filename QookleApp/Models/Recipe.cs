using System;
using System.Collections.Generic;

namespace QookleApp
{
	public class Recipe
	{


		public int id {
			get;
			set;
		}

		public string img {
			get;
			set;
		}

		public IEnumerable<string> ingredients {
			get;
			set;
		}

		public long published {
			get;
			set;
		}


		public string publisher {
			get;
			set;
		}


		public string title {
			get;
			set;
		}

		public string url {
			get;
			set;
		}

		public string kind {
			get;
			set;
		}

		public Recipe ()
		{
		}
	}
}