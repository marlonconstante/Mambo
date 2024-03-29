﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobishop.Infrastructure.Framework.Repositories;
using Skahal.Infrastructure.Framework.Repositories;

namespace Mobishop.Domain.Showcases
{
    public interface IShowcaseProductRepository : IRepository<ShowcaseProduct>
    {
        Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductSuggestionsByNameAsync(string name, Priorities priority = Priorities.Background);
        Task<IEnumerable<string>> FindShowcaseProductNameSuggestionsByNameAsync(string name, Priorities priority = Priorities.Background);
        Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductsByShowcaseType(ShowcaseType showcaseType, Priorities priority = Priorities.Background);
        Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductByNameAsync(string name, Priorities priority = Priorities.Background);
    }
}