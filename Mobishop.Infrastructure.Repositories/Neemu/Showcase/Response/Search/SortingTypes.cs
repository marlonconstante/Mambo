using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class SortingTypes
    {
        [JsonProperty("items")]
        public List<Item2> Items { get; set; }
    }
}

