using Foundation;
using Mobishop.Infrastructure.Repositories.Commons.Caching;
using NControl.Controls.iOS;
using UIKit;

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
		/// <returns>The launching.</returns>
		/// <param name="app">App.</param>
		/// <param name="options">Options.</param>
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			NControls.Init();

			Cache.Initialize("Mambo");

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}

		/// <summary>
		/// Wills the terminate.
		/// </summary>
		/// <param name="app">App.</param>
		public override void WillTerminate(UIApplication app)
		{
			base.WillTerminate(app);

			Cache.Shutdown();
		}
	}
}