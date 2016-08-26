using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Commons;
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
            throw new NotImplementedException();
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

