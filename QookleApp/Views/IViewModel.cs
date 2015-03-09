namespace QookleApp.Views
{
    /// <summary>
    /// The ViewModel interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IViewModel<T>
        where T : BaseViewModel
    {
        /// <summary>
        /// The get current view model.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetCurrentViewModel();

        /// <summary>
        /// The set view model.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        void SetViewModel(T viewModel);
    }
}