using FormsPlugin.Iconize.iOS;
using Mobishop.UI.Controls;
using Mobishop.UI.iOS.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationRenderer))]
namespace Mobishop.UI.iOS.Renderers
{
	/// <summary>
	/// Custom navigation renderer.
	/// </summary>
	public class CustomNavigationRenderer : IconNavigationRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.UI.iOS.Renderers.CustomNavigationRenderer"/> class.
		/// </summary>
		public CustomNavigationRenderer()
		{
		}
	}
}