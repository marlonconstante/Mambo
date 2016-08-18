using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Domain.Showcases
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
		[JsonProperty("sugestoes.consulta")]
        public IList<string> Suggestions { get; set; }

		/// <summary>
		/// Gets or sets the products.
		/// </summary>
		/// <value>The products.</value>
		[JsonProperty("produtos")]
        public IList<ShowcaseProduct> Products { get; set; }
	}
}