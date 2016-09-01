using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class Pagination
    {
        [JsonProperty("paginationItems")]
        public List<PaginationItem> PaginationItems { get; set; }

        [JsonProperty("numberOfPages")]
        public int NumberOfPages { get; set; }

        [JsonProperty("hasPagination")]
        public bool HasPagination { get; set; }
    }
}

