using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaordic.Showcase.Response
{
    public class ChaordicRootObject
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("feature")]
        public string Feature { get; set; }

        [JsonProperty("displays")]
        public List<ChaordicDisplay> Displays { get; set; }

        public ChaordicRootObject()
        {
        }
    }
}

