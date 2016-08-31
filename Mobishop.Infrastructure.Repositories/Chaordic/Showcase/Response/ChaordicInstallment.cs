using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaordic.Showcase.Response
{
    public class ChaordicInstallment
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        public ChaordicInstallment()
        {
        }
    }
}

