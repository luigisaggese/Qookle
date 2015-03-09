namespace QookleApp.Views.Controls
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    /// The selected ingredient cell view.
    /// </summary>
    public partial class SelectedIngredientCellView : ContentView
    {
        /// <summary>
        /// The changed event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public delegate void ChangedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedIngredientCellView"/> class.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        public SelectedIngredientCellView(MainPageView owner)
        {
            InitializeComponent();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => { OnChanged(e); };
            ClosingLabel.GestureRecognizers.Add(tapGestureRecognizer);
        }

        /// <summary>
        /// The changed.
        /// </summary>
        public event ChangedEventHandler Changed;

        // Invoke the Changed event; called whenever list changes
        /// <summary>
        /// The on changed.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }
    }
}