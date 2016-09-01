using Android.App;
using Android.Content.PM;
using Android.OS;
using Mobishop.Infrastructure.Repositories.Commons.Caching;
using Mobishop.Infrastructure.Repositories.FunctionalTests.Vtex.Products;

namespace Mobishop.Infrastructure.Repositories.FunctionalTests.Android
{
	/// <summary>
	/// Main activity.
	/// </summary>
	[Activity(Label = "NUnit 3.0", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		/// <summary>
		/// Ons the create.
		/// </summary>
		/// <param name="savedInstanceState">Saved instance state.</param>
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

			Cache.Initialize("MobiTests");

			var nunit = new NUnit.Runner.App {
				AutoRun = false
			};
			nunit.AddTestAssembly(typeof(VtexProductRepositoryTest).Assembly);

			LoadApplication(nunit);
		}

		/// <summary>
		/// Ons the destroy.
		/// </summary>
		protected override void OnDestroy()
		{
			base.OnDestroy();

			Cache.Shutdown();
		}
	}
}