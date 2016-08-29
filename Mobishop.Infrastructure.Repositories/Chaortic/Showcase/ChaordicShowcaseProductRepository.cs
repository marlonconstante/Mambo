using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Logging;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Chaortic.Mappers;
using Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Response;
using Mobishop.Infrastructure.Repositories.Commons;
using Mobishop.Infrastructure.Repositories.Commons.Caching;
using Skahal.Infrastructure.Framework.Repositories;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Showcase
{
    public class ChaordicShowcaseProductRepository : RestRepositoryBase<ShowcaseProduct, IChaordicShowcaseApi>
    {
        public ChaordicShowcaseProductRepository(IUnitOfWork unitOfWork = null) : base(unitOfWork)
        {
            ApiBaseAddress = "https://onsite.chaordicsystems.com/v5/";
        }

        public async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductsByShowcaseType(ShowcaseType showcaseType, Priorities priority = Priorities.Background)
        {
            var response = await Cache.GetAndFetchLatest(Logger.GetMethodSignature(parameters: showcaseType), () => FindShowcaseProductsByShowcaseTypeRemoteAsync(showcaseType, priority));

            var result = MapperHelper.ToDomainEntities(response?.Displays.FirstOrDefault().Recommendations, new ChaordicShowcaseProductMapper());

            return result;
        }

        public async Task<ChaorticRootObject> FindShowcaseProductsByShowcaseTypeRemoteAsync(ShowcaseType showcaseType, Priorities priority = Priorities.Background)
        {
            var results = await ExecuteApiRequest((arg) => GetClientWithPriority(priority).FetchShowcase(GetResourceNameForShowcase(showcaseType), ChaordicQuery.Build()));

            return results;
        }

        string GetResourceNameForShowcase(ShowcaseType showcaseType)
        {
            var result = "mostPopular";
            switch (showcaseType)
            {
                case ShowcaseType.Offers:
                    result = "mostPopular";
                    break;

                case ShowcaseType.Special:
                    result = "mostPopular";
                    break;

            }

            return result;
        }

    }
}

