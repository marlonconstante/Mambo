using System;
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

        public Task<Product> FindProductByName(string name, Priorities priority = Priorities.Background)
        {
            throw new NotImplementedException();
        }
    }
}