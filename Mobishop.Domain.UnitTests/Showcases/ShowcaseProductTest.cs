using System;
using System.Linq;
using System.Threading.Tasks;
using Mobishop.Domain.Products;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Memory;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Repositories;
using Splat;

namespace Mobishop.Domain.UnitTests.Showcases
{
    [TestFixture]
    public class ShowcaseProductTest
    {
        ShowcaseService m_target;

        [SetUp]
        public void Setup()
        {
            var unitOfWork = new MemoryUnitOfWork();
            Locator.CurrentMutable.RegisterLazySingleton(() => unitOfWork, typeof(IUnitOfWork));
            var repository = new MemoryShowcaseProductRepository(unitOfWork);
            Locator.CurrentMutable.RegisterConstant(repository, typeof(IShowcaseProductRepository));

            repository.Attach(new ShowcaseProduct
            {
                Id = 1,
                Name = "Primeiro"
            });

            repository.Attach(new ShowcaseProduct
            {
                Id = 2,
                Name = "Segundo"
            });

            repository.Attach(new ShowcaseProduct
            {
                Id = 3,
                Name = "Terceiro"
            });

            repository.Attach(new ShowcaseProduct
            {
                Id = 4,
                Name = "Quarto"
            });

            repository.Attach(new ShowcaseProduct
            {
                Id = 5,
                Name = "Quinto"
            });

            unitOfWork.CommitAsync();


            m_target = new ShowcaseService();
        }

        [Test]
        public async Task GetProductByName_Empty_EmptyList()
        {
            var actual = await m_target.GetShowcaseProductSuggestionsByNameAsync("");
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task GetProductByName_OneLetter_AllWordsWithThatLetter()
        {
            var actual = await m_target.GetShowcaseProductSuggestionsByNameAsync("o");
            Assert.AreEqual(5, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);
        }

        [Test]
        public async Task GetProductByName_StartWith_AllWordsThatStartsWith()
        {
            var actual = await m_target.GetShowcaseProductSuggestionsByNameAsync("Qu");
            Assert.AreEqual(2, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);
        }

        [Test]
        public async Task GetProductByName_EndWith_AllWordsThatSEndsWith()
        {
            var actual = await m_target.GetShowcaseProductSuggestionsByNameAsync("ro");
            Assert.AreEqual(2, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);

        }

        [Test]
        public async Task GetProductByName_NonExistentWord_Empty()
        {
            var actual = await m_target.GetShowcaseProductSuggestionsByNameAsync("Oitavo");
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task FindShowcaseProductSugestionsByNameAsync_Empty_EmptyList()
        {
            var actual = await m_target.GetShowcaseProductNameSuggestionsByNameAsync("");
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task FindShowcaseProductSugestionsByNameAsync_Test1_2Suggestions()
        {
            var actual = await m_target.GetShowcaseProductNameSuggestionsByNameAsync("Test1");
            Assert.AreEqual(2, actual.Count());
        }

        [Test]
        public async Task GetShowcaseProductsByShowcaseType_Offer_Offers()
        {
            var actual = (await m_target.GetShowcaseProductsByShowcaseType(ShowcaseType.Offers)).ToList();
            Assert.AreEqual(6, actual.Count());

            Assert.AreEqual("Name 0", actual[0].Name);
            Assert.AreEqual("Name 1", actual[1].Name);
        }

        [Test]
        public async Task GetShowcaseProductsByNameAsync_Empty_EmptyList()
        {
            var actual = await m_target.GetShowcaseProductsByNameAsync("");
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task GetShowcaseProductsByNameAsync_OneLetter_AllWordsWithThatLetter()
        {
            var actual = await m_target.GetShowcaseProductsByNameAsync("o");
            Assert.AreEqual(5, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);
        }

        [Test]
        public async Task GetShowcaseProductsByNameAsync_StartWith_AllWordsThatStartsWith()
        {
            var actual = await m_target.GetShowcaseProductsByNameAsync("Qu");
            Assert.AreEqual(2, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);
        }

        [Test]
        public async Task GetShowcaseProductsByNameAsync_EndWith_AllWordsThatSEndsWith()
        {
            var actual = await m_target.GetShowcaseProductsByNameAsync("ro");
            Assert.AreEqual(2, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);

        }

    }
}