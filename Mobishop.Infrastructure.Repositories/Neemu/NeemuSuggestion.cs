﻿using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Neemu
{
    public class NeemuSuggestion
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>The query.</value>
        [JsonProperty("consulta")]
        public string Query { get; set; }

    }
}