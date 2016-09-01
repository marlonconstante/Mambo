using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Mambo.ViewModels;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Collections;
using Mobishop.Infrastructure.Framework.Repositories;
using PropertyChanged;
using ReactiveUI;
using Xamarin.Forms;

namespace Mambo.PageModels
{
	/// <summary>
	/// Product search page model.
	/// </summary>
	[ImplementPropertyChanged]
	public class ProductSearchPageModel : FreshBasePageModel
	{
		/// <summary>
		/// The showcase service.
		/// </summary>
		ShowcaseService showcaseService;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.PageModels.ProductSearchPageModel"/> class.
		/// </summary>
		public ProductSearchPageModel()
		{
			showcaseService = new ShowcaseService();

			SearchResultItems = new List<ObservableList<SearchViewModel>>();
			SearchResultItems.Add(new ObservableList<SearchViewModel> {
				GroupName = "Sugestões de Pesquisa"
			});
			SearchResultItems.Add(new ObservableList<SearchViewModel> {
				GroupName = "Produtos Sugeridos"
			});

			SearchCommand = ReactiveCommand.CreateFromTask<string, IEnumerable<SearchViewModel>>((text) => SearchAsync(text));
			SearchCommand.SubscribeOn(RxApp.MainThreadScheduler)
						 .Subscribe(x => SetSearchResult(x));

			this.WhenAnyValue(x => x.SearchText)
			    .Throttle(TimeSpan.FromMilliseconds(500), RxApp.MainThreadScheduler)
			    .Select(x => x?.Trim() ?? string.Empty)
			    .DistinctUntilChanged()
			    .InvokeCommand(SearchCommand);

			Observable.Merge(SearchCommand.ThrownExceptions)
					  .SubscribeOn(RxApp.MainThreadScheduler)
					  .Subscribe(ex => {
						  Debug.WriteLine(ex.Message);
					  });

			SearchSuggestionCommand = new Command<string>(OnSearchSuggestion);
		}

		/// <summary>
		/// Ons the search suggestion.
		/// </summary>
		/// <param name="query">Query.</param>
		void OnSearchSuggestion(string query)
		{
			SearchText = query;
		}

		/// <summary>
		/// Ons the search text changed.
		/// </summary>
		void OnSearchTextChanged()
		{
			Suggestions.Clear();
			Products.Clear();
		}

		/// <summary>
		/// Sets the search result.
		/// </summary>
		/// <param name="results">Results.</param>
		void SetSearchResult(IEnumerable<SearchViewModel> results)
		{
			Suggestions.AddRange(results.Where(x => x.ContainsSuggestion));
			Products.AddRange(results.Where(x => x.ContainsProduct));
		}

		/// <summary>
		/// Searchs the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="text">Text.</param>
		async Task<IEnumerable<SearchViewModel>> SearchAsync(string text)
		{
			var suggestions = await showcaseService.GetShowcaseProductSuggestionsByNameAsync(text, Priorities.UserInitiated).ConfigureAwait(false);
			var products = await showcaseService.GetShowcaseProductByNameAsync(text, Priorities.UserInitiated).ConfigureAwait(false);

			return suggestions.Select(x => new SearchViewModel(x)).Union(products.Select(x => new SearchViewModel(x)));
		}

		/// <summary>
		/// Gets or sets the search text.
		/// </summary>
		/// <value>The search text.</value>
		public string SearchText {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the search result items.
		/// </summary>
		/// <value>The search result items.</value>
		public IList<ObservableList<SearchViewModel>> SearchResultItems {
			get;
			set;
		}

		/// <summary>
		/// Gets the suggestions.
		/// </summary>
		/// <value>The suggestions.</value>
		public ObservableList<SearchViewModel> Suggestions {
			get {
				return SearchResultItems.First();
			}
		}

		/// <summary>
		/// Gets the products.
		/// </summary>
		/// <value>The products.</value>
		public ObservableList<SearchViewModel> Products {
			get {
				return SearchResultItems.Last();
			}
		}

		/// <summary>
		/// Gets the search command.
		/// </summary>
		/// <value>The search command.</value>
		public ReactiveCommand<string, IEnumerable<SearchViewModel>> SearchCommand {
			get;
			private set;
		}

		/// <summary>
		/// Gets the search suggestion command.
		/// </summary>
		/// <value>The search suggestion command.</value>
		public ICommand SearchSuggestionCommand {
			get;
			private set;
		}
	}
}