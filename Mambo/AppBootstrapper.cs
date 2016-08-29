using Mobishop.Core.Caching;
using Mobishop.Domain.Products;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Memory;
using Mobishop.Infrastructure.Repositories.NeemuChaortic.Showcase;
using Mobishop.Infrastructure.Repositories.Vtex.Products;
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
            //RegisterMemoryRepositories();
            RegisterRestRepositories();
        }

        static void RegisterMemoryRepositories()
        {
            var unitOfWork = new MemoryUnitOfWork();
            Locator.CurrentMutable.RegisterLazySingleton(() => unitOfWork, typeof(IUnitOfWork));
            Locator.CurrentMutable.RegisterLazySingleton(() => new MemoryProductRepository(unitOfWork), typeof(IProductRepository));

            var neemuProduct = new MemoryShowcaseProductRepository(unitOfWork);
            neemuProduct.Attach(new ShowcaseProduct() { Name = "Teste" });
            unitOfWork.CommitAsync();

            Locator.CurrentMutable.RegisterLazySingleton(() => neemuProduct, typeof(IShowcaseProductRepository));
        }

        static void RegisterRestRepositories()
        {
            var unitOfWork = new MemoryUnitOfWork();
            Locator.CurrentMutable.RegisterLazySingleton(() => unitOfWork, typeof(IUnitOfWork));
            Locator.CurrentMutable.RegisterLazySingleton(() => new VtexProductRepository(unitOfWork), typeof(IProductRepository));
            Locator.CurrentMutable.RegisterLazySingleton(() => new NeemuChaorticShowcaseProductRepository(), typeof(IShowcaseProductRepository));
        }

    }
}