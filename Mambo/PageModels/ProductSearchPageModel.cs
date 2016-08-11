using System.Threading;
using System.Windows.Input;
using FreshMvvm;
using Mambo.Services;
using PropertyChanged;

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
		}

		/// <summary>
		/// Ons the search text changed.
		/// </summary>
		public void OnSearchTextChanged()
		{
			System.Diagnostics.Debug.WriteLine(SearchText);
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