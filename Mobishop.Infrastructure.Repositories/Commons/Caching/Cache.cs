using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;

namespace Mobishop.Infrastructure.Repositories.Commons.Caching
{
	/// <summary>
	/// Cached.
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
            TResult result = default(TResult);

             var cachedResult = BlobCache.LocalMachine.GetAndFetchLatest(
                cacheKey,
                fetchFunction,
                offset =>
                {
                    var elapsed = DateTimeOffset.Now - offset;
                    return elapsed > TimeSpan.FromMinutes(cacheValidityInMinutes);
            });

            cachedResult.Subscribe(subscribedPosts =>
            {
                result = subscribedPosts;
            });

            result = await cachedResult.FirstOrDefaultAsync();
            return result;
		}

        /// <summary>
        /// Gets the and fetch latests.
        /// </summary>
        /// <returns>The and fetch latests.</returns>
        /// <param name="cacheKey">Cache key.</param>
        /// <param name="fetchFunction">Fetch function.</param>
        /// <param name="cacheValidityInMinutes">Cache validity in minutes.</param>
        /// <typeparam name="TResult">The 1st type parameter.</typeparam>
        public static async Task<IEnumerable<TResult>> GetAndFetchLatests<TResult>(string cacheKey, Func<Task<IEnumerable<TResult>>> fetchFunction, double cacheValidityInMinutes = 5d)
        {
            IEnumerable<TResult> result = default(IEnumerable<TResult>);

            var cachedResult = BlobCache.LocalMachine.GetAndFetchLatest(
               cacheKey,
               fetchFunction,
               offset =>
               {
                   var elapsed = DateTimeOffset.Now - offset;
                   return elapsed > TimeSpan.FromMinutes(cacheValidityInMinutes);
               });

            cachedResult.Subscribe(subscribedPosts =>
            {
                result = subscribedPosts;
            });

            result = await cachedResult.FirstOrDefaultAsync();
            return result;
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