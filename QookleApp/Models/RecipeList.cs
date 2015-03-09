namespace QookleApp
{
    using System.Collections.Generic;

    /// <summary>
    /// The recipe list.
    /// </summary>
    public class RecipeList
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public IEnumerable<Recipe> items { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public string kind { get; set; }

        /// <summary>
        /// Gets or sets the etag.
        /// </summary>
        public string etag { get; set; }
    }
}