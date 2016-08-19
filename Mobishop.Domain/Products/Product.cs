using System;
using Newtonsoft.Json;
using Skahal.Infrastructure.Framework.Domain;

namespace Mobishop.Domain.Products
{
    public class Product : EntityWithIdBase<long>, IAggregateRoot
    {
        public Product()
        {
        }

        [JsonProperty("productId")]
        override public long Id
        {
            get;
            set;
        }

        //public object Key
        //{
        //    get
        //    {
        //        return Id;
        //    }

        //    set
        //    {
        //        Id = (long)value;
        //    }
        //}

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

