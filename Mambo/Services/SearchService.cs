using System.Threading.Tasks;
using Mambo.Models;
using Mambo.Neemu;
using Mambo.Repositories;
using Mobishop.Core.Caching;
using Mobishop.Core.Http;
using Mobishop.Core.Logging;

namespace Mambo.Services
{
	/// <summary>
	/// Search service.
	/// </summary>
	public class SearchService : NeemuClient<ISearchRepository>, ISearchService
	{
		/// <summary>
		/// Autos the complete.
		/// </summary>
		/// <returns>The complete.</returns>
		/// <param name="query">Query.</param>
		/// <param name="suggestionSize">Suggestion size.</param>
		/// <param name="productSize">Product size.</param>
		/// <param name="priority">Priority.</param>
		public Task<SearchResult> AutoComplete(string query, int suggestionSize, int productSize, PriorityRequest priority)
		{
			return Cached.GetValue(Logger.GetMethodSignature(parameters: new object[] { query, suggestionSize, productSize }), () => {
				return HttpHandler.Execute(() => GetRepository(priority).AutoComplete(query, suggestionSize, productSize));
			});
		}
	}
}