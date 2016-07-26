using System;
using System.Net;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Polly;

namespace Mambo.Core.Http
{
	/// <summary>
	/// Http handler.
	/// </summary>
	public static class HttpHandler
	{
		/// <summary>
		/// Executes the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="remoteFunction">Remote function.</param>
		/// <param name="attempts">Attempts.</param>
		/// <typeparam name="TResult">The 1st type parameter.</typeparam>
		public static async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> remoteFunction, int attempts = 5)
		{
			if (CrossConnectivity.Current.IsConnected)
			{
				return await Policy.Handle<WebException>()
								   .WaitAndRetryAsync(attempts, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
								   .ExecuteAsync(remoteFunction);
			}

			return default(TResult);
		}
	}
}