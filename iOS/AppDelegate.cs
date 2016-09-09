using Foundation;
using Mobishop.Infrastructure.Repositories.Commons.Caching;
using NControl.Controls.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Mambo.iOS
{
	/// <summary>
	/// App delegate.
	/// </summary>
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		/// <summary>
		/// Finisheds the launching.
		/// </summary>
		/// <returns><c>true</c>, if launching was finisheded, <c>false</c> otherwise.</returns>
		/// <param name="uiApplication">User interface application.</param>
		/// <param name="options">Options.</param>
		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary options)
		{
			Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.MaterialModule());

			global::Xamarin.Forms.Forms.Init();
			FormsPlugin.Iconize.iOS.IconControls.Init();
			Mobishop.UI.iOS.Controls.Init();
			NControls.Init();

			Cache.Initialize("Mambo");

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			var app = new App();
			LoadApplication(app);

			var statusBarBackgroundColor = (Color) app.Resources["statusBarBackgroundColor"];
			SetStatusBarBackgroundColor(uiApplication, statusBarBackgroundColor.ToUIColor());

			return base.FinishedLaunching(uiApplication, options);
		}

		/// <summary>
		/// Wills the terminate.
		/// </summary>
		/// <param name="uiApplication">User interface application.</param>
		public override void WillTerminate(UIApplication uiApplication)
		{
			base.WillTerminate(uiApplication);

			Cache.Shutdown();
		}

		/// <summary>
		/// Sets the color of the status bar background.
		/// </summary>
		/// <param name="uiApplication">User interface application.</param>
		/// <param name="backgroundColor">Background color.</param>
		void SetStatusBarBackgroundColor(UIApplication uiApplication, UIColor backgroundColor)
		{
			var statusBarWindow = uiApplication.ValueForKey(new NSString("statusBarWindow"));
			var statusBar = statusBarWindow.ValueForKey(new NSString("statusBar"));

			(statusBar as UIView).BackgroundColor = backgroundColor;
		}
	}
}