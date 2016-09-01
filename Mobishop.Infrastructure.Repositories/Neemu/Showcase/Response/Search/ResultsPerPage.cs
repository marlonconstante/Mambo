using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class ResultsPerPage
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}

