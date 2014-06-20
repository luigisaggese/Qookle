using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Qookle.Models;

namespace Qookle.Services
{
	public interface IQookleService
	{
		Task<List<DetailedRecipe>> SearchRecipe(string page, string ingredients);
	}
}