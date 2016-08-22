using System;
using Newtonsoft.Json;

namespace Mobishop.Infrastructure.Repositories.Vtex
{
    public class VtexProduct
    {
        public VtexProduct()
        {
        }

        [JsonProperty("productId")]
        override public long Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("productName")]
        public string Name
        {
            get;
            set;
        }
    }
}

