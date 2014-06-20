using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Qookle.Models;
using Qookle.Services;


namespace Qookle.ViewModels
{
	public class MainViewModel 
		: MvxViewModel
	{
		private readonly IQookleService _service;

		public MainViewModel(IQookleService service)
		{
			_service = service;
		}

		private string _searchString;

		public string SearchString
		{
			get { return _searchString; }
			set 
			{
				_searchString = value;
				RaisePropertyChanged(() => SearchString);
			}
		}

		private List<DetailedRecipe> _recipes;

		public List<DetailedRecipe> Recipes
		{
			get { return _recipes; }
			set
			{
				_recipes = value;
				RaisePropertyChanged(() => Recipes);
			}
		}

		private DetailedRecipe _selectedRecipe;

		public DetailedRecipe SelectedRecipe
		{
			get { return _selectedRecipe; }
			set
			{
				_selectedRecipe = value;
				RaisePropertyChanged(() => SelectedRecipe);

				ShowSelectedRecipeCommand.Execute(null);
			}
		}

		public ICommand GetRecipesCommand
		{
			get
			{
				return new MvxCommand(async () =>
					{
						Recipes = await _service.SearchRecipe("1",SearchString);
					});
			}
		}

		public ICommand ShowSelectedRecipeCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<DetailedRecipeViewModel>(new {recipe = SelectedRecipe}),
					() => SelectedRecipe != null);
			}
		}

		public ICommand ShowAboutPageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<AboutViewModel>());
			}
		}
	}
}
