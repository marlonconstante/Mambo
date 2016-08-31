using System;
using Newtonsoft.Json;


namespace Mobishop.Infrastructure.Repositories.Chaordic.Showcase.Request
{
    public class Identity
    {
        [JsonProperty("browserId")]
        public string BrowserId { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("anonymousUserId")]
        public string AnonymousUserId { get; set; }
    }
}

