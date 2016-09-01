using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.SuggestionSearch
{
    /// <summary>
    /// Search result.
    /// </summary>
    public class NeemuSuggestionSearchResult
    {
        /// <summary>
        /// Gets or sets the suggestions.
        /// </summary>
        /// <value>The suggestions.</value>
        [JsonProperty("sugestoes")]
        public IList<NeemuSuggestion> Suggestions { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        [JsonProperty("produtos")]
        public IList<NeemuShowcaseProduct> Products { get; set; }
    }
}

