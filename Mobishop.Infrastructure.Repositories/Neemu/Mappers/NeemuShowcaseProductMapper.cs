using System;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Commons;

namespace Mobishop.Infrastructure.Repositories.Neemu.Mappers
{
    public class NeemuShowcaseProductMapper : IMapper<ShowcaseProduct, NeemuSearchResult>
    {
        public NeemuShowcaseProductMapper()
        {
        }

        public ShowcaseProduct ToDomainEntity(NeemuSearchResult repositoryEntity)
        {
            throw new NotImplementedException();
        }

        public NeemuSearchResult ToRepositoryEntity(ShowcaseProduct domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}

