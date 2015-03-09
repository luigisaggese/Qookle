namespace QookleApp.WP
{
    using Microsoft.Phone.Controls;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.WinPhone;

    /// <summary>
    /// The main page.
    /// </summary>
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new QookleApp.App());
        }
    }
}