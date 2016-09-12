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

		/// <summary>
		/// Ons the size allocated.
		/// </summary>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);

			if (Device.OS == TargetPlatform.iOS && !NavigationPage.GetHasNavigationBar(this))
			{
				if (height > width)
				{
					Padding = new Thickness(0d, 20d, 0d, 0d);
				}
				else
				{
					Padding = new Thickness(0d);
				}
			}
		}
	}
}