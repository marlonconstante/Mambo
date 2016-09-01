using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class QuickFilter
    {
        [JsonProperty("termsQty")]
        public int termsQuantity { get; set; }

        [JsonProperty("terms")]
        public List<object> Terms { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

