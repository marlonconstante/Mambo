using System;
using Mobishop.Infrastructure.Repositories.Commons;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.SuggestionSearch;

namespace Mobishop.Infrastructure.Repositories.Neemu.Mappers
{
    public class NeemuSearchSuggestionMapper : IMapper<string, NeemuSuggestion>
    {
        public string ToDomainEntity(NeemuSuggestion repositoryEntity)
        {
            if (repositoryEntity == null)
                return null;
            
            var result = repositoryEntity.Query;

            return result;
        }

        public NeemuSuggestion ToRepositoryEntity(string domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}
