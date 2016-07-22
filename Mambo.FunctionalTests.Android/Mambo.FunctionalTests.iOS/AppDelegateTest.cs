using Foundation;
using UIKit;

namespace Mambo.FunctionalTests.iOS
{
	/// <summary>
	/// App delegate test.
	/// </summary>
	[Register("AppDelegateTest")]
	public partial class AppDelegateTest : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
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

			var nunit = new NUnit.Runner.App {
				AutoRun = true
			};
			//nunit.AddTestAssembly(typeof(FunctionalTests).Assembly);
			LoadApplication(nunit);

			return base.FinishedLaunching(app, options);
		}
	}
}