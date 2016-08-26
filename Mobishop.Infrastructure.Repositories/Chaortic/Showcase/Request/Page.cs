using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Request
{
    public class Page
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

