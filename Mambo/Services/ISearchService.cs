using System.Collections.Generic;
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
		/// Finds the suggestions.
		/// </summary>
		/// <returns>The suggestions.</returns>
		/// <param name="query">Query.</param>
		/// <param name="size">Size.</param>
		/// <param name="priority">Priority.</param>
		Task<IList<Suggestion>> FindSuggestions(string query, int size = 5, PriorityRequest priority = PriorityRequest.Intermediate);
	}
}