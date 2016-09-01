using System.Linq;
using System.Threading.Tasks;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.NeemuChaordic.Showcase;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Repositories;

namespace Mobishop.Infrastructure.Repositories.FunctionalTests.NeemuChaordic.Showcase
{
    [TestFixture]
    public class NeemuChaordicShowcaseProductRepositoryTest
    {
        NeemuChaordicShowcaseProductRepository m_target;

        [SetUp]
        public void Setup()
        {
            var unitOfWork = new MemoryUnitOfWork();
            m_target = new NeemuChaordicShowcaseProductRepository(unitOfWork);
        }

        [Test]
        public async Task FindShowcaseProductSuggestionByNameAsync_Carne_ShowcaseProductWithCarne()
        {
            var name = "carne";
            var actual = await m_target.FindShowcaseProductSuggestionsByNameAsync(name, Priorities.UserInitiated);

            Assert.That(actual.Select(p => p.Id), Has.All.GreaterThan(0L));
            Assert.That(actual.Select(p => p.Description.ToLower()), Has.All.Contains(name));
            Assert.That(actual.Select(p => p.PreviousPrice), Has.All.GreaterThan(0d));
            Assert.That(actual.Select(p => p.CurrentPrice), Has.All.GreaterThan(0d));
            Assert.That(actual.Select(p => p.ImageUrl), Has.All.Not.Empty);
        }

        [Test]
        public async Task FindShowcaseProductNameSugestionsByNameAsync_Carne_SuggestionsWithCarne()
        {
            var name = "carne";
            var actual = await m_target.FindShowcaseProductNameSuggestionsByNameAsync(name, Priorities.UserInitiated);

            Assert.IsTrue(actual.Count() > 0);
            Assert.That(actual.Select(s => s.ToLower()), Has.All.Contains(name));
        }

        [Test]
        public async Task FindShowcaseProductNameSugestionsByNameAsync_XPTOXPO_EmptySuggestionList()
        {
            var name = "XPTOXPO";
            var actual = await m_target.FindShowcaseProductNameSuggestionsByNameAsync(name, Priorities.UserInitiated);

            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task FindShowcaseProductSuggestions_Carne_ProductsAndSuggestionsUsedCache()
        {
            var name = "carne";
            var actual = await m_target.FindShowcaseProductSuggestionsByNameAsync(name, Priorities.UserInitiated);

            Assert.That(actual.Select(p => p.Id), Has.All.GreaterThan(0L));
            Assert.That(actual.Select(p => p.Description.ToLower()), Has.All.Contains(name));
            Assert.That(actual.Select(p => p.PreviousPrice), Has.All.GreaterThan(0d));
            Assert.That(actual.Select(p => p.CurrentPrice), Has.All.GreaterThan(0d));
            Assert.That(actual.Select(p => p.ImageUrl), Has.All.Not.Empty);
       
            var actual2 = await m_target.FindShowcaseProductNameSuggestionsByNameAsync(name, Priorities.UserInitiated);

            Assert.IsTrue(actual2.Count() > 0);
            Assert.That(actual2.Select(s => s.ToLower()), Has.All.Contains(name));
        }

        [Test]
        public async Task FindShowcaseProductsByShowcaseType_Offers_ShowcaseProducts()
        {
            var actual = await m_target.FindShowcaseProductsByShowcaseType(ShowcaseType.Offers);

            Assert.IsNotNull(actual);

            foreach (var item in actual)
            {
                Assert.IsTrue(item.Id > 0);
                Assert.IsTrue(item.CurrentPrice > 0);
                Assert.IsTrue(!string.IsNullOrEmpty(item.Description));
                Assert.IsTrue(!string.IsNullOrEmpty(item.ImageUrl));
                Assert.IsTrue(!string.IsNullOrEmpty(item.Name));
                Assert.IsTrue(item.PreviousPrice > 0);

            }

            Assert.IsTrue(actual.Count() > 0);
        }

        [Test]
        public async Task FindShowcaseProductByNameAsync_Carne_ShowcaseProductWithCarne()
        {
            var name = "carne";
            var actual = await m_target.FindShowcaseProductByNameAsync(name, Priorities.UserInitiated);

            Assert.That(actual.Select(p => p.Id), Has.All.GreaterThan(0L));
            Assert.That(actual.Select(p => p.Description.ToLower()), Has.All.Contains(name));
            Assert.That(actual.Select(p => p.PreviousPrice), Has.All.GreaterThan(0d));
            Assert.That(actual.Select(p => p.CurrentPrice), Has.All.GreaterThan(0d));
            Assert.That(actual.Select(p => p.ImageUrl), Has.All.Not.Empty);
        }
    }
}
