using Newtonsoft.Json;

namespace Mambo.Models
{
	/// <summary>
	/// Suggestion.
	/// </summary>
	public class Suggestion
	{
		/// <summary>
		/// Gets or sets the query.
		/// </summary>
		/// <value>The query.</value>
		[JsonProperty("consulta")]
		public string Query { get; set; }
	}
}