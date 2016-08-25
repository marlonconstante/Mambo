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

        public async Task<IEnumerable<ShowcaseProduct>> GetShowcaseProductByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_showcaseProductRepository.FindShowcaseProductByNameAsync(name, priority);
        }

        public async Task<IEnumerable<string>> GetShowcaseProductSugestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_showcaseProductRepository.FindShowcaseProductSugestionsByNameAsync(name, priority);
        }

        public async Task<IEnumerable<ShowcaseProduct>> GetShowcaseProductsByShowcaseType(ShowcaseType showcaseType, Priorities priority = Priorities.Background)
        {
            throw new NotImplementedException();
        }
    }
}

