namespace QookleApp.WP
{
    using Microsoft.Phone.Controls;

    /// <summary>
    /// The main page.
    /// </summary>
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            Forms.Init();
            this.Content = QookleApp.App.GetMainPage().ConvertPageToUIElement(this);

            // Sample code to localize the ApplicationBar
            // BuildLocalizedApplicationBar();
        }
    }
}