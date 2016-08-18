using System.Collections.Generic;
using System.Threading.Tasks;
using Mobishop.Infrastructure.Framework.Repositories;
using Skahal.Infrastructure.Framework.Repositories;

namespace Mobishop.Domain.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> FindProductByNameAsync(string name, Priorities priority = Priorities.Background);
    }
}