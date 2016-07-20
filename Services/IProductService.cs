using System.Collections.Generic;
using System.Threading.Tasks;
using Mambo.Core.Http;
using Mambo.Models;
using Refit;

namespace Mambo.Services
{
	/// <summary>
	/// Product service.
	/// </summary>
	public interface IProductService : IRestService
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