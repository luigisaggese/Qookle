using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QookleApp
{
	public interface IService
	{
		Task<RecipeList> GetRecipe(IEnumerable<string> parameters);//
	}
}

