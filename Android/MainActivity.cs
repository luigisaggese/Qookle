namespace QookleApp.Android
{
    using global::Android.App;
    using global::Android.Content.PM;
    using global::Android.OS;

    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// The main activity.
    /// </summary>
    [Activity(Label = "Qookle App", Theme = "@android:style/Theme.Holo", 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
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

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}