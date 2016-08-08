using System.Threading.Tasks;
using Mambo.Models;
using Mobishop.Core.Http;

namespace Mambo.Services
{
	/// <summary>
	/// Search service.
	/// </summary>
	public interface ISearchService
	{
		/// <summary>
		/// Autos the complete.
		/// </summary>
		/// <returns>The complete.</returns>
		/// <param name="query">Query.</param>
		/// <param name="suggestionSize">Suggestion size.</param>
		/// <param name="productSize">Product size.</param>
		/// <param name="priority">Priority.</param>
		Task<SearchResult> AutoComplete(string query, int suggestionSize = 3, int productSize = 5, PriorityRequest priority = PriorityRequest.Intermediate);
	}
}