using System.Collections.Generic;
using System.Threading.Tasks;
using Mambo.Core.Http;
using Mambo.Models;
using Mambo.Repositories;
using Mambo.Repositories.Vtex;

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
			return GetRepository(priority).SearchProducts(name);
		}
	}
}