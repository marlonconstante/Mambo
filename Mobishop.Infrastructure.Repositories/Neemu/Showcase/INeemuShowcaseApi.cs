using System;
using System.Threading.Tasks;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Commons;
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
        Task<NeemuSearchResult> AutoComplete(string query);
    }
}

