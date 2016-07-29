using System;
using System.Linq;
using System.Threading.Tasks;
using Mobishop.Core.Caching;
using Mambo.Services;
using NUnit.Framework;
using NUnit.Framework.Compatibility;

namespace Mambo.FunctionalTests.Services
{
	/// <summary>
	/// Product service test.
	/// </summary>
	[TestFixture]
	public class ProductServiceTest
	{
		/// <summary>
		/// The service.
		/// </summary>
		IProductService service;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.FunctionalTests.Services.ProductServiceTest"/> class.
		/// </summary>
		public ProductServiceTest()
		{
			Cached.Initialize("Mambo");
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		/// <returns>The up.</returns>
		[SetUp]
		public void SetUp()
		{
			Cached.InvalidateAll();
			service = new ProductService();
		}

		/// <summary>
		/// Shoulds the find bananas.
		/// </summary>
		/// <returns>The find bananas.</returns>
		[Test]
		public async Task ShouldFindBananas()
		{
			var name = "banana";
			var products = await service.SearchProducts(name).ConfigureAwait(false);

			Assert.That(products.Select(p => p.Id), Has.All.Not.Empty);
			Assert.That(products.Select(p => p.Name.ToLower()), Has.All.Contains(name));
		}

		/// <summary>
		/// Shoulds the find cached apples.
		/// </summary>
		/// <returns>The find cached apples.</returns>
		[Test]
		public async Task ShouldFindCachedApples()
		{
			Func<Task<long>> getElapsedMilliseconds = async () => {
				var watch = Stopwatch.StartNew();
				await service.SearchProducts("maça").ConfigureAwait(false);
				watch.Stop();

				return watch.ElapsedMilliseconds;
			};

			var firstTime = await getElapsedMilliseconds();
			var secondTime = await getElapsedMilliseconds();

			Assert.That(firstTime > (secondTime * 10));
		}
	}
}