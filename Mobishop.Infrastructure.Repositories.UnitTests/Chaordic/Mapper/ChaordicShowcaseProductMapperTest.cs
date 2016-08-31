using System;
using System.Collections.Generic;
using Mobishop.Infrastructure.Repositories.Chaordic.Mappers;
using Mobishop.Infrastructure.Repositories.Chaordic.Showcase.Response;
using NUnit.Framework;

namespace Mobishop.Infrastructure.Repositories.UnitTests.Chaordic.Mapper
{
    [TestFixture]
    public class ChaordicShowcaseProductMapperTest
    {
        ChaordicShowcaseProductMapper m_mapper;

        [SetUp]
        public void Setup()
        {
            m_mapper = new ChaordicShowcaseProductMapper();
        }

        [Test]
        public void ToDomainEntity_NeemuSearchResult_String()
        {

            var source = new ChaordicRecommendation()
            {
                ApiKey = "ApiKey",
                Categories = new List<ChaordicCategory>()
                {
                    new ChaordicCategory()
                    {
                        Id = "1",
                        Name = "TagName",
                        Parents = new List<string>()
                        {
                            "parent1",
                            "parent2"
                        }
                    },
                    new ChaordicCategory()
                    {
                        Id = "2",
                        Name = "TagName2",
                        Parents = new List<string>()
                        {
                            "parent3",
                            "parent4"
                        }
                    }
                },
                DaysOnTop = "10",
                Id = "1",
                Images = new ChaordicImage()
                {
                    ImageWith128x128 = "ImageWith128x128",
                    ImageWith230x230 = "ImageWith230x230",
                    ImageWith340x340 = "ImageWith340x340",
                    ImageWith500x500 = "ImageWith500x500",
                    ImageWith50x50 = "ImageWith50x50",
                    ImageWith70x70 = "ImageWith70x70"
                },
                Installment = new ChaordicInstallment()
                {
                    Count = 1,
                    Price = "Price"
                },
                Name = "Name",
                OldPrice = "R$ 8,37",
                Price = "R$ 8,01",
                SimilarityWeight = 1,
                Status = "Status",
                Tags = new List<ChaordicTag>()
                {
                    new ChaordicTag()
                    {
                        Id = "11",
                        Name = "Tag"
                    }
                },
                Tendency = "Tendency",
                Url = "URL"
            };

            var actual = m_mapper.ToDomainEntity(source);

            Assert.IsNotNull(actual);
            Assert.AreEqual(source.Id, actual.Id.ToString());
            Assert.AreEqual(source.Price, actual.CurrentPrice.ToString("C"));
            Assert.AreEqual(source.Name, actual.Name);
            Assert.AreEqual(source.OldPrice, actual.PreviousPrice.ToString("C"));

            //TODO: Como seleiconar a melhor imagem?
            Assert.AreEqual(source.Images.ImageWith500x500, actual.ImageUrl);
            //TODO: O que é a descrição?
            Assert.AreEqual(source.Name, actual.Description);
        }

        [Test]
        public void ToDomainEntity_null_null()
        {
            var actual = m_mapper.ToDomainEntity(null);

            Assert.IsNull(actual);
        }
    }
}

