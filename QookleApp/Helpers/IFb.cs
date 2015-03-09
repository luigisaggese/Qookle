namespace QookleApp
{
    using System;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    /// <summary>
    /// The Fb interface.
    /// </summary>
    public interface IFb
    {
        /// <summary>
        /// The authorize.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> Authorize();

        /// <summary>
        /// The get name.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetName();
    }

    /// <summary>
    /// The fb auth.
    /// </summary>
    public class FbAuth
    {
        #region IFb implementation

        /// <summary>
        /// The authorize.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<bool> Authorize()
        {
            return await DependencyService.Get<IFb>().Authorize();
        }

        /// <summary>
        /// The get name.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public static string GetName()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}