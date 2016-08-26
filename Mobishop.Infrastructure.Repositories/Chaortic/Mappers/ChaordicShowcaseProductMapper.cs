using System;
using System.Globalization;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Chaortic.Showcase.Response;
using Mobishop.Infrastructure.Repositories.Commons;

namespace Mobishop.Infrastructure.Repositories.Chaortic.Mappers
{
    public class ChaordicShowcaseProductMapper : IMapper<ShowcaseProduct, ChaorticRecommendation>
    {
        public ChaordicShowcaseProductMapper()
        {
        }

        public ShowcaseProduct ToDomainEntity(ChaorticRecommendation repositoryEntity)
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

        string GetImageForScreenSize(ChaorticRecommendation repositoryEntity)
        {
            return repositoryEntity.Images.ImageWith500x500;
        }

        public ChaorticRecommendation ToRepositoryEntity(ShowcaseProduct domainEntity)
        {
            throw new NotImplementedException();
        }
    }
}

