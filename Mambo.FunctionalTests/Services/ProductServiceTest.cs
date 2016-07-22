using System.Linq;
using System.Threading.Tasks;
using Mambo.Services;
using NUnit.Framework;

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
		/// Sets up.
		/// </summary>
		/// <returns>The up.</returns>
		[SetUp]
		public void SetUp()
		{
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
	}
}