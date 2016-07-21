using System;
using System.Collections.Generic;
using System.Net.Http;
using Fusillade;
using ModernHttpClient;
using Refit;

namespace Mambo.Core.Http
{
	/// <summary>
	/// Rest client.
	/// </summary>
	public abstract class RestClient<TRestService> where TRestService : IRestService
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.Core.Http.RestClient`1"/> class.
		/// </summary>
		/// <param name="baseAddress">Base address.</param>
		public RestClient(string baseAddress)
		{
			BaseAddress = baseAddress;

			ServiceMap = new Dictionary<Priority, Lazy<TRestService>>();
			ServiceMap.Add(BuildLazyService(Priority.Background));
			ServiceMap.Add(BuildLazyService(Priority.UserInitiated));
			ServiceMap.Add(BuildLazyService(Priority.Speculative));
		}

		/// <summary>
		/// Gets the service.
		/// </summary>
		/// <returns>The service.</returns>
		/// <param name="priority">Priority.</param>
		public TRestService GetService(Priority priority)
		{
			if (!ServiceMap.ContainsKey(priority))
			{
				throw new ArgumentException($"Prioridade {priority} não é suportada.");
			}

			return ServiceMap[priority].Value;
		}

		/// <summary>
		/// Builds the lazy service.
		/// </summary>
		/// <returns>The lazy service.</returns>
		/// <param name="priority">Priority.</param>
		KeyValuePair<Priority, Lazy<TRestService>> BuildLazyService(Priority priority)
		{
			return new KeyValuePair<Priority, Lazy<TRestService>>(priority, new Lazy<TRestService>(() => BuildService(priority)));
		}

		/// <summary>
		/// Builds the service.
		/// </summary>
		/// <returns>The service.</returns>
		/// <param name="priority">Priority.</param>
		TRestService BuildService(Priority priority)
		{
			var handler = new RateLimitedHttpMessageHandler(new NativeMessageHandler(), priority);
			var client = new HttpClient(handler) {
				BaseAddress = new Uri(BaseAddress)
			};

			return RestService.For<TRestService>(client);
		}

		/// <summary>
		/// Gets or sets the service map.
		/// </summary>
		/// <value>The service map.</value>
		IDictionary<Priority, Lazy<TRestService>> ServiceMap {
			get;
			set;
		}

		/// <summary>
		/// Gets the base address.
		/// </summary>
		/// <value>The base address.</value>
		public string BaseAddress {
			get;
			private set;
		}
	}
}