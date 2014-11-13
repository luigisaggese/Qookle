using System;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace QookleApp
{
	public interface IFb
	{
		Task<bool> Authorize ();
		String GetName ();
	}

	public class FbAuth
	{
		#region IFb implementation

		public static async Task<bool> Authorize ()
		{
			return await DependencyService.Get<IFb> ().Authorize();
		}

		public static string GetName ()
		{
			throw new NotImplementedException ();
		}

		#endregion


	}
}

