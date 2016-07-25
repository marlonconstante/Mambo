using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;

namespace Mambo.Core.Caching
{
	/// <summary>
	/// Cached.
	/// </summary>
	public static class Cached
	{
		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <returns>The value.</returns>
		/// <param name="cacheKey">Cache key.</param>
		/// <param name="fetchFunction">Fetch function.</param>
		/// <param name="cacheValidityInMinutes">Cache validity in minutes.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static async Task<T> GetValue<T>(string cacheKey, Func<Task<T>> fetchFunction, double cacheValidityInMinutes = 5d)
		{
			return await BlobCache.LocalMachine.GetAndFetchLatest(cacheKey, fetchFunction, offset => {
				var elapsed = DateTimeOffset.Now - offset;
				return elapsed > TimeSpan.FromMinutes(cacheValidityInMinutes);
			}).FirstOrDefaultAsync();
		}
	}
}