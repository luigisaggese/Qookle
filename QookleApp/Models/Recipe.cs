namespace QookleApp
{
    using System.Collections.Generic;

    /// <summary>
    /// The recipe.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the img.
        /// </summary>
        public string img { get; set; }

        /// <summary>
        /// Gets or sets the ingredients.
        /// </summary>
        public IEnumerable<string> ingredients { get; set; }

        /// <summary>
        /// Gets or sets the published.
        /// </summary>
        public long published { get; set; }

        /// <summary>
        /// Gets or sets the publisher.
        /// </summary>
        public string publisher { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public string kind { get; set; }

        /// <summary>
        /// Gets the publisherimage.
        /// </summary>
        public string publisherimage
        {
            get
            {
                return "http://g.etfv.co/" + url + "?defaulticon=bluepng";
            }
        }

        /// <summary>
        /// Gets the img good quality.
        /// </summary>
        public string imgGoodQuality
        {
            get
            {
                return "http://www.qookle.com/recipe_image?id=" + id + "&cw=640";
            }
        }
    }
}