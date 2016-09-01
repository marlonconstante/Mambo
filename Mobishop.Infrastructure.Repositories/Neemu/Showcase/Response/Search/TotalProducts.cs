using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class TotalProducts
    {
        [JsonProperty("hasApproximatedResults")]
        public bool HasApproximatedResults { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }
    }
}

