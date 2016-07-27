﻿using Mambo.Services;
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
			Locator.CurrentMutable.RegisterLazySingleton(() => new ProductService(), typeof(IProductService));
		}
	}
}