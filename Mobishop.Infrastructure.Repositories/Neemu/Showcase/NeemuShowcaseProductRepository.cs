using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Commons;
using Mobishop.Infrastructure.Repositories.Neemu.Mappers;
using Skahal.Infrastructure.Framework.Repositories;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase
{
    public class NeemuShowcaseProductRepository : RestRepositoryBase<ShowcaseProduct, INeemuShowcaseApi>
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

    }
}