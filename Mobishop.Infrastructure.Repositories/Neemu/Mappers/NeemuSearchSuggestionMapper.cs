using System;
using Mobishop.Infrastructure.Repositories.Commons;

namespace Mobishop.Infrastructure.Repositories.Neemu.Mappers
{
    public class NeemuSearchSuggestionMapper : IMapper<string, NeemuSearchResult>
    {
        public NeemuSearchSuggestionMapper()
        {
        }

        public string ToDomainEntity(NeemuSearchResult repositoryEntity)
        {
            throw new NotImplementedException();
        }

        public NeemuSearchResult ToRepositoryEntity(string domainEntity)
        {
            throw new NotImplementedException();
        }
    }

