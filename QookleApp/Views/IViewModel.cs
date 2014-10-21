using System;

namespace QookleApp
{
	public interface IViewModel<T> where T: BaseViewModel
	{
		T GetCurrentViewModel();
		void SetViewModel(T viewModel);
	}
}

