using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;

namespace Mobishop.Infrastructure.Repositories.Commons.Caching
{
	/// <summary>
	/// Cache.
	/// </summary>
	public static class Cache
	{
		/// <summary>
		/// Initialize the specified name.
		/// </summary>
		/// <param name="name">Name.</param>
		public static void Initialize(string name)
		{
			BlobCache.ApplicationName = name;
		}

		/// <summary>
		/// Gets the and fetch latest.
		/// </summary>
		/// <returns>The and fetch latest.</returns>
		/// <param name="cacheKey">Cache key.</param>
		/// <param name="fetchFunction">Fetch function.</param>
		/// <param name="cacheValidityInMinutes">Cache validity in minutes.</param>
		/// <typeparam name="TResult">The 1st type parameter.</typeparam>
		public static async Task<TResult> GetAndFetchLatest<TResult>(string cacheKey, Func<Task<TResult>> fetchFunction, double cacheValidityInMinutes = 5d)
		{
			var result = default(TResult);

			var cachedResult = BlobCache.LocalMachine.GetAndFetchLatest(cacheKey, fetchFunction, offset => {
				var elapsed = DateTimeOffset.Now - offset;
				return elapsed > TimeSpan.FromMinutes(cacheValidityInMinutes);
			});

			cachedResult.Subscribe(value => {
				result = value;
			});

			result = await cachedResult.FirstOrDefaultAsync();
			return result;
		}

		/// <summary>
		/// Invalidates all.
		/// </summary>
		public static void InvalidateAll()
		{
			BlobCache.LocalMachine.InvalidateAll();
		}

		/// <summary>
		/// Shutdown this instance.
		/// </summary>
		public static void Shutdown()
		{
			BlobCache.Shutdown().Wait();
		}
	}
}