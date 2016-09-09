using FormsPlugin.Iconize;
using Xamarin.Forms;

namespace Mobishop.UI.Controls
{
	/// <summary>
	/// Custom navigation page.
	/// </summary>
	public class CustomNavigationPage : IconNavigationPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.UI.Controls.CustomNavigationPage"/> class.
		/// </summary>
		/// <param name="page">Page.</param>
		public CustomNavigationPage(Page page) : base(page)
		{
			Style = (Style) Application.Current.Resources["navigationBarStyle"];
		}
	}
}