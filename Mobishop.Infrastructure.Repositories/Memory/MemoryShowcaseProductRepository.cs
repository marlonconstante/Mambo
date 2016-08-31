using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Repositories;
using Skahal.Infrastructure.Framework.Repositories;

namespace Mobishop.Infrastructure.Repositories.Memory
{
    public class MemoryShowcaseProductRepository : MemoryRepository<ShowcaseProduct>, IShowcaseProductRepository
    {
        #region Fields

        private static long s_lastKey;

        #endregion

        public MemoryShowcaseProductRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, u =>
            {
                ++s_lastKey;
                return s_lastKey.ToString();
            })
        {
            s_lastKey = 0;
        }

        public Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            IEnumerable<ShowcaseProduct> results = new List<ShowcaseProduct>();
            results = Entities.Where(p => p.Name.Contains(name) && !string.IsNullOrWhiteSpace(name));

            return Task.FromResult(results);
        }

        public Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductsByShowcaseType(ShowcaseType showcaseType, Priorities priority = Priorities.Background)
        {
            var results = new List<ShowcaseProduct>();

            if (showcaseType == ShowcaseType.Offers)
            {
                for (int i = 0; i < 6; i++)
                {
                    var prod = new ShowcaseProduct()
                    {
                        Id = i,
                        CurrentPrice = i,
                        Description = $"Description {i}",
                        ImageUrl = $"ImageURL/{i}",
                        Name = $"Name {i}",
                        PreviousPrice = i
                    };
                    results.Add(prod);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    var prod = new ShowcaseProduct()
                    {
                        Id = i,
                        CurrentPrice = i,
                        Description = $"Description {i}",
                        ImageUrl = $"ImageURL/{i}",
                        Name = $"Name {i}",
                        PreviousPrice = i
                    };
                    results.Add(prod);
                }
            }

            return Task.FromResult((IEnumerable<ShowcaseProduct>)results);
        }

        public Task<IEnumerable<string>> FindShowcaseProductSuggestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            IList<string> results = new List<string>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                results.Add(name);

                results.Add("Suggestion 1");
            }

            return Task.FromResult((IEnumerable<string>)results);
        }
    }
}