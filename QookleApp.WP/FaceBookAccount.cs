namespace QookleApp.Android
{
    /// <summary>
    /// The face book account.
    /// </summary>
    public class FaceBookAccount
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        public dynamic picture { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string id { get; set; }
    }

    /// <summary>
    /// The my picture.
    /// </summary>
    public class MyPicture
    {
        private object data { get; set; }
    }

    internal class MyData
    {
        private bool is_silhouette { get; set; }

        private string url { get; set; }
    }
}