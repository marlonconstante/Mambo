using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Akavache;
using Mobishop.Domain.Products;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Commons;
using Skahal.Infrastructure.Framework.Repositories;
using System.Reactive.Linq;
using System.Linq;
using Mobishop.Infrastructure.Repositories.Neemu.Mappers;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase
{
    public class NeemuShowcaseProductRepository : RestRepositoryBase<Product, INeemuShowcaseApi>, IShowcaseProductRepository
    {
        string m_searchCacheKey = "NeemuShowcaseProductRepository.Search-";


        public NeemuShowcaseProductRepository(IUnitOfWork unitOfWork = null) : base(unitOfWork)
        {
            ApiBaseAddress = "http://busca.mambo.com.br";
        }

        public async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            var searchResult = await BlobCache.LocalMachine.GetAndFetchLatest<NeemuSearchResult>(
                    string.Concat(m_searchCacheKey, name),
                    async () =>
                    {
                        return await FindSearchResultRemoteAsync(name, priority);
                    },
                    offset =>
                    {
                        TimeSpan elapsed = DateTimeOffset.Now - offset;
                        return elapsed > new TimeSpan(0, 30, 0);
                    }).FirstOrDefaultAsync();

            var result = MapperHelper.ToDomainEntities(searchResult?.Products, new NeemuShowcaseProductMapper());

            return result;
        }

        public async Task<IEnumerable<string>> FindShowcaseProductSugestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            var searchResult = await BlobCache.LocalMachine.GetAndFetchLatest(
                string.Concat(m_searchCacheKey, name),
                async () =>
                    {
                        return await FindSearchResultRemoteAsync(name, priority);
                    },
                    offset =>
                    {
                        TimeSpan elapsed = DateTimeOffset.Now - offset;
                        return elapsed > new TimeSpan(0, 30, 0);
                    }).FirstOrDefaultAsync();

            var result = MapperHelper.ToDomainEntities(searchResult?.Suggestions, new NeemuSearchSuggestionMapper());

            return result;
        }

        async Task<NeemuSearchResult> FindSearchResultRemoteAsync(string name, Priorities priority = Priorities.Background)
        {
            var results = await ExecuteApiRequest((arg) => GetClientWithPriority(priority).FindNeemuSearchResults(name));
            return results;
        }



        #region NotImplemented
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

        #endregion
    }
}