using System.Collections.Generic;
using System.Threading.Tasks;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Commons;
using Mobishop.Infrastructure.Repositories.Commons.Caching;
using Mobishop.Infrastructure.Repositories.Neemu.Mappers;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.SuggestionSearch;
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

        public async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductSuggestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            var searchResult = await Cache.GetAndFetchLatest(GetCacheKey(name), () => FindSearchResultRemoteAsync(name, priority));

            var result = MapperHelper.ToDomainEntities(searchResult?.Products, new NeemuShowcaseProductMapper());

            return result;
        }

        public async Task<IEnumerable<string>> FindShowcaseProductNameSuggestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            var searchResult = await Cache.GetAndFetchLatest(GetCacheKey(name), () => FindSearchResultRemoteAsync(name, priority));

            var result = MapperHelper.ToDomainEntities(searchResult?.Suggestions, new NeemuSearchSuggestionMapper());

            return result;
        }

        string GetCacheKey(string name)
        {
            return string.Concat(m_searchCacheKey, name);
        }

        async Task<NeemuSuggestionSearchResult> FindSearchResultRemoteAsync(string name, Priorities priority = Priorities.Background)
        {
            var results = await ExecuteApiRequest((arg) => GetClientWithPriority(priority).FetchNeemuSearchResults(name));
            return results;
        }

        public async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            var searchResult = await Cache.GetAndFetchLatest(GetCacheKey(name), () => FindSearchResultRemoteAsync(name, priority));

            var result = MapperHelper.ToDomainEntities(searchResult?.Products, new NeemuShowcaseProductMapper());

            return result;
        }

        async Task<NeemuSuggestionSearchResult> FindShowcaseSearchResultRemoteAsync(string name, Priorities priority = Priorities.Background)
        {
            var results = await ExecuteApiRequest((arg) => GetClientWithPriority(priority).FetchNeemuSearchResults(name));
            return results;
        }

    }
}