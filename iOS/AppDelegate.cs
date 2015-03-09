using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;

namespace QookleApp.iOS
{

	[Register ("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
	}
}

