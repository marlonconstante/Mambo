using System;
using System.Globalization;
using Mobishop.Infrastructure.Repositories.Neemu.Mappers;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search;
using NUnit.Framework;

namespace Mobishop.Infrastructure.Repositories.UnitTests.Neemu.Mappers
{
    [TestFixture]
    public class NeemuShowcaseProductMapperTest
    {
        NeemuShowcaseProductMapper m_mapper;

        [SetUp]
        public void Setup()
        {
            m_mapper = new NeemuShowcaseProductMapper();
        }

        [Test]
        public void ToDomainEntity_NeemuShowcaseProduct_ShowcaseProduct()
        {
            var neemuProduct = new Product()
            {
                Id = 12345,
                Price = "5,12",
                PriceRaw = "10.10",
                Name = "Name",
                ImageUrl = "http://url"
            };

            var actual = m_mapper.ToDomainEntity(neemuProduct);

            Assert.AreEqual(neemuProduct.Id, actual.Id);
            Assert.AreEqual(neemuProduct.PriceRaw, actual.PreviousPrice.ToString("F", new CultureInfo("en-US")));
            Assert.AreEqual(neemuProduct.Price, actual.CurrentPrice.ToString("F", new CultureInfo("pt-BR")));
            Assert.AreEqual("", actual.Description);
            Assert.AreEqual(neemuProduct.ImageUrl, actual.ImageUrl);
            Assert.AreEqual(neemuProduct.Name, actual.Name);

        }

        [Test]
        public void ToDomainEntity_null_null()
        {
            var actual = m_mapper.ToDomainEntity(null);

            Assert.IsNull(actual);
        }
    }
}

