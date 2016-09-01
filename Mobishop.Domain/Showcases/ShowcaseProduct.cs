using System;
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
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the previous price.
        /// </summary>
        /// <value>The previous price.</value>
        public double PreviousPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current price.
        /// </summary>
        /// <value>The current price.</value>
        public double CurrentPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        public string ImageUrl
        {
            get;
            set;
        }

        public string ToUpper()
        {
            throw new NotImplementedException();
        }
    }
}


