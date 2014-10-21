using System;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace QookleApp
{
	public class ServiceHelper
	{
		//static IService recipeService;

		public static async Task<Recipe> GetRecipe()//tam dekilka treba 1 receptiv za raz
		//pohui 
		{//bude samlpe
			return  await DependencyService.Get<IService> ().GetRecipe ();//VO ebat! tepert etreba vzhe pid kozhnu platformu okremo pusatu pravulno? realizyvatu toj metod getrecipe? da ebat
		}
	}
}

