using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaordic.Showcase.Response
{
    public class ChaordicCategory
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parents")]
        public List<string> Parents { get; set; }

        public ChaordicCategory()
        {
        }
    }
}

