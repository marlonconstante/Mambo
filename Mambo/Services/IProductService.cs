using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mambo.Models;
using Mobishop.Core.Http;

namespace Mambo.Services
{
	/// <summary>
	/// Product service.
	/// </summary>
	public interface IProductService
	{
		/// <summary>
		/// Searchs the products.
		/// </summary>
		/// <returns>The products.</returns>
		/// <param name="name">Name.</param>
		/// <param name="token">Token.</param>
		/// <param name="priority">Priority.</param>
		Task<IList<Product>> SearchProducts(string name, CancellationToken token = default(CancellationToken), PriorityRequest priority = PriorityRequest.Intermediate);
	}
}