using Foundation;
using Mobishop.Infrastructure.Repositories.Commons.Caching;
using Mobishop.Infrastructure.Repositories.FunctionalTests.Vtex.Products;
using UIKit;

namespace Mobishop.Infrastructure.Repositories.FunctionalTests.iOS
{
	/// <summary>
	/// App delegate.
	/// </summary>
	[Register("AppDelegate")]
	public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
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

			Cache.Initialize("MobiTests");

			var nunit = new NUnit.Runner.App {
				AutoRun = false
			};
			nunit.AddTestAssembly(typeof(VtexProductRepositoryTest).Assembly);
			LoadApplication(nunit);

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