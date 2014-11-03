using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace QookleApp
{
	public partial class SplashScreen : ContentPage
	{
		MainPage _mainPage;
		public SplashScreen (MainPage mainPage)
		{
			_mainPage = mainPage;
			InitializeComponent ();

			NavigeteToMain ();
		}

		void NavigeteToMain()
		{
			Task.Delay(new TimeSpan(0,0,5)).Wait();
			Navigation.PushAsync (_mainPage);
		}


		internal delegate void TimerCallback(object state);

		internal sealed class Timer : CancellationTokenSource, IDisposable
		{
			internal Timer(TimerCallback callback, object state, int dueTime, int period)
			{
				//Contract.Assert(period == -1, "This stub implementation only supports dueTime.");
				Task.Delay(dueTime, Token).ContinueWith((t, s) =>
					{
						var tuple = (Tuple<TimerCallback, object>)s;
						tuple.Item1(tuple.Item2);
					}, Tuple.Create(callback, state), CancellationToken.None,
					TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion,
					TaskScheduler.Default);
			}

			public new void Dispose() { base.Cancel(); }
		}
	}
}

