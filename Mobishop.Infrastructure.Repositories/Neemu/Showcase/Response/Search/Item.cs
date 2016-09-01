using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class Item
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }
    }
}

