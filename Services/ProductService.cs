using System.Collections.Generic;
using System.Threading.Tasks;
using Mambo.Models;
using Mambo.Repositories.Vtex;

namespace Mambo.Services
{
	/// <summary>
	/// Product service.
	/// </summary>
	public class ProductService : VtexClient<IProductService>, IProductService
	{
		/// <summary>
		/// Searchs the products.
		/// </summary>
		/// <returns>The products.</returns>
		/// <param name="name">Name.</param>
		public Task<IList<Product>> SearchProducts(string name)
		{
			return Service.SearchProducts(name);
		}
	}
}