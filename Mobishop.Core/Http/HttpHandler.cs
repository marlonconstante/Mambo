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
		/// Execute the specified remoteFunction and attempts.
		/// </summary>
		/// <param name="remoteFunction">Remote function.</param>
		/// <param name="attempts">Attempts.</param>
		/// <typeparam name="TResult">The 1st type parameter.</typeparam>
		public static Task<TResult> Execute<TResult>(Func<Task<TResult>> remoteFunction, int attempts = 5)
		{
			if (CrossConnectivity.Current.IsConnected)
			{
				return Policy.Handle<WebException>()
							 .WaitAndRetryAsync(attempts, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
							 .ExecuteAsync(remoteFunction);
			}

			return Task.FromResult(default(TResult));
		}
	}
}