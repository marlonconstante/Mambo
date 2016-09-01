using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class Item2
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }
    }
}

