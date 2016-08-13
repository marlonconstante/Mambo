using Mambo.Models;
using PropertyChanged;

namespace Mambo.ViewModels
{
	/// <summary>
	/// Search view model.
	/// </summary>
	[ImplementPropertyChanged]
	public class SearchViewModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.ViewModels.SearchViewModel"/> class.
		/// </summary>
		public SearchViewModel()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.ViewModels.SearchViewModel"/> class.
		/// </summary>
		/// <param name="suggestion">Suggestion.</param>
		public SearchViewModel(Suggestion suggestion)
		{
			Suggestion = suggestion;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.ViewModels.SearchViewModel"/> class.
		/// </summary>
		/// <param name="product">Product.</param>
		public SearchViewModel(ProductSuggestion product)
		{
			Product = product;
		}

		/// <summary>
		/// Gets or sets the suggestion.
		/// </summary>
		/// <value>The suggestion.</value>
		public Suggestion Suggestion {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the product.
		/// </summary>
		/// <value>The product.</value>
		public ProductSuggestion Product {
			get;
			set;
		}
	}
}