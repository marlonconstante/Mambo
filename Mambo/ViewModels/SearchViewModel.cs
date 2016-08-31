using Mobishop.Domain.Showcases;
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
		public SearchViewModel(string suggestion)
		{
			Suggestion = suggestion;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.ViewModels.SearchViewModel"/> class.
		/// </summary>
		/// <param name="product">Product.</param>
		public SearchViewModel(ShowcaseProduct product)
		{
			Product = product;
		}

		/// <summary>
		/// Gets or sets the suggestion.
		/// </summary>
		/// <value>The suggestion.</value>
		public string Suggestion {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the product.
		/// </summary>
		/// <value>The product.</value>
		public ShowcaseProduct Product {
			get;
			set;
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Mambo.ViewModels.SearchViewModel"/> contains suggestion.
		/// </summary>
		/// <value><c>true</c> if contains suggestion; otherwise, <c>false</c>.</value>
		public bool ContainsSuggestion {
			get {
				return !string.IsNullOrWhiteSpace(Suggestion);
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Mambo.ViewModels.SearchViewModel"/> contains product.
		/// </summary>
		/// <value><c>true</c> if contains product; otherwise, <c>false</c>.</value>
		public bool ContainsProduct {
			get {
				return Product != null;
			}
		}
	}
}