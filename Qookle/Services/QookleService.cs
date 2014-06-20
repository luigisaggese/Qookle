using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Qookle.Models;
using ModernHttpClient;
using Newtonsoft.Json;

namespace Qookle.Services
{
	public class QookleService : IQookleService
	{
		private HttpClient _baseClient;

		private HttpClient BaseClient
		{
			get
			{
				return _baseClient ?? (_baseClient = new HttpClient(new NativeMessageHandler())
					{
						BaseAddress = new Uri(Constants.BaseUrl)
					});
			}
		}

		public async Task<List<DetailedRecipe>> SearchRecipe(string page, string ingredients)
		{
			try
			{
				var content = new StringContent("");

				var res = await BaseClient.PostAsync(string.Format(Constants.RecipeSearchUrl, page,ingredients),content);
				res.EnsureSuccessStatusCode();

				var json = await res.Content.ReadAsStringAsync();

				if (string.IsNullOrEmpty(json)) return null;

				var recipes = JsonConvert.DeserializeObject<SearchListItemRaw>(json);
				var recipeList = recipes.Items.ToList();

				return recipeList;
			}
			catch(Exception ex)
			{
				Mvx.TaggedTrace(typeof(QookleService).Name, 
					"Ooops! Something went wrong fetching information for: {0} - {1} . Exception: {2}",page,ingredients, ex);
				return null;
			}
		}

	}
}
