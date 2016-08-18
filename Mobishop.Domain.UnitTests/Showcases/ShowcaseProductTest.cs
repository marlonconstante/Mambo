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
        public async Task Setup()
        {
            var unitOfWork = new MemoryUnitOfWork();
            Locator.CurrentMutable.RegisterLazySingleton(() => unitOfWork, typeof(IUnitOfWork));
            var repository = new MemoryShowcaseProductRepository(unitOfWork);
            Locator.CurrentMutable.RegisterConstant(repository, typeof(IProductRepository));

            await repository.Attach(new ShowcaseProduct
            {
                Id = 1,
                Name = "Primeiro"
            });

            await repository.Attach(new ShowcaseProduct
            {
                Id = 2,
                Name = "Segundo"
            });

            await repository.Attach(new ShowcaseProduct
            {
                Id = 3,
                Name = "Terceiro"
            });

            await repository.Attach(new ShowcaseProduct
            {
                Id = 4,
                Name = "Quarto"
            });

            await repository.Attach(new ShowcaseProduct
            {
                Id = 5,
                Name = "Quinto"
            });

            await unitOfWork.CommitAsync();


            m_target = new ShowcaseService();
        }

        [Test]
        public async Task GetProductByName_Empty_EmptyList()
        {
            var actual = await m_target.GetShowcaseProductByName("");
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task GetProductByName_OneLetter_AllWordsWithThatLetter()
        {
            var actual = await m_target.GetShowcaseProductByName("o");
            Assert.AreEqual(5, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);
        }

        [Test]
        public async Task GetProductByName_StartWith_AllWordsThatStartsWith()
        {
            var actual = await m_target.GetShowcaseProductByName("Qu");
            Assert.AreEqual(2, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);
        }

        [Test]
        public async Task GetProductByName_EndWith_AllWordsThatSEndsWith()
        {
            var actual = await m_target.GetShowcaseProductByName("ro");
            Assert.AreEqual(2, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);

        }

        [Test]
        public async Task GetProductByName_NonExistentWord_Empty()
        {
            var actual = await m_target.GetShowcaseProductByName("Oitavo");
            Assert.AreEqual(0, actual.Count());
        }
    }
}