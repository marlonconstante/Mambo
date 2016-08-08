using System.Collections.Generic;
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
		/// Finds the suggestions.
		/// </summary>
		/// <returns>The suggestions.</returns>
		/// <param name="query">Query.</param>
		/// <param name="size">Size.</param>
		/// <param name="priority">Priority.</param>
		public Task<IList<Suggestion>> FindSuggestions(string query, int size, PriorityRequest priority)
		{
			return Cached.GetValue(Logger.GetMethodSignature(parameters: new object[] { query, size }), () => {
				return HttpHandler.Execute(() => GetRepository(priority).FindSuggestions(query, size));
			});
		}
	}
}