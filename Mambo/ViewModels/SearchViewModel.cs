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
        public string Suggestion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public ShowcaseProduct Product
        {
            get;
            set;
        }
    }
}


