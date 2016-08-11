using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Mambo.Services;
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
		/// The search service.
		/// </summary>
		ISearchService searchService;

		/// <summary>
		/// The search token source.
		/// </summary>
		CancellationTokenSource searchTokenSource;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.PageModels.ProductSearchPageModel"/> class.
		/// </summary>
		/// <param name="searchService">Search service.</param>
		public ProductSearchPageModel(ISearchService searchService)
		{
			this.searchService = searchService;

			searchTokenSource = new CancellationTokenSource();
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
				Interlocked.Exchange(ref searchTokenSource, new CancellationTokenSource()).Cancel();

				await Task.Delay(SearchMillisecondsDelay, searchTokenSource.Token).ConfigureAwait(false);
				if (!searchTokenSource.IsCancellationRequested)
				{
					// Pesquisando produto
					var result = await searchService.AutoComplete(text, searchTokenSource.Token).ConfigureAwait(false);
					if (result != null)
					{

					}
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
		public string SearchText {
			get;
			set;
		}

		/// <summary>
		/// Gets the search command.
		/// </summary>
		/// <value>The search command.</value>
		public ICommand SearchCommand {
			get;
			private set;
		}
	}
}