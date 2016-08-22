using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobishop.Infrastructure.Framework.Repositories;
using Splat;

namespace Mobishop.Domain.Products
{
    public class ProductService
    {
        IProductRepository m_productRepository;

        public ProductService(IProductRepository productRepository = null)
        {
            m_productRepository = productRepository ?? Locator.Current.GetService<IProductRepository>();
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_productRepository.FindProductByNameAsync(name, priority);
        }
    }
}

