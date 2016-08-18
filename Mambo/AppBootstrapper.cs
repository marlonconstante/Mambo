using Mobishop.Core.Caching;
using Mobishop.Domain.Products;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Memory;
using Skahal.Infrastructure.Framework.Repositories;
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

			 var unitOfWork = new MemoryUnitOfWork();
            Locator.CurrentMutable.RegisterLazySingleton(() => new MemoryUnitOfWork(), typeof(IUnitOfWork));
            Locator.CurrentMutable.RegisterConstant(new MemoryProductRepository(unitOfWork), typeof(IProductRepository));
            Locator.CurrentMutable.RegisterConstant(new MemoryShowcaseProductRepository(unitOfWork), typeof(IShowcaseProductRepository));
		}
	}
}