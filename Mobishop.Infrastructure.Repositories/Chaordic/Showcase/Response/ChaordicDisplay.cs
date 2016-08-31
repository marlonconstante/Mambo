using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaordic.Showcase.Response
{
    public class ChaordicDisplay
    {
        [JsonProperty("recs")]
        public List<ChaordicRecommendation> Recommendations { get; set; }

        public ChaordicDisplay()
        {  
        }
    }
}

