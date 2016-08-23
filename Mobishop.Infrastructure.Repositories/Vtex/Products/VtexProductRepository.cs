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

namespace Mobishop.Infrastructure.Repositories.Vtex.Products
{
    public class VtexProductRepository : RestRepositoryBase<Product, IVtexProductApi>, IProductRepository
    {
        public VtexProductRepository(IUnitOfWork unitOfWork = null) : base(unitOfWork)
        {
            ApiBaseAddress = "http://www.mambo.com.br/api/catalog_system/pub";
        }

        public async Task<IEnumerable<Product>> FindProductByNameAsync(string name, Priorities priority)
        {
            var entities = await BlobCache.LocalMachine.GetAndFetchLatest(
                Logger.GetMethodSignature(parameters: name),
                async () => await FindProductByNameRemoteAsync(name, priority),
                 offset =>
                 {
                     TimeSpan elapsed = DateTimeOffset.Now - offset;
                     return elapsed > new TimeSpan(0, 30, 0);
                 }).FirstOrDefaultAsync();

            var result = MapperHelper.ToDomainEntities(entities, new VtexProductMapper());

            return result;
        }

        async Task<IEnumerable<VtexProduct>> FindProductByNameRemoteAsync(string name, Priorities priority)
        {
            return await GetClientWithPriority(priority).FindProductsByName(name);
        }
    }
}