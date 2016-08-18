using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<IEnumerable<Product>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

