using System;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Akavache;

namespace Mobishop.Core.Caching
{
	/// <summary>
	/// Cached.
	/// </summary>
	public static class Cached
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
		/// Gets the value.
		/// </summary>
		/// <returns>The value.</returns>
		/// <param name="cacheKey">Cache key.</param>
		/// <param name="fetchFunction">Fetch function.</param>
		/// <param name="cacheValidityInMinutes">Cache validity in minutes.</param>
		/// <typeparam name="TResult">The 1st type parameter.</typeparam>
		public static Task<TResult> GetValue<TResult>(string cacheKey, Func<Task<TResult>> fetchFunction, double cacheValidityInMinutes = 5d)
		{
			return BlobCache.LocalMachine.GetAndFetchLatest(cacheKey, async () => {
				return await fetchFunction.Invoke().ConfigureAwait(false);
			}, offset => {
				var elapsed = DateTimeOffset.Now - offset;
				return elapsed > TimeSpan.FromMinutes(cacheValidityInMinutes);
			}).ToTask();
		}

		/// <summary>
		/// Invalidates all.
		/// </summary>
		/// <returns>The all.</returns>
		public static void InvalidateAll()
		{
			BlobCache.LocalMachine.InvalidateAll();
		}
	}
}