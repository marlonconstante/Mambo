using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaordic.Showcase.Request
{
    public class Page
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

