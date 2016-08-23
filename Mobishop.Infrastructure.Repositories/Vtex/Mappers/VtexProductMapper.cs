using System;
using Mobishop.Domain.Products;
using Mobishop.Infrastructure.Repositories.Commons;

namespace Mobishop.Infrastructure.Repositories.Vtex.Mappers
{
    public class VtexProductMapper : IMapper<Product, VtexProduct>
    {
        public Product ToDomainEntity(VtexProduct repositoryEntity)
        {
            if (repositoryEntity == null)
                return null;
            
            var result = new Product()
            {
                Id = repositoryEntity.Id,
                Name = repositoryEntity.Name
            };

            return result;
        }

        public VtexProduct ToRepositoryEntity(Product domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}

