using Xamarin.Forms;

namespace Mobishop.UI.Controls
{
	/// <summary>
	/// Custom page.
	/// </summary>
	public class CustomPage : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.UI.Controls.CustomPage"/> class.
		/// </summary>
		public CustomPage()
		{
			Style = (Style) Application.Current.Resources["pageStyle"];

			NavigationPage.SetTitleIcon(this, (string) Application.Current.Resources["titleIconImageName"]);
		}
	}
}