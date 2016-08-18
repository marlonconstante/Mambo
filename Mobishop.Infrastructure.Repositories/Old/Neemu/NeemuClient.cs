using Mobishop.Core.Http;

namespace Mambo.Neemu
{
	/// <summary>
	/// Neemu client.
	/// </summary>
	public abstract class NeemuClient<TNeemuRepository> : RestClient<TNeemuRepository> where TNeemuRepository : INeemuRepository
	{
		/// <summary>
		/// The address.
		/// </summary>
		const string Address = "http://busca.mambo.com.br";

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.Neemu.NeemuClient`1"/> class.
		/// </summary>
		public NeemuClient() : base(Address)
		{
		}
	}
}