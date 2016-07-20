using System;
using System.Net.Http;
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
			var client = new HttpClient(new NativeMessageHandler()) {
				BaseAddress = new Uri(baseAddress)
			};

			Service = RestService.For<TRestService>(client);
		}

		/// <summary>
		/// Gets the service.
		/// </summary>
		/// <value>The service.</value>
		public TRestService Service {
			get;
			private set;
		}
	}
}