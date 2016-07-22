using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Mambo.FunctionalTests.Android
{
	/// <summary>
	/// Main activity test.
	/// </summary>
	[Activity(Label = "Mambo.FunctionalTests.Android", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivityTest : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		/// <summary>
		/// Ons the create.
		/// </summary>
		/// <returns>The create.</returns>
		/// <param name="savedInstanceState">Saved instance state.</param>
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

			var nunit = new NUnit.Runner.App {
				AutoRun = true
			};
			//nunit.AddTestAssembly(typeof(FunctionalTests).Assembly);
			LoadApplication(nunit);
		}
	}
}