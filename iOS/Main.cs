namespace QookleApp.iOS
{
    using MonoTouch.UIKit;

    /// <summary>
    /// The application.
    /// </summary>
    public class Application
    {
        // This is the main entry point of the application.
        private static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}