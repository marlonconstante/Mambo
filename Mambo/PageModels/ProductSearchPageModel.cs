using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Collections;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.UI.Tasks;
using PropertyChanged;
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
        /// The search milliseconds delay.
        /// </summary>
        const int SearchMillisecondsDelay = 500;

        /// <summary>
        /// The search token source.
        /// </summary>
        CancellationTokenSource searchTokenSource;

        ShowcaseService m_showcaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Mambo.PageModels.ProductSearchPageModel"/> class.
        /// </summary>
        /// <param name="searchService">Search service.</param>
        public ProductSearchPageModel()
        {
            m_showcaseService = new ShowcaseService();
            searchTokenSource = new CancellationTokenSource();

            //SearchResultItems = new List<ObservableList<SearchViewModel>>();
            //SearchResultItems.Add(new ObservableList<SearchViewModel>());
            //SearchResultItems.Add(new ObservableList<SearchViewModel>
            //{
            //    GroupName = "Produtos Sugeridos"
            //});

            SearchCommand = new Command(OnSearchTextChanged);
        }

        /// <summary>
        /// Ons the search text changed.
        /// </summary>
        public async void OnSearchTextChanged()
        {
            await UITaskHandler.Execute(() => SearchProducts(SearchText));
        }

        /// <summary>
        /// Searchs the products.
        /// </summary>
        /// <returns>The products.</returns>
        /// <param name="text">Text.</param>
        async Task SearchProducts(string text)
        {
            try
            {
                Suggestions.Clear();
                Products.Clear();

                Interlocked.Exchange(ref searchTokenSource, new CancellationTokenSource()).Cancel();

                await Task.Delay(SearchMillisecondsDelay, searchTokenSource.Token).ConfigureAwait(false);
                if (!searchTokenSource.IsCancellationRequested)
                {
                    // Pesquisando produto
                    var showcaseProducts = await m_showcaseService.GetShowcaseProductByNameAsync(text, Priorities.UserInitiated).ConfigureAwait(false);
                    var suggestions = await m_showcaseService.GetShowcaseProductSugestionsByNameAsync(text, Priorities.UserInitiated).ConfigureAwait(false);

                    Suggestions.AddRange(suggestions);
                    Products.AddRange(showcaseProducts);
                }
            }
            catch (TaskCanceledException)
            {
                // Pesquisa cancelada...
            }
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

        ///// <summary>
        ///// Gets or sets the search result items.
        ///// </summary>
        ///// <value>The search result items.</value>
        //public IList<ObservableList<SearchViewModel>> SearchResultItems
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Gets the suggestions.
        /// </summary>
        /// <value>The suggestions.</value>
        public ObservableList<string> Suggestions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        public ObservableList<ShowcaseProduct> Products
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the search command.
        /// </summary>
        /// <value>The search command.</value>
        public ICommand SearchCommand
        {
            get;
            private set;
        }
    }
}