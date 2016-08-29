using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akavache;
using Mobishop.Domain.Products;
using Mobishop.Infrastructure.Framework.Logging;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Commons;
using Skahal.Infrastructure.Framework.Repositories;
using System.Reactive.Linq;
using Mobishop.Infrastructure.Repositories.Vtex.Mappers;
using Mobishop.Infrastructure.Repositories.Commons.Caching;

namespace Mobishop.Infrastructure.Repositories.Vtex.Products
{
    public class VtexProductRepository : RestRepositoryBase<Product, IVtexProductApi>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Mobishop.Infrastructure.Repositories.Vtex.Products.VtexProductRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of work.</param>
        public VtexProductRepository(IUnitOfWork unitOfWork = null) : base(unitOfWork)
        {
            ApiBaseAddress = "http://www.mambo.com.br/api/catalog_system/pub";
        }

        /// <summary>
        /// Finds the product by name async.
        /// </summary>
        /// <returns>The product.</returns>
        /// <param name="name">Name.</param>
        /// <param name="priority">Priority.</param>
        public async Task<IEnumerable<Product>> FindProductByNameAsync(string name, Priorities priority)
        {
            var entities = await Cache.GetAndFetchLatest(Logger.GetMethodSignature(parameters: name), () => FindProductByNameRemoteAsync(name, priority));

            var result = MapperHelper.ToDomainEntities(entities, new VtexProductMapper());

            return result;
        }

        async Task<IEnumerable<VtexProduct>> FindProductByNameRemoteAsync(string name, Priorities priority)
        {
            return await GetClientWithPriority(priority).FindProductsByName(name);
        }
    }
}