using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Response
{
    public class ChaorticImage
    {
        [JsonProperty("50x50")]
        public string ImageWith50x50 { get; set; }

        [JsonProperty("70x70")]
        public string ImageWith70x70 { get; set; }

        [JsonProperty("128x128")]
        public string ImageWith128x128 { get; set; }

        [JsonProperty("230x230")]
        public string ImageWith230x230 { get; set; }

        [JsonProperty("340x340")]
        public string ImageWith340x340 { get; set; }

        [JsonProperty("500x500")]
        public string ImageWith500x500 { get; set; }

        public ChaorticImage()
        {
        }
    }
}

