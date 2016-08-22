using Skahal.Infrastructure.Framework.Domain;

namespace Mobishop.Domain.Products
{
    public class Product : EntityWithIdBase<long>, IAggregateRoot
    {
        public Product()
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
    }
}

