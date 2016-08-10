using Mambo.Services;
using Mobishop.Core.Caching;
using Splat;

namespace Mambo
{
	/// <summary>
	/// App bootstrapper.
	/// </summary>
	public static class AppBootstrapper
	{
		/// <summary>
		/// Initialize this instance.
		/// </summary>
		public static void Initialize()
		{
			Cached.Initialize("Mambo");

			Locator.CurrentMutable.RegisterLazySingleton(() => new ProductService(), typeof(IProductService));
			Locator.CurrentMutable.RegisterLazySingleton(() => new SearchService(), typeof(ISearchService));
		}
	}
}