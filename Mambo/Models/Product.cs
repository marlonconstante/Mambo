﻿using Newtonsoft.Json;

namespace Mambo.Models
{
	/// <summary>
	/// Product.
	/// </summary>
	public class Product
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[JsonProperty("productId")]
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[JsonProperty("productName")]
		public string Name { get; set; }
	}
}