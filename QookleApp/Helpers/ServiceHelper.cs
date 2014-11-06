using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace QookleApp
{
	public class ServiceHelper
	{
		public static async Task<RecipeList> GetRecipe(IEnumerable<string> parameters, int page)
		{
			return await DependencyService.Get<IService> ().GetRecipe (parameters,page);
		}
	}
}

