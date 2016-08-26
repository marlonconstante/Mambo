using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Request
{
    public class Request
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("identity")]
        public Identity Identity { get; set; }

        [JsonProperty("page")]
        public Page Page { get; set; }
    }
}

