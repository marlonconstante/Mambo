using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Response
{
    public class ChaorticRecommendation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("images")]
        public ChaorticImage Images { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("categories")]
        public List<ChaorticCategory> Categories { get; set; }

        [JsonProperty("installment")]
        public ChaorticInstallment Installment { get; set; }

        [JsonProperty("oldPrice")]
        public string OldPrice { get; set; }

        [JsonProperty("tags")]
        public List<ChaorticTag> Tags { get; set; }

        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("daysOnTop")]
        public string DaysOnTop { get; set; }

        [JsonProperty("tendency")]
        public string Tendency { get; set; }

        [JsonProperty("similarityWeight")]
        public double SimilarityWeight { get; set; }

        public ChaorticRecommendation()
        {
        }
    }
}

