using System;
using FFImageLoading;
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
            FFImageLoading.Forms.Touch.CachedImageRenderer.Init();

			global::Xamarin.Forms.Forms.Init();
			NControls.Init();

            Cache.Initialize("Mambo");

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			LoadApplication(new App());

            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                Logger = new FFImageCustomLogger(),
            };
            ImageService.Instance.Initialize(config);

			return base.FinishedLaunching(app, options);
		}

        public override void WillTerminate(UIApplication uiApplication)
        {
            base.WillTerminate(uiApplication);
            Cache.Shutdown();
        }
	}
}