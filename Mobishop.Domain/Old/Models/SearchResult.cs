using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mambo.Models
{
	/// <summary>
	/// Search result.
	/// </summary>
	public class SearchResult
	{
		/// <summary>
		/// Gets or sets the suggestions.
		/// </summary>
		/// <value>The suggestions.</value>
		[JsonProperty("sugestoes")]
		public IList<Suggestion> Suggestions { get; set; }

		/// <summary>
		/// Gets or sets the products.
		/// </summary>
		/// <value>The products.</value>
		[JsonProperty("produtos")]
		public IList<ProductSuggestion> Products { get; set; }
	}
}