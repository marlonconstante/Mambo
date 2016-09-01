using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class PaginationItem
    {
        [JsonProperty("hasPagination")]
        public int PageNumber { get; set; }

        [JsonProperty("hasPagination")]
        public bool IsFirst { get; set; }

        [JsonProperty("hasPagination")]
        public string Link { get; set; }

        [JsonProperty("hasPagination")]
        public bool Active { get; set; }

        [JsonProperty("hasPagination")]
        public bool? IsPrevious { get; set; }

        [JsonProperty("hasPagination")]
        public string Previous { get; set; }

        [JsonProperty("hasPagination")]
        public string Next { get; set; }

        [JsonProperty("hasPagination")]
        public bool? Selected { get; set; }

        [JsonProperty("hasPagination")]
        public bool? IsPageNumber { get; set; }

        [JsonProperty("hasPagination")]
        public bool? IsNext { get; set; }

        [JsonProperty("hasPagination")]
        public bool? IsLast { get; set; }
    }
}