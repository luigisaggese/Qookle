namespace QookleApp
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The Service interface.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// The get recipe.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<RecipeList> GetRecipe(IEnumerable<string> parameters, int page);

        /// <summary>
        /// The get screen width.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        double GetScreenWidth();

        /// <summary>
        /// The get screen height.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        double GetScreenHeight();

        /// <summary>
        /// The get screen dpi height.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        double GetScreenDPIHeight();

        /// <summary>
        /// The get screen dpi width.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        double GetScreenDPIWidth();

        /// <summary>
        /// The convert pixels to dp.
        /// </summary>
        /// <param name="pixelValue">
        /// The pixel value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int ConvertPixelsToDp(float pixelValue);
    }
}