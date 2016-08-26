using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Response
{
    public class ChaorticInstallment
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        public ChaorticInstallment()
        {
        }
    }
}

