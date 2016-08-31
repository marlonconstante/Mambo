using System;
using System.Globalization;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Chaordic.Showcase.Response;
using Mobishop.Infrastructure.Repositories.Commons;

namespace Mobishop.Infrastructure.Repositories.Chaordic.Mappers
{
    public class ChaordicShowcaseProductMapper : IMapper<ShowcaseProduct, ChaordicRecommendation>
    {
        public ChaordicShowcaseProductMapper()
        {
        }

        public ShowcaseProduct ToDomainEntity(ChaordicRecommendation repositoryEntity)
        {
            if (repositoryEntity == null)
                return null;

            var ci = new CultureInfo("pt-BR");

            var result = new ShowcaseProduct()
            {
                Id = Convert.ToInt64(repositoryEntity.Id),
                CurrentPrice = Double.Parse(repositoryEntity.Price, System.Globalization.NumberStyles.Currency, ci),
                Description = repositoryEntity.Name,
                Name = repositoryEntity.Name,
                ImageUrl = GetImageForScreenSize(repositoryEntity),
                PreviousPrice = Double.Parse(repositoryEntity.OldPrice, System.Globalization.NumberStyles.Currency, ci),
            };

            return result;
        }

        string GetImageForScreenSize(ChaordicRecommendation repositoryEntity)
        {
            return repositoryEntity.Images.ImageWith500x500;
        }

        public ChaordicRecommendation ToRepositoryEntity(ShowcaseProduct domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}

