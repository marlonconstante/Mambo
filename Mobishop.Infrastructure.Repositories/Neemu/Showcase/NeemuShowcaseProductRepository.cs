using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Akavache;
using Mobishop.Domain.Products;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Logging;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Commons;
using Skahal.Infrastructure.Framework.Repositories;
using System.Reactive.Linq;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase
{
    public class NeemuShowcaseProductRepository : RestRepositoryBase<Product, INeemuShowcaseApi>, IShowcaseProductRepository
    {
        string m_searchCacheKey = "NeemuShowcaseProductRepository.Search({name})";


        public NeemuShowcaseProductRepository(IUnitOfWork unitOfWork = null) : base(unitOfWork)
        {
            ApiBaseAddress = "http://busca.mambo.com.br";
        }

        public async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await BlobCache.LocalMachine.GetAndFetchLatest(
                            string.Format(m_searchCacheKey, name),
                            async () => await FindShowcaseProductByNameRemoteAsync(name, priority),
                            offset =>
                            {
                                TimeSpan elapsed = DateTimeOffset.Now - offset;
                                return elapsed > new TimeSpan(0, 30, 0);
                            });
        }

        async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductByNameRemoteAsync(string name, Priorities priority = Priorities.Background)
        {
            return (await ExecuteApiRequest((arg) => GetClientWithPriority(priority).AutoComplete(name)))?.Products;
        }

        public async Task<IEnumerable<string>> FindShowcaseProductSugestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await BlobCache.LocalMachine.GetAndFetchLatest(
                    m_searchCacheKey,
                    async () => await FindShowcaseProductSugestionsByNameRemoteAsync(name, priority),
                    offset =>
                    {
                        TimeSpan elapsed = DateTimeOffset.Now - offset;
                        return elapsed > new TimeSpan(0, 30, 0);
                    });
        }

        async Task<IEnumerable<string>> FindShowcaseProductSugestionsByNameRemoteAsync(string name, Priorities priority = Priorities.Background)
        {
            return (await ExecuteApiRequest(() => GetClientWithPriority(priority).AutoComplete(name)))?.Suggestions;
        }

        Task<ShowcaseProduct> IRepository<ShowcaseProduct>.FindByAsync(object key, bool syncBeforeFind)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowcaseProduct>> FindAllAsync(int offset, int limit, Expression<Func<ShowcaseProduct, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowcaseProduct>> FindAllAscendingAsync<TOrderByKey>(int offset, int limit, Expression<Func<ShowcaseProduct, bool>> filter, Expression<Func<ShowcaseProduct, TOrderByKey>> orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowcaseProduct>> FindAllDescendingAsync<TOrderByKey>(int offset, int limit, Expression<Func<ShowcaseProduct, bool>> filter, Expression<Func<ShowcaseProduct, TOrderByKey>> orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAllAsync(Expression<Func<ShowcaseProduct, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(ShowcaseProduct item)
        {
            throw new NotImplementedException();
        }

        public Task<ShowcaseProduct> Attach(ShowcaseProduct entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ShowcaseProduct item)
        {
            throw new NotImplementedException();
        }
    }
}