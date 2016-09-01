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
		/// <returns><c>true</c>, if launching was finisheded, <c>false</c> otherwise.</returns>
		/// <param name="uiApplication">User interface application.</param>
		/// <param name="options">Options.</param>
		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			NControls.Init();

			Cache.Initialize("Mambo");

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			LoadApplication(new App());

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
	}
}