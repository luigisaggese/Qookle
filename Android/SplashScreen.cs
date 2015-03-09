namespace QookleApp.Android
{
    using global::Android.App;
    using global::Android.Content;
    using global::Android.OS;

    /// <summary>
    /// The splash screen.
    /// </summary>
    [Activity(Label = "Qookle", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash")]
    public class SplashScreen : Activity
    {
        /// <summary>
        /// The on create.
        /// </summary>
        /// <param name="bundle">
        /// The bundle.
        /// </param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var intent = new Intent(this, typeof(MainActivity));
            this.StartActivity(intent);
            this.Finish();
        }
    }
}