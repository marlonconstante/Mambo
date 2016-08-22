using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mobishop.Domain.Products;
using Mobishop.Infrastructure.Framework.Repositories;
using Skahal.Infrastructure.Framework.Repositories;


namespace Mobishop.Infrastructure.Repositories.Memory
{
    public class MemoryProductRepository : MemoryRepository<Product>, IProductRepository
    {
        #region Fields

        private static long s_lastKey;

        #endregion

        public MemoryProductRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, u =>
            {
                ++s_lastKey;
                return s_lastKey.ToString();
            })
        {
            s_lastKey = 0;
        }

        public Task<IEnumerable<Product>> FindProductByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            IEnumerable<Product> results = new List<Product>();
            results = Entities.Where(p => p.Name.Contains(name) && !string.IsNullOrWhiteSpace(name));

            return Task.FromResult(results);
        }
    }
}