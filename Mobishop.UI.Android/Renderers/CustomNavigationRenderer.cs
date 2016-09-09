using FormsPlugin.Iconize.Droid;
using Mobishop.UI.Android.Renderers;
using Mobishop.UI.Controls;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationRenderer))]
namespace Mobishop.UI.Android.Renderers
{
	/// <summary>
	/// Custom navigation renderer.
	/// </summary>
	public class CustomNavigationRenderer : IconNavigationRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.UI.Android.Renderers.CustomNavigationRenderer"/> class.
		/// </summary>
		public CustomNavigationRenderer()
		{
		}
	}
}