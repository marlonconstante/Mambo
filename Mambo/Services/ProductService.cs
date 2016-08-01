using System.Collections.Generic;
using System.Threading.Tasks;
using Mambo.Models;
using Mambo.Repositories;
using Mobishop.Core.Caching;
using Mobishop.Core.Http;
using Mobishop.Core.Logging;
using Mobishop.Core.Vtex;

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
		/// <param name="priority">Priority.</param>
		public Task<IList<Product>> SearchProducts(string name, PriorityRequest priority)
		{
			return Cached.GetValue(Logger.GetMethodSignature(parameters: name), () => {
				return HttpHandler.Execute(() => GetRepository(priority).SearchProducts(name));
			});
		}
	}
}