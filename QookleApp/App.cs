using System;
using Xamarin.Forms;

namespace QookleApp
{

	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage (new MainPage ()){ };
		}
	}
}

