using System.Collections.Generic;
using System.Threading.Tasks;
using Mambo.Models;
using Mambo.Neemu;
using Refit;

namespace Mambo.Repositories
{
	/// <summary>
	/// Search repository.
	/// </summary>
	public interface ISearchRepository : INeemuRepository
	{
		/// <summary>
		/// Finds the suggestions.
		/// </summary>
		/// <returns>The suggestions.</returns>
		/// <param name="query">Query.</param>
		/// <param name="size">Size.</param>
		[Get("/autocomplete/search?q={query}&type=1&numsugestoes={size}&numprods={size}")]
		Task<IList<Suggestion>> FindSuggestions(string query, int size = 5);
	}
}