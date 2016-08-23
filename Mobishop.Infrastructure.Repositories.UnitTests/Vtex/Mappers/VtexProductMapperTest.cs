using System;
using Mobishop.Infrastructure.Repositories.Vtex;
using Mobishop.Infrastructure.Repositories.Vtex.Mappers;
using NUnit.Framework;

namespace Mobishop.Infrastructure.Repositories.UnitTests.Vtex.Mappers
{
    [TestFixture]
    public class VtexProductMapperTest
    {
        VtexProductMapper m_mapper;

        [SetUp]
        public void Setup()
        {
            m_mapper = new VtexProductMapper();
        }

        [Test]
        public void ToDomainEntity_VtexProduct_Product()
        {
            var vtexProduct = new VtexProduct()
            {
                Id = 1,
                Name = "Test"
            };

            var actual = m_mapper.ToDomainEntity(vtexProduct);

            Assert.AreEqual(vtexProduct.Id, actual.Id);
            Assert.AreEqual(vtexProduct.Name, actual.Name);
        }

        [Test]
        public void ToDomainEntity_null_null()
        {
            var actual = m_mapper.ToDomainEntity(null);

            Assert.IsNull(actual);
        }
    }
}

