using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobishop.Domain.Products;
using Mobishop.Infrastructure.Repositories.Commons;
using Refit;

namespace Mobishop.Infrastructure.Repositories.Vtex.Products
{
    public interface IVtexProductApi : IRestApiClient
    {
        //// <summary>
        /// Finds the products by name.
        /// </summary>
        /// <returns>The products.</returns>
        /// <param name="name">Name.</param>
        [Get("/products/search/?fq=productName:{name}")]
        Task<IEnumerable<Product>> FindProductsByName(string name);
    }
}