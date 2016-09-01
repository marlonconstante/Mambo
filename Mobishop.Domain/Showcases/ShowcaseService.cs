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

        public async Task<IEnumerable<ShowcaseProduct>> GetShowcaseProductSuggestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_showcaseProductRepository.FindShowcaseProductSuggestionsByNameAsync(name, priority);
        }

        public async Task<IEnumerable<string>> GetShowcaseProductNameSuggestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_showcaseProductRepository.FindShowcaseProductNameSuggestionsByNameAsync(name, priority);
        }

        public async Task<IEnumerable<ShowcaseProduct>> GetShowcaseProductsByShowcaseType(ShowcaseType showcaseType, Priorities priority = Priorities.Background)
        {
            return await m_showcaseProductRepository.FindShowcaseProductsByShowcaseType(showcaseType, priority);
        }

        public async Task<IEnumerable<ShowcaseProduct>> GetShowcaseProductsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_showcaseProductRepository.FindShowcaseProductByNameAsync(name, priority);
        }
    }
}

