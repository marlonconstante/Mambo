using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class ProductsInfo
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("protocolProductsList")]
        public string ProtocolProductsList { get; set; }

        [JsonProperty("recommendationProductList")]
        public string RecommendationProductList { get; set; }
    }
}

