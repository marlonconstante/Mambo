using System;
using System.Collections.Generic;
using System.Net.Http;
using Fusillade;
using ModernHttpClient;
using Refit;

namespace Mobishop.Core.Http
{
	/// <summary>
	/// Rest client.
	/// </summary>
	public abstract class RestClient<TRestRepository> where TRestRepository : IRestRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.Core.Http.RestClient`1"/> class.
		/// </summary>
		/// <param name="baseAddress">Base address.</param>
		public RestClient(string baseAddress)
		{
			BaseAddress = baseAddress;

			ServiceMap = new Dictionary<PriorityRequest, Lazy<TRestRepository>>();
			ServiceMap.Add(BuildLazyService(PriorityRequest.Minimum));
			ServiceMap.Add(BuildLazyService(PriorityRequest.Intermediate));
			ServiceMap.Add(BuildLazyService(PriorityRequest.Maximum));
		}

		/// <summary>
		/// Gets the repository.
		/// </summary>
		/// <returns>The repository.</returns>
		/// <param name="priority">Priority.</param>
		protected TRestRepository GetRepository(PriorityRequest priority)
		{
			return ServiceMap[priority].Value;
		}

		/// <summary>
		/// Gets the priority.
		/// </summary>
		/// <returns>The priority.</returns>
		/// <param name="priority">Priority.</param>
		Priority GetPriority(PriorityRequest priority)
		{
			switch (priority)
			{
			case PriorityRequest.Minimum:
				return Priority.Speculative;

			case PriorityRequest.Intermediate:
				return Priority.Background;

			case PriorityRequest.Maximum:
				return Priority.UserInitiated;

			default:
				return Priority.Explicit;
			}
		}

		/// <summary>
		/// Builds the lazy service.
		/// </summary>
		/// <returns>The lazy service.</returns>
		/// <param name="priority">Priority.</param>
		KeyValuePair<PriorityRequest, Lazy<TRestRepository>> BuildLazyService(PriorityRequest priority)
		{
			return new KeyValuePair<PriorityRequest, Lazy<TRestRepository>>(priority, new Lazy<TRestRepository>(() => BuildService(priority)));
		}

		/// <summary>
		/// Builds the service.
		/// </summary>
		/// <returns>The service.</returns>
		/// <param name="priority">Priority.</param>
		TRestRepository BuildService(PriorityRequest priority)
		{
			var handler = new RateLimitedHttpMessageHandler(new NativeMessageHandler(), GetPriority(priority));
			var client = new HttpClient(handler) {
				BaseAddress = new Uri(BaseAddress)
			};

			return RestService.For<TRestRepository>(client);
		}

		/// <summary>
		/// Gets or sets the service map.
		/// </summary>
		/// <value>The service map.</value>
		IDictionary<PriorityRequest, Lazy<TRestRepository>> ServiceMap {
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