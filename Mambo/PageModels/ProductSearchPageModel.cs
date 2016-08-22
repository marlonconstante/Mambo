using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using FreshMvvm;
using Mambo.ViewModels;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Collections;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.UI.Tasks;
using PropertyChanged;
using ReactiveUI;

namespace Mambo.PageModels
{
    /// <summary>
    /// Product search page model.
    /// </summary>
    [ImplementPropertyChanged]
    public class ProductSearchPageModel : FreshBasePageModel
    {
        /// <summary>
        /// The search milliseconds delay.
        /// </summary>
        const int SearchMillisecondsDelay = 500;

        /// <summary>
        /// The search service.
        /// </summary>
        ShowcaseService m_showcaseService;

        /// <summary>
        /// The search token source.
        /// </summary>
        CancellationTokenSource searchTokenSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Mambo.PageModels.ProductSearchPageModel"/> class.
        /// </summary>
        /// <param name="searchService">Search service.</param>
        public ProductSearchPageModel()
        {
            m_showcaseService = new ShowcaseService();

            SearchResultItems = new List<ObservableList<SearchViewModel>>();
            SearchResultItems.Add(new ObservableList<SearchViewModel>
            {
                GroupName = "Sugestões de Pesquisa"
            });
            SearchResultItems.Add(new ObservableList<SearchViewModel>
            {
                GroupName = "Produtos Sugeridos"
            });

            ShowSuggestionsCommand = ReactiveCommand.CreateFromTask<string, IEnumerable<SearchViewModel>>((arg1) => GetSuggestions(arg1));
            ShowSuggestionsCommand
                .SubscribeOn(RxApp.MainThreadScheduler)
                .Subscribe(l => AddSuggestionsToList(l));

            ShowProductsCommand = ReactiveCommand.CreateFromTask<string, IEnumerable<SearchViewModel>>((arg1) => GetProducts(arg1));
            ShowProductsCommand
                .SubscribeOn(RxApp.MainThreadScheduler)
                .Subscribe(l => AddProductsToList(l));

            this
                .WhenAnyValue(x => x.SearchText)
                .Throttle(TimeSpan.FromMilliseconds(400), RxApp.MainThreadScheduler)
                .Select(x => x?.Trim())
                .DistinctUntilChanged()
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .InvokeCommand(ShowSuggestionsCommand);

            this
                .WhenAnyValue(x => x.SearchText)
                .Throttle(TimeSpan.FromMilliseconds(800), RxApp.MainThreadScheduler)
                .Select(x => x?.Trim())
                .DistinctUntilChanged()
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .InvokeCommand(ShowProductsCommand);

            Observable
                .Merge(ShowSuggestionsCommand.ThrownExceptions, ShowProductsCommand.ThrownExceptions)
               .SubscribeOn(RxApp.MainThreadScheduler)
               .Subscribe(ex =>
               {
                   Debug.WriteLine(ex.Message);
               });

        }

        void AddSuggestionsToList(IEnumerable<SearchViewModel> suggestions)
        {
            Suggestions.Clear();
            Suggestions.AddRange(suggestions);
        }

        void AddProductsToList(IEnumerable<SearchViewModel> products)
        {
            Products.Clear();
            Products.AddRange(products);
        }

        async Task<IEnumerable<SearchViewModel>> GetSuggestions(string text)
        {
            var suggestions = await m_showcaseService.GetShowcaseProductSugestionsByNameAsync(text, Priorities.UserInitiated).ConfigureAwait(false);
            return suggestions.Select(s => new SearchViewModel(s));
        }

        async Task<IEnumerable<SearchViewModel>> GetProducts(string text)
        {
            var products = await m_showcaseService.GetShowcaseProductByNameAsync(text, Priorities.UserInitiated).ConfigureAwait(false);
            return products.Select(p => new SearchViewModel(p));
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
        /// Gets the show suggestions command.
        /// </summary>
        /// <value>The show suggestions command.</value>
        public ReactiveCommand<string, IEnumerable<SearchViewModel>> ShowSuggestionsCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the show products command.
        /// </summary>
        /// <value>The show products command.</value>
        public ReactiveCommand<string, IEnumerable<SearchViewModel>> ShowProductsCommand
        {
            get;
            private set;
        }
    }
}