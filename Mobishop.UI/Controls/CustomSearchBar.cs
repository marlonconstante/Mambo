using Xamarin.Forms;

namespace Mobishop.UI.Controls
{
	/// <summary>
	/// Custom search bar.
	/// </summary>
	public class CustomSearchBar : SearchBar
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.UI.Controls.CustomSearchBar"/> class.
		/// </summary>
		public CustomSearchBar()
		{
			Style = (Style) Application.Current.Resources["searchBarStyle"];
		}
	}
}