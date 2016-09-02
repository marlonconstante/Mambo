using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading;
using Mobishop.Infrastructure.Repositories.Commons.Caching;
using NControl.Controls.Droid;
using Xamarin.Forms;

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

            UserDialogs.Init(() => (Activity)Forms.Context);

			base.OnCreate(bundle);

            FFImageLoading.Forms.Droid.CachedImageRenderer.Init();

            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                Logger = new FFImageCustomLogger(),
            };
            ImageService.Instance.Initialize(config);


            Forms.Init(this, bundle);
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