using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class ShowcaseProductSearchResult
    {
        [JsonProperty("searchInfo")]
        public SearchInfo SearchInfo { get; set; }

        [JsonProperty("productsInfo")]
        public ProductsInfo ProductsInfo { get; set; }

        [JsonProperty("resultsPerPage")]
        public ResultsPerPage ResultsPerPage { get; set; }

        [JsonProperty("sortingTypes")]
        public SortingTypes SortingTypes { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("quickFilter")]
        public QuickFilter QuickFilter { get; set; }

        [JsonProperty("filter")]
        public Filter Filter { get; set; }

        [JsonProperty("totalProducts")]
        public TotalProducts TotalProducts { get; set; }
    }
}

