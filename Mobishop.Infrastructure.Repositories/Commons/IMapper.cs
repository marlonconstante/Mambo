using System;
namespace Mobishop.Infrastructure.Repositories.Commons
{
    public interface IMapper<TDomainEntity, TRepositoryEntity>
    {
        TDomainEntity ToDomainEntity(TRepositoryEntity repositoryEntity);
        TRepositoryEntity ToRepositoryEntity(TDomainEntity domainEntity);
    }
}

