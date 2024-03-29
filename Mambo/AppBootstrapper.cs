﻿using Mambo.Utils;
using Mobishop.Domain.Products;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Repositories.Memory;
using Mobishop.Infrastructure.Repositories.NeemuChaordic.Showcase;
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
			//RegisterMemoryRepositories();
			RegisterRestRepositories();

            //Locator.CurrentMutable.RegisterLazySingleton(() => new UserDialogsService(), typeof(IUserDialogsService));
		}

		/// <summary>
		/// Registers the memory repositories.
		/// </summary>
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

		/// <summary>
		/// Registers the rest repositories.
		/// </summary>
		static void RegisterRestRepositories()
		{
			var unitOfWork = new MemoryUnitOfWork();
			Locator.CurrentMutable.RegisterLazySingleton(() => unitOfWork, typeof(IUnitOfWork));
			Locator.CurrentMutable.RegisterLazySingleton(() => new VtexProductRepository(unitOfWork), typeof(IProductRepository));
			Locator.CurrentMutable.RegisterLazySingleton(() => new NeemuChaordicShowcaseProductRepository(), typeof(IShowcaseProductRepository));
		}
	}
}