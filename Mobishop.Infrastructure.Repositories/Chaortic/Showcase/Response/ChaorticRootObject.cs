using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Response
{
    public class ChaorticRootObject
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("feature")]
        public string Feature { get; set; }

        [JsonProperty("displays")]
        public List<ChaorticDisplay> Displays { get; set; }

        public ChaorticRootObject()
        {
        }
    }
}

