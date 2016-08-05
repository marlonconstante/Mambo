using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mambo.Models
{
	/// <summary>
	/// Suggestion.
	/// </summary>
	public class Suggestion
	{
		/// <summary>
		/// Gets or sets the queries.
		/// </summary>
		/// <value>The queries.</value>
		[JsonProperty("sugestoes")]
		public IList<QuerySuggestion> Queries { get; set; }

		/// <summary>
		/// Gets or sets the products.
		/// </summary>
		/// <value>The products.</value>
		[JsonProperty("produtos")]
		public IList<ProductSuggestion> Products { get; set; }
	}
}