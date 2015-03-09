namespace QookleApp
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The detailed recipe view model.
    /// </summary>
    public class DetailedRecipeViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailedRecipeViewModel"/> class.
        /// </summary>
        /// <param name="recipe">
        /// The recipe.
        /// </param>
        public DetailedRecipeViewModel(Recipe recipe)
        {
            Id = recipe.id;
            Image = recipe.img;
            Ingredients = new List<string>(recipe.ingredients);
            Published = recipe.published;
            Publisher = recipe.publisher;
            Title = recipe.title;
            Url = recipe.url;
            Kind = recipe.kind;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the ingredients.
        /// </summary>
        public IEnumerable<string> Ingredients { get; set; }

        /// <summary>
        /// Gets the ingredients string.
        /// </summary>
        public string IngredientsString
        {
            get
            {
                if (!Ingredients.Any())
                {
                    return string.Empty;
                }
                else
                {
                    var ingredients = string.Empty;
                    foreach (var ing in Ingredients)
                    {
                        ingredients += "•" + ing + "\n";
                    }

                    return ingredients;
                }
            }
        }

        /// <summary>
        /// Gets or sets the published.
        /// </summary>
        public long Published { get; set; }

        /// <summary>
        /// Gets or sets the publisher.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets the publisher image.
        /// </summary>
        public string PublisherImage
        {
            get
            {
                return "http://g.etfv.co/" + Url + "?defaulticon=bluepng";
            }
        }
    }
}