using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
using Cirrious.MvvmCross.Touch.Platform;
using MonoTouch.FacebookConnect;
using MTiRate;
//using ParseTouch;
using BigTed;
using Cirrious.CrossCore.WeakSubscription;
using GoogleAnalytics.iOS;
using SDWebImage;

namespace Qookle.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate
		: MvxApplicationDelegate
	{
		public static readonly NSString NotificationWillChangeStatusBarOrientation = new NSString("UIApplicationWillChangeStatusBarOrientationNotification");
		public static readonly NSString NotificationDidChangeStatusBarOrientation = new NSString("UIApplicationDidChangeStatusBarOrientationNotification");
		public static readonly NSString NotificationOrientationDidChange = new NSString("UIDeviceOrientationDidChangeNotification");
		public static readonly NSString NotificationFavoriteUpdated = new NSString("NotificationFavoriteUpdated");

		const string FacebookAppId = "539437369482517";

		const string DisplayName = "Qookle";
		public static readonly string TrackingId = "UA-38636262-2";
		public IGAITracker Tracker;
		// class-level declarations
		UIWindow _window;
		UINavigationController navController;
		//LoginView viewController;

		public static bool IsPhone
		{
			get
			{
				return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;
			}
		}

		public static bool IsPad
		{
			get
			{
				return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad;
			}
		}

		public static bool HasRetina
		{
			get
			{
				if (MonoTouch.UIKit.UIScreen.MainScreen.RespondsToSelector(new Selector("scale")))
					return (MonoTouch.UIKit.UIScreen.MainScreen.Scale == 2.0);
				else
					return false;
			}
		}


		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{

			UIApplication.SharedApplication.RegisterForRemoteNotificationTypes (
				UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound);

			//ParseTouch.Parse.SetAppId ("Ti1JICYrMZgOUpoeR6ONlgKHIw9jiKphVI47bWld", "dWtzbE7K6tb7933MBeOvInnQNEcwoV5rfmhWwe1j");

			SDWebImageManager.SharedManager.SetCacheKeyFilter(url => {
				if(url.AbsoluteString.Contains("g.etfv.co")){
					string key = url.AbsoluteString.Replace("http://g.etfv.co/","").Replace("?defaulticon=bluepng","");
					key = key.Substring(0,key.IndexOf("/",9));
					return (NSString)key;
				}
				return (NSString)url.AbsoluteString;
			});
			// create a new window instance based on the screen size
			_window = new UIWindow(UIScreen.MainScreen.Bounds);
			var rateAlert = iRate.SharedInstance;



			// Enable preview mode so everytime Application is launched you get the promt
			rateAlert.PreviewMode = false;

			FBSettings.DefaultAppID = FacebookAppId;
			FBSettings.DefaultDisplayName = DisplayName;
			FBSettings.DefaultUrlSchemeSuffix = "fb" + FacebookAppId;

			rateAlert.OnlyPromptIfLatestVersion = false;
			iRate.SharedInstance.MessageTitle = "Che ne pensi?";
			iRate.SharedInstance.Message = "Se l'applicazione ti piace, faccelo sapere! Ne saremo HAPPY!";;
			iRate.SharedInstance.CancelButtonLabel = "No, grazie";
			iRate.SharedInstance.RemindButtonLabel = "Più tardi";
			iRate.SharedInstance.RateButtonLabel = "Ok!";

			// Optional: set Google Analytics dispatch interval to e.g. 20 seconds.
			GAI.SharedInstance.DispatchInterval = 20;

			// Optional: automatically send uncaught exceptions to Google Analytics.
			GAI.SharedInstance.TrackUncaughtExceptions = true;

			// Initialize tracker.
			Tracker = GAI.SharedInstance.GetTracker (TrackingId);

			navController = new UINavigationController ();

			_window.RootViewController = navController;

			var setup = new Setup(this, _window);
			setup.Initialize();


			// start the app
			var start = Mvx.Resolve<IMvxAppStart>();
			start.Start();

			_window.MakeKeyAndVisible();


			return true;
		}
		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
			/*

			ParsePush.StoreDeviceToken(deviceToken);

			ParsePush.SubscribeToChannelAsync("");
			*/
		}
		public void ResetBadge(UIApplication application){
			/*
			application.CancelAllLocalNotifications ();
			if (application.ApplicationIconBadgeNumber > 0) {
				application.ApplicationIconBadgeNumber = 0;

				ParseInstallation installation = ParseInstallation.CurrentInstallation;
				installation.Badge = 0;
				installation.SaveAsync ();
			}
			*/
		}

		public override void ReceivedRemoteNotification (UIApplication application, NSDictionary userInfo)
		{
			/*
			HomeViewModel ViewModel = new HomeViewModel ();
			System.Type t = ViewModel.GetType ();
			System.Reflection.PropertyInfo prop = t.GetProperty ("SearchTerm");
			var aps = userInfo.ObjectForKey (new NSString ("aps")) as NSDictionary;
			var search = aps.ObjectForKey (new NSString ("alert")).ToString ();
			search = search.Substring (search.IndexOf (":")+1);
			prop.SetValue (ViewModel,search.Replace (" e ", " ").Replace("!","").Replace(" al "," "), null);
			ViewModel.WeakSubscribe(() => ViewModel.IsBusy, (sender, args) =>
				{
					if (ViewModel.IsBusy)
					{
						if (BTProgressHUD.IsVisible){
							BTProgressHUD.Dismiss();
						}
						BTProgressHUD.Show("Lo Chef stasera consiglia:" + search.Replace("!",""), -1, BTProgressHUD.MaskType.Black);
					}
					else
					{
						if (BTProgressHUD.IsVisible)
							BTProgressHUD.Dismiss();
					}
				});

			ViewModel.GoParameterizedCommand.Execute(null);

			UIAlertView alertView;
			alertView = new UIAlertView("Qookle","Lo Chef stasera consiglia:" + search.Replace("!",""),null,"Ok",null);
			alertView.Show();		
			*/
		}
		public override void DidEnterBackground (UIApplication application)
		{
			foreach (UIWindow win in application.Windows) {
				win.EndEditing (true);
			}
		}

		public override void OnActivated (UIApplication application)
		{
			FBSession.ActiveSession.HandleDidBecomeActive();

			ResetBadge (application);

		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// We need to handle URLs by passing them to FBSession in order for SSO authentication
			// to work.

			return FBSession.ActiveSession.HandleOpenURL(url);
		}






	}
}