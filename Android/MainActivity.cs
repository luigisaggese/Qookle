﻿namespace QookleApp.Android
{
    using global::Android.App;
    using global::Android.Content.PM;
    using global::Android.OS;

    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// The main activity.
    /// </summary>
    [Activity(Label = "Qookle", Theme = "@android:style/Theme.Holo", 
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

            Xamarin.Forms.Forms.Init(this, bundle);
            this.LoadApplication(new App());
        }
    }
}