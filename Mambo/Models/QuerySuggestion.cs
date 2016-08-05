using Newtonsoft.Json;

namespace Mambo.Models
{
	/// <summary>
	/// Query suggestion.
	/// </summary>
	public class QuerySuggestion
	{
		/// <summary>
		/// Gets or sets the query.
		/// </summary>
		/// <value>The query.</value>
		[JsonProperty("consulta")]
		public string Query { get; set; }
	}
}