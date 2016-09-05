using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Mambo.Utils;
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
    public class ProductSearchPageModel : PageModelBase
    {
        /// <summary>
        /// The showcase service.
        /// </summary>
        ShowcaseService showcaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Mambo.PageModels.ProductSearchPageModel"/> class.
        /// </summary>
        public ProductSearchPageModel(IUserDialogsService userDialogService = null) : base(userDialogService)
        {
            showcaseService = new ShowcaseService();

            SearchResultItems = new List<ObservableList<SearchViewModel>>();
            SearchResultItems.Add(new ObservableList<SearchViewModel>
            {
                GroupName = "Sugestões de Pesquisa"
            });
            SearchResultItems.Add(new ObservableList<SearchViewModel>
            {
                GroupName = "Produtos Sugeridos"
            });

            SearchCommand = ReactiveCommand.CreateFromTask<string, IEnumerable<SearchViewModel>>((text) => SearchAsync(text));
            SearchCommand.SubscribeOn(RxApp.MainThreadScheduler)
                         .Subscribe(x => SetSearchResult(x))
                         .DisposeWith(subscriptionDisposables);

            this.WhenAnyValue(x => x.SearchText)
                .Throttle(TimeSpan.FromMilliseconds(500), RxApp.MainThreadScheduler)
                .Select(x => x?.Trim())
                .Where(x => x != null)
                .DistinctUntilChanged()
                .InvokeCommand(SearchCommand)
                 .DisposeWith(subscriptionDisposables);

            Observable.Merge(SearchCommand.ThrownExceptions)
                      .SubscribeOn(RxApp.MainThreadScheduler)
                      .Subscribe(ex =>
                      {
                          Dialogs.ShowError(ex.Message);
                      })
                      .DisposeWith(subscriptionDisposables);

            SearchSuggestionCommand = new Command<string>(async (q) => await OnSearchSuggestion(q));
            SelectProductCommand = new Command<ShowcaseProduct>(async (p) => await OnProductSelect(p));
        }

        /// <summary>
        /// Ons the product select.
        /// </summary>
        /// <returns>The product select.</returns>
        /// <param name="product">Product.</param>
        async Task OnProductSelect(ShowcaseProduct product)
        {
            await CoreMethods.PushPageModel<ProductDetailsPageModel>(product);
        }

        /// <summary>
        /// Ons the search suggestion.
        /// </summary>
        /// <param name="query">Query.</param>
        async Task OnSearchSuggestion(string query)
        {
            await CoreMethods.PushPageModel<ProductSearchGridResultPageModel>(query);
        }

        /// <summary>
        /// Sets the search result.
        /// </summary>
        /// <param name="results">Results.</param>
        void SetSearchResult(IEnumerable<SearchViewModel> results)
        {
            Suggestions.Clear();
            Suggestions.AddRange(results.Where(x => x.ContainsSuggestion));

            Products.Clear();
            Products.AddRange(results.Where(x => x.ContainsProduct));
        }

        /// <summary>
        /// Searchs the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="text">Text.</param>
        async Task<IEnumerable<SearchViewModel>> SearchAsync(string text)
        {
            var suggestions = await showcaseService.GetShowcaseProductNameSuggestionsByNameAsync(text, Priorities.UserInitiated).ConfigureAwait(false);
            var products = await showcaseService.GetShowcaseProductSuggestionsByNameAsync(text, Priorities.UserInitiated).ConfigureAwait(false);

            return suggestions.Select(x => new SearchViewModel(x)).Union(products.Select(x => new SearchViewModel(x)));
        }

        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        /// <value>The search text.</value>
        public string SearchText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the search result items.
        /// </summary>
        /// <value>The search result items.</value>
        public IList<ObservableList<SearchViewModel>> SearchResultItems
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the suggestions.
        /// </summary>
        /// <value>The suggestions.</value>
        public ObservableList<SearchViewModel> Suggestions
        {
            get
            {
                return SearchResultItems.First();
            }
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        public ObservableList<SearchViewModel> Products
        {
            get
            {
                return SearchResultItems.Last();
            }
        }

        /// <summary>
        /// Gets the search command.
        /// </summary>
        /// <value>The search command.</value>
        public ReactiveCommand<string, IEnumerable<SearchViewModel>> SearchCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the search suggestion command.
        /// </summary>
        /// <value>The search suggestion command.</value>
        public ICommand SearchSuggestionCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the select product command.
        /// </summary>
        /// <value>The select product command.</value>
        public ICommand SelectProductCommand
        {
            get;
            private set;
        }
    }
}