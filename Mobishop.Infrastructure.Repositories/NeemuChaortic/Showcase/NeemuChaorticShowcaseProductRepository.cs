using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Chaortic.Showcase;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase;
using Skahal.Infrastructure.Framework.Repositories;

namespace Mobishop.Infrastructure.Repositories.NeemuChaortic.Showcase
{
    public class NeemuChaorticShowcaseProductRepository : IShowcaseProductRepository
    {
        ChaordicShowcaseProductRepository m_chaorticRepository;
        NeemuShowcaseProductRepository m_neemuRepository;

        public NeemuChaorticShowcaseProductRepository(IUnitOfWork unitOfWork = null)
        {

            m_chaorticRepository = new ChaordicShowcaseProductRepository(unitOfWork);
            m_neemuRepository = new NeemuShowcaseProductRepository(unitOfWork);
            
        }

        public async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_neemuRepository.FindShowcaseProductByNameAsync(name, priority);
        }

        public async Task<IEnumerable<string>> FindShowcaseProductSuggestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_neemuRepository.FindShowcaseProductSuggestionsByNameAsync(name, priority);
        }

        public async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductsByShowcaseType(ShowcaseType showcaseType, Priorities priority = Priorities.Background)
        {
            return await m_chaorticRepository.FindShowcaseProductsByShowcaseType(showcaseType, priority);
        }


        #region Not Implemented
        public void Add(ShowcaseProduct item)
        {
            throw new NotImplementedException();
        }

        public Task<ShowcaseProduct> Attach(ShowcaseProduct entity)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAllAsync(Expression<Func<ShowcaseProduct, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowcaseProduct>> FindAllAscendingAsync<TOrderByKey>(int offset, int limit, Expression<Func<ShowcaseProduct, bool>> filter, Expression<Func<ShowcaseProduct, TOrderByKey>> orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowcaseProduct>> FindAllAsync(int offset, int limit, Expression<Func<ShowcaseProduct, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowcaseProduct>> FindAllDescendingAsync<TOrderByKey>(int offset, int limit, Expression<Func<ShowcaseProduct, bool>> filter, Expression<Func<ShowcaseProduct, TOrderByKey>> orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<ShowcaseProduct> FindByAsync(object key, bool syncBeforeFind = true)
        {
            throw new NotImplementedException();
        }

        public void Remove(ShowcaseProduct item)
        {
            throw new NotImplementedException();
        }

        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

