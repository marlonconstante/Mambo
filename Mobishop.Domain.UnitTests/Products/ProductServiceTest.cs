using System;
using System.Linq;
using System.Threading.Tasks;
using Mobishop.Domain.Products;
using Mobishop.Infrastructure.Repositories.Memory;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Repositories;
using Splat;

namespace Mobishop.Domain.UnitTests.Products
{
    [TestFixture]
    public class ProductServiceTest
    {
        ProductService m_target;

        [SetUp]
        public async Task Setup()
        {
            var unitOfWork = new MemoryUnitOfWork();
            Locator.CurrentMutable.RegisterLazySingleton(() => unitOfWork, typeof(IUnitOfWork));
            var repository = new MemoryProductRepository(unitOfWork);
            Locator.CurrentMutable.RegisterConstant(repository, typeof(IProductRepository));

            await repository.Attach(new Product
            {
                Id = 1,
                Name = "Primeiro"
            });

            await repository.Attach(new Product
            {
                Id = 2,
                Name = "Segundo"
            });

            await repository.Attach(new Product
            {
                Id = 3,
                Name = "Terceiro"
            });

            await repository.Attach(new Product
            {
                Id = 4,
                Name = "Quarto"
            });

            await repository.Attach(new Product
            {
                Id = 5,
                Name = "Quinto"
            });

            await unitOfWork.CommitAsync();


            m_target = new ProductService();
        }

        [Test]
        public async Task GetProductByName_Empty_EmptyList()
        {
            var actual = await m_target.GetProductByNameAsync("");
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task GetProductByName_OneLetter_AllWordsWithThatLetter()
        {
            var actual = await m_target.GetProductByNameAsync("o");
            Assert.AreEqual(5, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);
        }

        [Test]
        public async Task GetProductByName_StartWith_AllWordsThatStartsWith()
        {
            var actual = await m_target.GetProductByNameAsync("Qu");
            Assert.AreEqual(2, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);
        }

        [Test]
        public async Task GetProductByName_EndWith_AllWordsThatSEndsWith()
        {
            var actual = await m_target.GetProductByNameAsync("ro");
            Assert.AreEqual(2, actual.Count());
            Assert.IsNotEmpty(actual.FirstOrDefault().Name);

        }

        [Test]
        public async Task GetProductByName_NonExistentWord_Empty()
        {
            var actual = await m_target.GetProductByNameAsync("Oitavo");
            Assert.AreEqual(0, actual.Count());
        }
    }
}