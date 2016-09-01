using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class PaginationItem
    {
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("isFirst")]
        public bool IsFirst { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("isPrevious")]
        public bool? IsPrevious { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("selected")]
        public bool? Selected { get; set; }

        [JsonProperty("isPageNumber")]
        public bool? IsPageNumber { get; set; }

        [JsonProperty("isNext")]
        public bool? IsNext { get; set; }

        [JsonProperty("isLast")]
        public bool? IsLast { get; set; }
    }
}