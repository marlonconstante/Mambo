using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Polly;

namespace Mobishop.Core.Http
{
	/// <summary>
	/// Http handler.
	/// </summary>
	public static class HttpHandler
	{
		/// <summary>
		/// Execute the specified remoteFunction, cancellationToken and attempts.
		/// </summary>
		/// <param name="remoteFunction">Remote function.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		/// <param name="attempts">Attempts.</param>
		/// <typeparam name="TResult">The 1st type parameter.</typeparam>
		public static Task<TResult> Execute<TResult>(Func<CancellationToken, Task<TResult>> remoteFunction, CancellationToken cancellationToken = default(CancellationToken), int attempts = 5)
		{
			if (CrossConnectivity.Current.IsConnected)
			{
				return Policy.Handle<WebException>()
							 .WaitAndRetryAsync(attempts, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
							 .ExecuteAsync(remoteFunction, cancellationToken);
			}

			return Task.FromResult(default(TResult));
		}
	}
}