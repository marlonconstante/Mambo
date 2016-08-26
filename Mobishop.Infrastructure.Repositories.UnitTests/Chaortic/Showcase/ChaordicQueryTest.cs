using System;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Chaortic;
using NUnit.Framework;

namespace Mobishop.Infrastructure.Repositories.UnitTests.Chaortic.Showcase
{
    [TestFixture]
    public class ChaordicQueryTest
    {
        ChaordicQuery query;

        [SetUp]
        public void Setup()
        {
            query = new ChaordicQuery();
        }

        [Test]
        public void BuildQueryForShowcaseType_Offers_OffersQuery()
        {
            var actual = query.Build();
            var resultExpected = "{\"size\":7,\"apiKey\":\"panvel-v5\",\"identity\":{\"browserId\":\"1234\",\"session\":\"1\",\"anonymousUserId\":\"anon-1234\"},\"page\":{\"name\":\"mobile.home\"}}";
            Assert.AreEqual(resultExpected, actual);
        }
    }
}

