using System;
using System.Linq;
using System.Threading.Tasks;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Vtex.Products;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Repositories;

namespace Mobishop.Infrastructure.Repositories.FunctionalTests.VTex.Products
{
    [TestFixture]
    public class VtexProductRepositoryTest
    {
        VtexProductRepository m_target;

        [SetUp]
        public void Setup()
        {
            var unitOfWork = new MemoryUnitOfWork();
            m_target = new VtexProductRepository(unitOfWork);
        }

        [Test]
        public async Task FindProductByNameAsync_Banana_ProductsWithBanana()
        {
            var name = "banana";
            var actual = await m_target.FindProductByNameAsync(name, Priorities.UserInitiated);
            Assert.That(actual.Select(p => p.Id), Has.All.GreaterThan(0L));
            Assert.That(actual.Select(p => p.Name.ToLower()), Has.All.Contains(name));

        }

        /// <summary>
        /// Shoulds the find cached apples.
        /// </summary>
        /// <returns>The find cached apples.</returns>
        //[Test]
        //public async Task ShouldFindCachedApples()
        //{
        //    Func<Task<long>> getElapsedMilliseconds = async () =>
        //    {
        //        var watch = Stopwatch.StartNew();
        //        await service.SearchProducts("maça").ConfigureAwait(false);
        //        watch.Stop();

        //        return watch.ElapsedMilliseconds;
        //    };

        //    var firstTime = await getElapsedMilliseconds();
        //    var secondTime = await getElapsedMilliseconds();

        //    Assert.That(firstTime > (secondTime * 10));
        //}
    }
}
