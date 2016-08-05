using Newtonsoft.Json;

namespace Mambo.Models
{
	/// <summary>
	/// Product suggestion.
	/// </summary>
	public class ProductSuggestion
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		[JsonProperty("descricao")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the previous price.
		/// </summary>
		/// <value>The previous price.</value>
		[JsonProperty("de")]
		public double PreviousPrice { get; set; }

		/// <summary>
		/// Gets or sets the current price.
		/// </summary>
		/// <value>The current price.</value>
		[JsonProperty("preco")]
		public double CurrentPrice { get; set; }

		/// <summary>
		/// Gets or sets the image URL.
		/// </summary>
		/// <value>The image URL.</value>
		[JsonProperty("imagem")]
		public string ImageUrl { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:Mambo.Models.ProductSuggestion"/> is available.
		/// </summary>
		/// <value><c>true</c> if is available; otherwise, <c>false</c>.</value>
		[JsonProperty("disponivel")]
		public bool IsAvailable { get; set; }
	}
}