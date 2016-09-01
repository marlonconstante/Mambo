using Mobishop.Infrastructure.Repositories.Neemu.Mappers;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.SuggestionSearch;
using NUnit.Framework;

namespace Mobishop.Infrastructure.Repositories.UnitTests.Neemu.Mappers
{
    [TestFixture]
    public class NeemuSearchSuggestionMapperTest
    {
        NeemuSearchSuggestionMapper m_mapper;

        [SetUp]
        public void Setup()
        {
            m_mapper = new NeemuSearchSuggestionMapper();
        }

        [Test]
        public void ToDomainEntity_NeemuSearchResult_String()
        {
            var sugesstion1 = new NeemuSuggestion()
            {
                Query = "Suggestion1"
            };

            var actual = m_mapper.ToDomainEntity(sugesstion1);

            Assert.AreEqual(sugesstion1.Query, actual);
        }

        [Test]
        public void ToDomainEntity_null_null()
        {
            var actual = m_mapper.ToDomainEntity(null);

            Assert.IsNull(actual);
        }
    }
}

