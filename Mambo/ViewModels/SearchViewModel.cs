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