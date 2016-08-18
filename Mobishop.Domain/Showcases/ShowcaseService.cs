using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<IEnumerable<ShowcaseProduct>> GetShowcaseProductByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

