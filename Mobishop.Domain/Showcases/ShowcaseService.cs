using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobishop.Infrastructure.Framework.Repositories;
using Splat;

namespace Mobishop.Domain.Showcases
{
    public class ShowcaseService
    {
        IShowcaseProductRepository m_showcaseProductRepository;

        public ShowcaseService(IShowcaseProductRepository showcaseProductRepository = null)
        {
            m_showcaseProductRepository = showcaseProductRepository ?? Locator.Current.GetService<IShowcaseProductRepository>();
        }

        public Task<IEnumerable<ShowcaseProduct>> GetShowcaseProductByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetShowcaseProductSugestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            throw new NotImplementedException();
        }

    }
}

