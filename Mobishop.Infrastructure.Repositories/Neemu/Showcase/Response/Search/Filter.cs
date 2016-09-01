using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class Filter
    {
        [JsonProperty("removeAllFiltersLink")]
        public string RemoveAllFiltersLink { get; set; }

        [JsonProperty("hasSelectedFilters")]
        public bool HasSelectedFilters { get; set; }

        [JsonProperty("selectedFilters")]
        public List<object> SelectedFilters { get; set; }

        [JsonProperty("filters")]
        public List<Filter2> Filters { get; set; }
    }
}

