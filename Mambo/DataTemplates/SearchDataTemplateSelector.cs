﻿using Mambo.ViewModels;
using Xamarin.Forms;

namespace Mambo.DataTemplates
{
	/// <summary>
	/// Search data template selector.
	/// </summary>
	public class SearchDataTemplateSelector : DataTemplateSelector
	{
		/// <summary>
		/// Ons the select template.
		/// </summary>
		/// <returns>The select template.</returns>
		/// <param name="item">Item.</param>
		/// <param name="container">Container.</param>
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var viewModel = (SearchViewModel) item;
			var isProductTemplate = viewModel.Product != null;

			return isProductTemplate ? ProductTemplate : SuggestionTemplate;
		}

		/// <summary>
		/// Gets or sets the suggestion template.
		/// </summary>
		/// <value>The suggestion template.</value>
		public DataTemplate SuggestionTemplate {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the product template.
		/// </summary>
		/// <value>The product template.</value>
		public DataTemplate ProductTemplate {
			get;
			set;
		}
	}
}