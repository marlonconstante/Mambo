using System.Globalization;
using FreshMvvm;
using Mambo.Services;
using Mobishop.Core.Caching;

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
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
			Cached.Initialize("Mambo");

			FreshIOC.Container.Register<IProductService, ProductService>();
			FreshIOC.Container.Register<ISearchService, SearchService>();
		}
	}
}