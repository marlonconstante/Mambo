using System;
using Newtonsoft.Json;
using Skahal.Infrastructure.Framework.Domain;

namespace Mobishop.Domain.Showcases
{
    public class ShowcaseProduct : EntityWithIdBase<long>, IAggregateRoot
    {
        public ShowcaseProduct()
        {
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

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("descricao")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the previous price.
        /// </summary>
        /// <value>The previous price.</value>
        [JsonProperty("de")]
        public double PreviousPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current price.
        /// </summary>
        /// <value>The current price.</value>
        [JsonProperty("preco")]
        public double CurrentPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        [JsonProperty("imagem")]
        public string ImageUrl
        {
            get;
            set;
        }
    }
}


