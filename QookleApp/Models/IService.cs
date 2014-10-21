using System;
using System.Threading.Tasks;

namespace QookleApp
{
	public interface IService
	{
		Task<Recipe> GetRecipe();//
	}
}

