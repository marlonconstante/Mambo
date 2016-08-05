using Mobishop.Core.Http;

namespace Mambo.Vtex
{
	/// <summary>
	/// Vtex client.
	/// </summary>
	public abstract class VtexClient<TRestRepository> : RestClient<TRestRepository> where TRestRepository : IRestRepository
	{
		/// <summary>
		/// The address.
		/// </summary>
		const string Address = "http://www.mambo.com.br/api/catalog_system/pub";

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.Core.Vtex.VtexClient`1"/> class.
		/// </summary>
		public VtexClient() : base(Address)
		{
		}
	}
}