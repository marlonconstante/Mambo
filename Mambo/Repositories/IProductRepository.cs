using System.Collections.Generic;
using System.Threading.Tasks;
using Mambo.Models;
using Mambo.Vtex;
using Refit;

namespace Mambo.Repositories
{
	/// <summary>
	/// Product repository.
	/// </summary>
	public interface IProductRepository : IVtexRepository
	{
		/// <summary>
		/// Searchs the products.
		/// </summary>
		/// <returns>The products.</returns>
		/// <param name="name">Name.</param>
		[Get("/products/search/?fq=productName:{name}")]
		Task<IList<Product>> SearchProducts(string name);
	}
}