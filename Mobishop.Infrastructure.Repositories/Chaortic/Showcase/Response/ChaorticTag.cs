using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Response
{
    public class ChaorticTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        public ChaorticTag()
        {
        }
    }
}

