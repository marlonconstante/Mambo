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
		/// <param name="token">Token.</param>
		/// <param name="priority">Priority.</param>
		Task<SearchResult> AutoComplete(string query, CancellationToken token = default(CancellationToken), PriorityRequest priority = PriorityRequest.Intermediate);
	}
}