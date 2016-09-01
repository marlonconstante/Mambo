using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class Filter2
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tipo")]
        public string Type { get; set; }

        [JsonProperty("selecionados")]
        public List<object> Selecteds { get; set; }

        [JsonProperty("lvalores")]
        public List<Lvalore> LValores { get; set; }

        [JsonProperty("normalizedName")]
        public string NormalizedName { get; set; }

        [JsonProperty("isCategory")]
        public bool IsCategory { get; set; }

        [JsonProperty("isColor")]
        public bool? IsColor { get; set; }

        [JsonProperty("hasSelectedFilters")]
        public bool? HasSelectedFilters { get; set; }

        [JsonProperty("linkRemoveFilter")]
        public string LinkRemoveFilter { get; set; }

        [JsonProperty("isDefault")]
        public bool? IsDefault { get; set; }

        [JsonProperty("range")]
        public List<Range> Ranges { get; set; }

        [JsonProperty("unityup")]
        public string Unityup { get; set; }

        [JsonProperty("isPrice")]
        public bool? IsPrice { get; set; }

        [JsonProperty("isSize")]
        public bool? IsSize { get; set; }
    }
}

