﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mambo.Core.Http;
using Mambo.Models;

namespace Mambo.Services
{
	/// <summary>
	/// Product service.
	/// </summary>
	public interface IProductService
	{
		/// <summary>
		/// Searchs the products.
		/// </summary>
		/// <returns>The products.</returns>
		/// <param name="name">Name.</param>
		/// <param name="priority">Priority.</param>
		Task<IList<Product>> SearchProducts(string name, PriorityRequest priority = PriorityRequest.Intermediate);
	}
}