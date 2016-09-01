using System;
using System.Globalization;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Commons;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search;

namespace Mobishop.Infrastructure.Repositories.Neemu.Mappers
{
    public class NeemuShowcaseProductMapper : IMapper<ShowcaseProduct, Product>
    {
        public NeemuShowcaseProductMapper()
        {
        }

        public ShowcaseProduct ToDomainEntity(Product repositoryEntity)
        {
            if (repositoryEntity == null)
                return null;

            var ptBrCultureInfo = new CultureInfo("pt-BR");
            var enUsCultureInfo = new CultureInfo("en-US");

            var result = new ShowcaseProduct()
            {
                Id = repositoryEntity.Id,
                CurrentPrice = Double.Parse(repositoryEntity.Price, NumberStyles.Currency, ptBrCultureInfo),
                Description = "",
                ImageUrl = repositoryEntity.ImageUrl,
                Name = repositoryEntity.Name,
                PreviousPrice = Double.Parse(repositoryEntity.PriceRaw, NumberStyles.Currency, enUsCultureInfo),
            };

            return result;
        }

        public Product ToRepositoryEntity(ShowcaseProduct domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}

