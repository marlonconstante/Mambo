using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mambo.Models;
using Mambo.Repositories;
using Mambo.Vtex;
using Mobishop.Core.Caching;
using Mobishop.Core.Http;
using Mobishop.Core.Logging;

namespace Mambo.Services
{
	/// <summary>
	/// Product service.
	/// </summary>
	public class ProductService : VtexClient<IProductRepository>, IProductService
	{
		/// <summary>
		/// Searchs the products.
		/// </summary>
		/// <returns>The products.</returns>
		/// <param name="name">Name.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		/// <param name="priority">Priority.</param>
		public Task<IList<Product>> SearchProducts(string name, CancellationToken cancellationToken, PriorityRequest priority)
		{
			return Cached.GetValue(Logger.GetMethodSignature(parameters: name), () => {
				return HttpHandler.Execute((token) => GetRepository(priority).SearchProducts(name), cancellationToken);
			});
		}
	}
}