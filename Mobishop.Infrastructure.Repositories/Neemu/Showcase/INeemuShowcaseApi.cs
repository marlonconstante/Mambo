using System.Threading.Tasks;
using Mobishop.Infrastructure.Repositories.Commons;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.SuggestionSearch;
using Refit;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase
{
    public interface INeemuShowcaseApi : IRestApiClient
    {
        /// <summary>
        /// Autos the complete.
        /// </summary>
        /// <returns>The complete.</returns>
        /// <param name="query">Query.</param>
        [Get("/autocomplete/search?q={query}&type=1")]
        Task<NeemuSuggestionSearchResult> FetchNeemuSuggestionSearchResults(string query);

        [Get("/api/search?q={query}")]
        Task<ShowcaseProductSearchResult> FetchNeemuSearchResults(string query);
    }
}

