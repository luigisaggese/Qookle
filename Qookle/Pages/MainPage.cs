using Xamarin.Forms;

namespace Qookle.Pages
{
	public class MainPage 
		: ContentPage
	{
		public MainPage()
		{
			Button goButton;
			Entry searchEntry;
			StackLayout mainLayout;
			Title = "Recipes Sample";

			Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			var searchLayout = new StackLayout
			{
				Spacing = 10,
				Orientation = StackOrientation.Horizontal,
			};

			searchLayout.Children.Add(searchEntry = new Entry
				{
					Placeholder = "Recipe Name",
					HorizontalOptions = LayoutOptions.FillAndExpand
				});
			searchLayout.Children.Add(goButton = new Button
				{
					Text = "Search", IsEnabled = true,
					HorizontalOptions = LayoutOptions.End
				});

			Content = mainLayout = new StackLayout
			{
				Padding = new Thickness(10),
				Spacing = 10,
				Orientation = StackOrientation.Vertical,
			};

			mainLayout.Children.Add(searchLayout);

			var recipeListView = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(ImageCell)),
				Rotation=270,
				RowHeight = 40

			};

			mainLayout.Children.Add(recipeListView);

			searchEntry.SetBinding(Entry.TextProperty, new Binding("SearchString"));
			goButton.SetBinding(Button.CommandProperty, new Binding("GetRecipesCommand"));
			recipeListView.SetBinding(ListView.ItemsSourceProperty, new Binding("Recipes"));
			recipeListView.SetBinding(ListView.SelectedItemProperty, new Binding("SelectedRecipe"));
			recipeListView.ItemTemplate.SetBinding(ImageCell.TextProperty, new Binding("Title"));
			recipeListView.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, new Binding("ImageUrl"));
			recipeListView.ItemTemplate.SetBinding(ImageCell.DetailProperty, new Binding("Score"));
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			// Fixed in next version of Xamarin.Forms. BindingContext is not properly set on ToolbarItem.
			var aboutItem = new ToolbarItem { Name = "About", BindingContext = BindingContext };
			aboutItem.SetBinding(ToolbarItem.CommandProperty, new Binding("ShowAboutPageCommand"));

			ToolbarItems.Add(aboutItem);
		}
	}
}
