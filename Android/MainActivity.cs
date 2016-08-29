using Android.App;
using Android.Content.PM;
using Android.OS;
using Mobishop.Infrastructure.Repositories.Commons.Caching;
using NControl.Controls.Droid;

namespace Mambo.Android
{
	/// <summary>
	/// Main activity.
	/// </summary>
	[Activity(Label = "Mambo.Android", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		/// <summary>
		/// Ons the create.
		/// </summary>
		/// <returns>The create.</returns>
		/// <param name="bundle">Bundle.</param>
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

            Cache.Initialize("Mambo");

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			NControls.Init();

			LoadApplication(new App());
		}

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Cache.Shutdown();
        }
	}
}