using System;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Commons;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.SuggestionSearch;

namespace Mobishop.Infrastructure.Repositories.Neemu.Mappers
{
    public class NeemuSuggestionProductShowcaseProductMapper : IMapper<ShowcaseProduct, NeemuShowcaseProduct>
    {
        public ShowcaseProduct ToDomainEntity(NeemuShowcaseProduct repositoryEntity)
        {
            if (repositoryEntity == null)
                return null;
            
            var result = new ShowcaseProduct()
            {
                Id = repositoryEntity.Id,
                Name = repositoryEntity.Name,
                PreviousPrice = repositoryEntity.PreviousPrice,
                CurrentPrice = repositoryEntity.CurrentPrice,
                Description = repositoryEntity.Description,
                ImageUrl = repositoryEntity.ImageUrl
            };

            return result;
        }

        public NeemuShowcaseProduct ToRepositoryEntity(ShowcaseProduct domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
