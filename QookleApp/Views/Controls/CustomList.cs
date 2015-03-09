namespace QookleApp.Views.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xamarin.Forms;

    /// <summary>
    /// The custom list.
    /// </summary>
    public class CustomList : ListView
    {
        private readonly List<object> visibleItems = new List<object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomList"/> class.
        /// </summary>
        public CustomList()
        {
            BackgroundColor = Color.Transparent;
            this.ItemTapped += (object sender, ItemTappedEventArgs e) =>
                {
                    if (e.Item.GetType() == typeof(Recipe))
                    {
                        this.Navigation.PushAsync(new RecipeDetailedPage((Recipe)e.Item));
                    }
                };
            this.ItemAppearing += (sender, e) =>
                {
                    if (!visibleItems.Contains(e.Item))
                    {
                        visibleItems.Add(e.Item);
                        var Items = ((IEnumerable<object>)ItemsSource).ToList();
                        var count = Items.Count();
                        if (count > 0)
                        {
                            if (e.Item == Items[count - 1])
                            {
                                if (OnScrolledToEnd != null)
                                {
                                    OnScrolledToEnd();
                                }
                            }
                        }
                    }
                };
            this.ItemDisappearing += (sender, e) => { visibleItems.Remove(e.Item); };
        }

        /// <summary>
        /// Gets or sets the on scrolled to end.
        /// </summary>
        public Action OnScrolledToEnd { get; set; }
    }
}