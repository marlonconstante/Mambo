using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Response
{
    public class ChaorticDisplay
    {
        [JsonProperty("recs")]
        public List<ChaorticRecommendation> Recommendations { get; set; }

        public ChaorticDisplay()
        {  
        }
    }
}

