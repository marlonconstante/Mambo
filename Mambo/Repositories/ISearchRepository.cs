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
		/// Autos the complete.
		/// </summary>
		/// <returns>The complete.</returns>
		/// <param name="query">Query.</param>
		/// <param name="suggestionSize">Suggestion size.</param>
		/// <param name="productSize">Product size.</param>
		[Get("/autocomplete/search?q={query}&type=1&numsugestoes={suggestionSize}&numprods={productSize}")]
		Task<SearchResult> AutoComplete(string query, int suggestionSize, int productSize);
	}
}