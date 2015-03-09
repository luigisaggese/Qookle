namespace QookleApp
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Xamarin.Forms;

    /// <summary>
    /// The main page view model.
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<string> _searchListOfIngredients = new ObservableCollection<string>();

        private string _searchText = string.Empty;

        private ObservableCollection<string> _selectedListOfIngredients = new ObservableCollection<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel()
        {
            SaveCommand = new Command(OnSubmit);
        }

        /// <summary>
        /// Gets or sets the text to search.
        /// </summary>
        public string TextToSearch
        {
            get
            {
                return _searchText;
            }

            set
            {
                _searchText = value;
                if (string.IsNullOrWhiteSpace(_searchText))
                {
                    SearchListOfIngredients = new ObservableCollection<string>();
                }
                else
                {
                    SearchListOfIngredients =
                        new ObservableCollection<string>(
                            IngredientsList.IngredientsFullList.Except(SelectedListOfIngredients)
                                .Where(x => x.ToLower().StartsWith(value.ToLower()))
                                .Take(8));
                }

                OnPropertyChnaged("TextToSearch");
            }
        }

        /// <summary>
        /// Gets or sets the search list of ingredients.
        /// </summary>
        public ObservableCollection<string> SearchListOfIngredients
        {
            get
            {
                return _searchListOfIngredients;
            }

            set
            {
                _searchListOfIngredients = value;
                OnPropertyChnaged("SearchListOfIngredients");
            }
        }

        /// <summary>
        /// Gets or sets the selected list of ingredients.
        /// </summary>
        public ObservableCollection<string> SelectedListOfIngredients
        {
            get
            {
                return _selectedListOfIngredients;
            }

            set
            {
                _selectedListOfIngredients = value;
                OnPropertyChnaged("SelectedListOfIngredients");
            }
        }

        /// <summary>
        /// Gets or sets the selection completed action.
        /// </summary>
        public Action<IEnumerable<string>> SelectionCompletedAction { get; set; }

        /// <summary>
        /// Gets the save command.
        /// </summary>
        public Command SaveCommand { get; internal set; }

        /// <summary>
        /// Gets the text changed command.
        /// </summary>
        public Command TextChangedCommand { get; internal set; }

        /// <summary>
        /// The select new ingredient.
        /// </summary>
        /// <param name="ingredient">
        /// The ingredient.
        /// </param>
        public void SelectNewIngredient(string ingredient)
        {
            SelectedListOfIngredients.Add(ingredient);
            SearchListOfIngredients.Remove(ingredient);

            TextToSearch = string.Empty;
            OnPropertyChnaged("SelectedListOfIngredients");
        }

        /// <summary>
        /// The remove ingredient.
        /// </summary>
        /// <param name="ingredient">
        /// The ingredient.
        /// </param>
        public void RemoveIngredient(string ingredient)
        {
            SelectedListOfIngredients.Remove(ingredient);

            OnPropertyChnaged("SelectedListOfIngredients");
        }

        /// <summary>
        /// The on submit.
        /// </summary>
        public void OnSubmit()
        {
            if (SelectionCompletedAction != null)
            {
                SelectionCompletedAction(SelectedListOfIngredients);
            }
        }
    }
}