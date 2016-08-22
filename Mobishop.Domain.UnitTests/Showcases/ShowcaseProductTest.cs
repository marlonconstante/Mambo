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
            var actual = await m_target.GetShowcaseProductByNameAsync("");
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task GetProductByName_OneLetter_AllWordsWithThatLetter()
        {
            var actual = await m_target.GetShowcaseProductByNameAsync("o");
            Assert.AreEqual(5, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);
        }

        [Test]
        public async Task GetProductByName_StartWith_AllWordsThatStartsWith()
        {
            var actual = await m_target.GetShowcaseProductByNameAsync("Qu");
            Assert.AreEqual(2, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);
        }

        [Test]
        public async Task GetProductByName_EndWith_AllWordsThatSEndsWith()
        {
            var actual = await m_target.GetShowcaseProductByNameAsync("ro");
            Assert.AreEqual(2, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);

        }

        [Test]
        public async Task GetProductByName_NonExistentWord_Empty()
        {
            var actual = await m_target.GetShowcaseProductByNameAsync("Oitavo");
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task FindShowcaseProductSugestionsByNameAsync_Empty_EmptyList()
        {
            var actual = await m_target.GetShowcaseProductSugestionsByNameAsync("");
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task FindShowcaseProductSugestionsByNameAsync_Test1_2Suggestions()
        {
            var actual = await m_target.GetShowcaseProductSugestionsByNameAsync("Test1");
            Assert.AreEqual(2, actual.Count());
        }
    }
}