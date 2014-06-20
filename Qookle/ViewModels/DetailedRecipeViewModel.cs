using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.WebBrowser;
using Cirrious.MvvmCross.ViewModels;
using Qookle.Models;
using Qookle.Services;

namespace Qookle.ViewModels
{
	public class DetailedRecipeViewModel 
		: MvxViewModel
	{
		private DetailedRecipe _model;

		public void Init(DetailedRecipe recipe)
		{
			_model = recipe;
		}

		public override async void Start()
		{
			base.Start();

			if (_model != null) return;

			Title = _model.Title;
			Score = 2;
			PosterUrl = _model.ImageUrl;
			VoteCount = 3;
			ImdbUrl = _model.Url;
			Synopsis = _model.Ingredients.ToString();
			TagLine = _model.Kind;
			Runtime = 4;
		}

		private readonly IQookleService _service;

		public DetailedRecipeViewModel(IQookleService service)
		{
			_service = service;
		}

		private string _title;
		public string Title
		{
			get { return _title; }
			set
			{
				_title = value;
				RaisePropertyChanged(() => Title);
			}
		}

		private double _score;
		public double Score
		{
			get { return _score; }
			set
			{
				_score = value;
				RaisePropertyChanged(() => Score);
			}
		}

		private string _posterUrl;
		public string PosterUrl
		{
			get { return _posterUrl; }
			set
			{
				_posterUrl = value;
				RaisePropertyChanged(() => PosterUrl);
			}
		}

		private string _releaseDate;
		public string ReleaseDate
		{
			get { return _releaseDate; }
			set
			{
				_releaseDate = value;
				RaisePropertyChanged(() => ReleaseDate);
			}
		}

		private int _voteCount;
		public int VoteCount
		{
			get { return _voteCount; }
			set
			{
				_voteCount = value;
				RaisePropertyChanged(() => VoteCount);
			}
		}

		private string _imdbUrl;
		public string ImdbUrl
		{
			get { return "http://www.imdb.com/title/" + _imdbUrl; }
			set
			{
				_imdbUrl = value;
				RaisePropertyChanged(() => ImdbUrl);
			}
		}

		private string _synopsis;
		public string Synopsis
		{
			get { return _synopsis; }
			set
			{
				_synopsis = value;
				RaisePropertyChanged(() => Synopsis);
			}
		}

		private string _tagline;
		public string TagLine
		{
			get { return _tagline; }
			set
			{
				_tagline = value;
				RaisePropertyChanged(() => TagLine);
			}
		}

		private int _runtime;
		public int Runtime
		{
			get { return _runtime; }
			set
			{
				_runtime = value;
				RaisePropertyChanged(() => Runtime);
			}
		}

		public ICommand ShowOnImdbCommand
		{
			get
			{
				return new MvxCommand(() => 
					Mvx.Resolve<IMvxWebBrowserTask>().ShowWebPage(ImdbUrl));
			}
		}
	}
}
