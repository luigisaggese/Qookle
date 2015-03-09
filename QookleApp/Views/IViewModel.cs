namespace QookleApp.Views
{
	public interface IViewModel<T> where T: BaseViewModel
	{
		T GetCurrentViewModel();
		void SetViewModel(T viewModel);
	}
}

