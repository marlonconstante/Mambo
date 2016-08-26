using System;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Response;
using Mobishop.Infrastructure.Repositories.Commons;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Mappers
{
    public class ChaordicShowcaseProductMapper : IMapper<ShowcaseProduct, ChaorticRecommendation>
    {
        public ChaordicShowcaseProductMapper()
        {
        }

        public ShowcaseProduct ToDomainEntity(ChaorticRecommendation repositoryEntity)
        {
            throw new NotImplementedException();
        }

        public ChaorticRecommendation ToRepositoryEntity(ShowcaseProduct domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}

