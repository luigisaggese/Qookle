namespace QookleApp.iOS
{
    using MonoTouch.Foundation;
    using MonoTouch.UIKit;

    /// <summary>
    /// The app delegate.
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private UIWindow window;

        /// <summary>
        /// The finished launching.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}