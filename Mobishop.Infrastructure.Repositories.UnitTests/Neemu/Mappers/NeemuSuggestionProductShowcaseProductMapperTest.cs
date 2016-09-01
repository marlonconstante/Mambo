using Mobishop.Infrastructure.Repositories.Neemu.Mappers;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.SuggestionSearch;
using NUnit.Framework;

namespace Mobishop.Infrastructure.Repositories.UnitTests.Neemu.Mappers
{
    [TestFixture]
    public class NeemuSuggestionProductShowcaseProductMapperTest
    {
        NeemuSuggestionProductShowcaseProductMapper m_mapper;

        [SetUp]
        public void Setup()
        {
            m_mapper = new NeemuSuggestionProductShowcaseProductMapper();
        }

        [Test]
        public void ToDomainEntity_NeemuShowcaseProduct_ShowcaseProduct()
        {
            var neemuProduct = new NeemuShowcaseProduct()
            {
                Id = 1,
                PreviousPrice = 10,
                CurrentPrice = 11,
                Description = "Description",
                ImageUrl = "http://image.url",
                Name = "Name"
            };

            var actual = m_mapper.ToDomainEntity(neemuProduct);

            Assert.AreEqual(neemuProduct.Id, actual.Id);
            Assert.AreEqual(neemuProduct.PreviousPrice, actual.PreviousPrice);
            Assert.AreEqual(neemuProduct.CurrentPrice, actual.CurrentPrice);
            Assert.AreEqual(neemuProduct.Description, actual.Description);
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

