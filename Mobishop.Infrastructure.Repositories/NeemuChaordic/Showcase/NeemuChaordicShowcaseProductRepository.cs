using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Chaordic.Showcase;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase;
using Skahal.Infrastructure.Framework.Repositories;

namespace Mobishop.Infrastructure.Repositories.NeemuChaordic.Showcase
{
    public class NeemuChaordicShowcaseProductRepository : IShowcaseProductRepository
    {
        ChaordicShowcaseProductRepository m_chaordicRepository;
        NeemuShowcaseProductRepository m_neemuRepository;

        public NeemuChaordicShowcaseProductRepository(IUnitOfWork unitOfWork = null)
        {
            m_chaordicRepository = new ChaordicShowcaseProductRepository(unitOfWork);
            m_neemuRepository = new NeemuShowcaseProductRepository(unitOfWork);
            
        }

        public async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductSuggestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_neemuRepository.FindShowcaseProductSuggestionsByNameAsync(name, priority);
        }

        public async Task<IEnumerable<string>> FindShowcaseProductNameSuggestionsByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_neemuRepository.FindShowcaseProductNameSuggestionsByNameAsync(name, priority);
        }

        public async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductsByShowcaseType(ShowcaseType showcaseType, Priorities priority = Priorities.Background)
        {
            return await m_chaordicRepository.FindShowcaseProductsByShowcaseType(showcaseType, priority);
        }

        public async Task<IEnumerable<ShowcaseProduct>> FindShowcaseProductByNameAsync(string name, Priorities priority = Priorities.Background)
        {
            return await m_neemuRepository.FindShowcaseProductByNameAsync(name, priority);
        }


        #region Not Implemented
        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        public Task<ShowcaseProduct> FindByAsync(object key, bool syncBeforeFind = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowcaseProduct>> FindAllAsync(int offset, int limit, Expression<Func<ShowcaseProduct, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowcaseProduct>> FindAllAscendingAsync<TOrderByKey>(int offset, int limit, Expression<Func<ShowcaseProduct, bool>> filter, Expression<Func<ShowcaseProduct, TOrderByKey>> orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowcaseProduct>> FindAllDescendingAsync<TOrderByKey>(int offset, int limit, Expression<Func<ShowcaseProduct, bool>> filter, Expression<Func<ShowcaseProduct, TOrderByKey>> orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAllAsync(Expression<Func<ShowcaseProduct, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(ShowcaseProduct item)
        {
            throw new NotImplementedException();
        }

        public Task<ShowcaseProduct> Attach(ShowcaseProduct entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ShowcaseProduct item)
        {
            throw new NotImplementedException();
        }
        #endregion Not Implemented
    }
}

