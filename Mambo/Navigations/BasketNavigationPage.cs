using FormsPlugin.Iconize;
using Mobishop.UI.Controls;
using Xamarin.Forms;

namespace Mambo.Navigations
{
	/// <summary>
	/// Basket navigation page.
	/// </summary>
	public class BasketNavigationPage : CustomNavigationPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.Navigations.BasketNavigationPage"/> class.
		/// </summary>
		/// <param name="page">Page.</param>
		public BasketNavigationPage(Page page) : base(page)
		{
			ToolbarItems.Add(new IconToolbarItem {
				Icon = "md-search",
				IconColor = Color.White
			});

			ToolbarItems.Add(new IconToolbarItem {
				Icon = "md-shopping-cart",
				IconColor = Color.White
			});
		}
	}
}