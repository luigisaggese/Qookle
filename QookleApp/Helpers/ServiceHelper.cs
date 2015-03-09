namespace QookleApp
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    /// <summary>
    /// The service helper.
    /// </summary>
    public class ServiceHelper
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
        public static async Task<RecipeList> GetRecipe(IEnumerable<string> parameters, int page)
        {
            return await DependencyService.Get<IService>().GetRecipe(parameters, page);
        }

        /// <summary>
        /// The get screen width.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double GetScreenWidth()
        {
            return DependencyService.Get<IService>().GetScreenWidth();
        }

        /// <summary>
        /// The get screen height.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double GetScreenHeight()
        {
            return DependencyService.Get<IService>().GetScreenHeight();
        }

        /// <summary>
        /// The get screen dpi width.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double GetScreenDPIWidth()
        {
            return DependencyService.Get<IService>().GetScreenDPIWidth();
        }

        /// <summary>
        /// The get screen dpi height.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double GetScreenDPIHeight()
        {
            return DependencyService.Get<IService>().GetScreenDPIHeight();
        }

        /// <summary>
        /// The convert pixels to dp.
        /// </summary>
        /// <param name="pixelValue">
        /// The pixel value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int ConvertPixelsToDp(float pixelValue)
        {
            return DependencyService.Get<IService>().ConvertPixelsToDp(pixelValue);
        }
    }
}