using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class SearchInfo
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("number_of_results")]
        public int NumberOfResults { get; set; }

        [JsonProperty("processing_time")]
        public int ProcessingTime { get; set; }

        [JsonProperty("suggested_query")]
        public int SuggestedQuery { get; set; }

        [JsonProperty("number_of_and_results")]
        public int NumberOfAndResults { get; set; }

        [JsonProperty("query_correction")]
        public int QueryCorrection { get; set; }

        [JsonProperty("cache_use")]
        public int CacheUse { get; set; }

        [JsonProperty("qOriginal")]
        public string QOriginal { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("page_type")]
        public string PageType { get; set; }
    }
}

