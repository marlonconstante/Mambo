using Splat;

namespace Mambo.Services
{
	/// <summary>
	/// Service locator.
	/// </summary>
	public static class ServiceLocator
	{
		/// <summary>
		/// Register this instance.
		/// </summary>
		public static void Register()
		{
			Locator.CurrentMutable.RegisterLazySingleton(() => new ProductService(), typeof(IProductService));
		}
	}
}