using System.Linq;
using System.Threading.Tasks;
using Mambo.Services;
using Mobishop.Core.Caching;
using NUnit.Framework;

namespace Mambo.FunctionalTests.Services
{
	/// <summary>
	/// Search service test.
	/// </summary>
	[TestFixture]
	public class SearchServiceTest
	{
		/// <summary>
		/// The service.
		/// </summary>
		ISearchService service;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.FunctionalTests.Services.SearchServiceTest"/> class.
		/// </summary>
		public SearchServiceTest()
		{
			Cached.Initialize("Mambo");
		}

		/// <summary>
		/// Sets up.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			Cached.InvalidateAll();
			service = new SearchService();
		}

		/// <summary>
		/// Shoulds the find meats.
		/// </summary>
		/// <returns>The find meats.</returns>
		[Test]
		public async Task ShouldFindMeats()
		{
			var query = "carne";

			var result = await service.AutoComplete(query).ConfigureAwait(false);

			var suggestions = result.Suggestions;
			Assert.That(suggestions.Select(s => s.Query.ToLower()), Has.All.Contains(query));

			var products = result.Products;
			Assert.That(products.Select(p => p.Id), Has.All.GreaterThan(0L));
			Assert.That(products.Select(p => p.Description.ToLower()), Has.All.Contains(query));
			Assert.That(products.Select(p => p.PreviousPrice), Has.All.GreaterThan(0d));
			Assert.That(products.Select(p => p.CurrentPrice), Has.All.GreaterThan(0d));
			Assert.That(products.Select(p => p.ImageUrl), Has.All.Not.Empty);
		}
	}
}