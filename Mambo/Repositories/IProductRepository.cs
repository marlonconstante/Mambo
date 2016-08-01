using System.Collections.Generic;
using System.Threading.Tasks;
using Mambo.Models;
using Mobishop.Core.Http;
using Refit;

namespace Mambo.Repositories
{
	/// <summary>
	/// Product repository.
	/// </summary>
	public interface IProductRepository : IRestRepository
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