﻿using System;
using System.Collections.Generic;
using Mobishop.Domain.Showcases;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu
{
    /// <summary>
    /// Search result.
    /// </summary>
    public class NeemuSearchResult
    {
        /// <summary>
        /// Gets or sets the suggestions.
        /// </summary>
        /// <value>The suggestions.</value>
        [JsonProperty("sugestoes.consulta")]
        public IList<string> Suggestions { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        [JsonProperty("produtos")]
        public IList<ShowcaseProduct> Products { get; set; }
    }
}

