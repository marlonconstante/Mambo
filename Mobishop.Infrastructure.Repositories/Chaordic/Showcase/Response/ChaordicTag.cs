using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaordic.Showcase.Response
{
    public class ChaordicTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        public ChaordicTag()
        {
        }
    }
}

