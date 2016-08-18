using System.Threading;
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
		/// <param name="cancellationToken">Cancellation token.</param>
		/// <param name="priority">Priority.</param>
		Task<SearchResult> AutoComplete(string query, CancellationToken cancellationToken = default(CancellationToken), PriorityRequest priority = PriorityRequest.Intermediate);
	}
}